using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

using DatabaseInterface.DatabaseTypes;
using DatabaseInterface.Controllers;

namespace DatabaseInterface.Infrastructure;

public class IntegrityService
{
  private readonly IntegrityController integrityController;
  private readonly NodeController nodeController;
  private readonly EmploymentController employmentController;
  private readonly ILogger<IntegrityService> logger;
  private readonly FileSystemWatcher watcher = new FileSystemWatcher
  {
    Path = "/data",
    NotifyFilter = NotifyFilters.LastWrite,
    Filter = "*.yaml",
    EnableRaisingEvents = true,
  };

  private bool isCheckingIntegrity = false;
  private DateTime lastEventTime = DateTime.MinValue;
  private readonly TimeSpan debounceTime = TimeSpan.FromSeconds(5);

  public IntegrityService(
    IntegrityController integrityController,
    NodeController nodeController,
    EmploymentController employmentController,
    ILogger<IntegrityService> logger)
  {
    this.integrityController = integrityController;
    this.nodeController = nodeController;
    this.employmentController = employmentController;
    this.logger = logger;
  }

  public void StartDataMonitor()
  {
    this.logger.LogInformation("Integrity service started");
    this.watcher.Changed += OnChanged;
    this.CheckIntegrity();
  }

  public void StopDataMonitor() =>
    this.watcher.Changed -= OnChanged;

  private void OnChanged(object sender, FileSystemEventArgs e)
  {
    var currentTime = DateTime.Now;
    if (currentTime - this.lastEventTime > this.debounceTime)
    {
      this.lastEventTime = currentTime;
      this.logger.LogInformation("Data change detected: {0}", e.FullPath);
      this.CheckIntegrity();
    }
  }

  public async void CheckIntegrity()
  {
    if (this.isCheckingIntegrity) return;
    this.isCheckingIntegrity = true;

    var integrityRecords = (await this.integrityController.GetIntegrity()).ToList();
    foreach (var file in Directory.GetFiles("/data", "*.yaml"))
    {
      var fileName = Path.GetFileNameWithoutExtension(file);
      var fileText = File.ReadAllText(file);
      var yaml = this.ParseYaml(fileText);

      if (!yaml.TryGetValue("version", out var version))
      {
        this.logger.LogError($"Version not found in YAML file for {file}");
        continue;
      }

      var fileVersion = version.ToString();

      var integrityVersion = integrityRecords.FirstOrDefault(r => r.Name == fileName).Version;
      if (fileVersion == integrityVersion)
      {
        continue;
      }

      this.logger.LogInformation($"Version mismatch for {fileName}:"
                                + $"\n\tDatabase version {integrityVersion},"
                                + $"\n\tYAML version {fileVersion}");

      if (!yaml.TryGetValue("data", out var data))
      {
        this.logger.LogError($"Data not found in YAML file for {file}");
        continue;
      }
      var fileData = (List<object>)data;

      switch (fileName)
      {
        case "Nodes":
          await this.UpdateNodesCollection(fileData);
          break;

        case "Employment":
          await this.UpdateEmploymentCollection(fileData);
          break;

        default:
          this.logger.LogWarning($"Unknown type {fileName}");
          return;
      }

      await this.UpdateIntegrityRecord(fileName, fileVersion!);
    }

    this.isCheckingIntegrity = false;
  }

  private async Task UpdateNodesCollection(List<object> data)
  {
    var existingNodes = await this.nodeController.GetNodes();

    foreach (var entry in data)
    {
      var node = (Dictionary<object, object>)entry;

      var newNode = new Node
      {
        Name = node["name"].ToString(),
        Icon = node["icon"].ToString(),
        Position = ((List<object>)node["position"]).Select(x => Convert.ToInt32(x)).ToArray(),
        ParentNode = node.TryGetValue("parentNode", out var parentNode) ? parentNode?.ToString() : null,
        ShowNodes = ((List<object>)node["showNodes"]).Select(x => x.ToString()).ToList(),
        NodeType = Enum.Parse<NodeType>(node["nodeType"].ToString()),
      };

      var existingNode = existingNodes.FirstOrDefault(n => n.Name == newNode.Name);
      if (existingNode is null)
      {
        await this.nodeController.CreateNode(newNode);
        continue;
      }

      newNode.Id = existingNode.Id;
      await this.nodeController.UpdateNode(existingNode.Id.ToString(), newNode);
    }

    // Delete nodes that are not in the YAML file
    foreach (var existingNode in existingNodes)
    {
      if (data.Cast<Dictionary<object, object>>().All(n => n["name"].ToString() != existingNode.Name))
      {
        await this.nodeController.DeleteNode(existingNode.Id.ToString());
      }
    }
  }

  private async Task UpdateEmploymentCollection(List<object> data)
  {
    var existing = await this.employmentController.GetEmployments();

    foreach (var emp in data)
    {
      var employment = (Dictionary<object, object>)emp;

      var newEmployment = new Employment
      {
        Company = employment["company"].ToString(),
        Image = employment.TryGetValue("image", out var image) ? image?.ToString() : null,
        Links = employment.TryGetValue("links", out var links) ? ((List<object>)links).Select(x => x.ToString()).ToList() : null,
        Location = employment.TryGetValue("location", out var location) ? location?.ToString() : null,
        Blurb = employment.TryGetValue("blurb", out var blurb) ? blurb?.ToString() : null,
        Dates = employment.TryGetValue("dates", out var dates) ? ((List<object>)dates).Select(x => x.ToString()).ToList() : null,
        Position = employment["position"].ToString(),
        TechStack = employment.TryGetValue("techStack", out var techStack) ? ((List<object>)techStack).Select(x => x.ToString()).ToList() : null,
        ResponsibilitiesHR = employment.TryGetValue("responsibilitiesHR", out var responsibilitiesHR) ? ((List<object>)responsibilitiesHR).Select(x => x.ToString()).ToList() : null,
        ResponsibilitiesEng = employment.TryGetValue("responsibilitiesEng", out var responsibilitiesEng) ? ((List<object>)responsibilitiesEng).Select(x => x.ToString()).ToList() : null,
      };

      var existingEmployment = existing.FirstOrDefault(e => e.Company == newEmployment.Company);
      if (existingEmployment is null)
      {
        await this.employmentController.CreateEmployment(newEmployment);
        continue;
      }

      newEmployment.Id = existingEmployment.Id;
      await this.employmentController.UpdateEmployment(existingEmployment.Id.ToString(), newEmployment);
    }

    // Delete employments that are not in the YAML file
    foreach (var existingEmployment in existing)
    {
      if (data.Cast<Dictionary<object, object>>().All(e => e["company"].ToString() != existingEmployment.Company))
      {
        await this.employmentController.DeleteEmployment(existingEmployment.Id.ToString());
      }
    }
  }

  private async Task UpdateIntegrityRecord(string name, string version)
  {
    var integrityRecord = await this.integrityController.GetByName(name);
    if (integrityRecord is null)
    {
      this.logger.LogInformation($"Creating integrity record {name} at version {version}");
      await this.integrityController.CreateIntegrity(new Integrity { Name = name, Version = version });
      return;
    }

    var record = integrityRecord.Value;
    record.Version = version;
    logger.LogInformation($"Updating integrity record {name} to version {version}");
    await this.integrityController.UpdateIntegrity(record.Id.ToString(), record);
  }

  private Dictionary<string, object> ParseYaml(string yaml) =>
    new DeserializerBuilder()
      .WithNamingConvention(CamelCaseNamingConvention.Instance)
      .Build()
      .Deserialize<Dictionary<string, object>>(yaml);
}