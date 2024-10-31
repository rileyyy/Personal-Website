using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

using database_interface.DatabaseTypes;
using database_interface.Controllers;

namespace database_interface.Infrastructure;

public class IntegrityService
{
  private readonly IntegrityController integrityController;
  private readonly NodeController nodeController;
  private readonly ILogger<IntegrityService> logger;
  private readonly FileSystemWatcher watcher = new FileSystemWatcher
  {
    Path = "/data",
    NotifyFilter = NotifyFilters.LastWrite,
    Filter = "*.yaml",
    EnableRaisingEvents = true,
  };

  public IntegrityService(
    IntegrityController integrityController,
    NodeController nodeController,
    ILogger<IntegrityService> logger)
  {
    this.integrityController = integrityController;
    this.nodeController = nodeController;
    this.logger = logger;

    this.logger.LogInformation("Integrity service started");
  }

  public void StartDataMonitor()
  {
    this.logger.LogInformation("Starting data monitor");
    this.watcher.Changed += (_, _) => this.CheckIntegrity();
    this.CheckIntegrity();
  }

  public void StopDataMonitor()
  {
    this.watcher.Changed -= (_, _) => this.CheckIntegrity();
  }

  public async void CheckIntegrity()
  {
    var integrityRecords = (await this.integrityController.GetIntegrity()).ToList();

    foreach (var integrityRecord in integrityRecords)
    {
      var yamlPath = Path.Combine("/data", $"{integrityRecord.Name}.yaml");
      if (!File.Exists(yamlPath))
      {
        this.logger.LogWarning($"YAML file for {integrityRecord.Name} does not exist.");
        continue;
      }

      var yamlContent = File.ReadAllText(yamlPath);
      var deserializer = new DeserializerBuilder()
        .WithNamingConvention(CamelCaseNamingConvention.Instance)
        .Build();

      var yamlData = deserializer.Deserialize<Dictionary<string, object>>(yamlContent);
      if (!yamlData.TryGetValue("version", out var version))
      {
        this.logger.LogInformation($"Version not found in YAML file for {integrityRecord.Name}");
        continue;
      }

      if (version.ToString() != integrityRecord.Version)
      {
        this.logger.LogInformation($"Version mismatch for {integrityRecord.Name}:"
                                  + $"\n\tDatabase version {integrityRecord.Version},"
                                  + $"\n\tYAML version {version}");
        await this.UpdateMongoDatabaseToLatest(yamlData, version.ToString());
      }
    }
  }

  public async Task UpdateMongoDatabaseToLatest(Dictionary<string, object> data, string version)
  {
    if (!data.TryGetValue("type", out var type))
    {
      this.logger.LogWarning("Type definition not found in YAML file");
      return;
    }

    if (!data.TryGetValue("data", out var dataObject))
    {
      this.logger.LogWarning("Data definition not found in YAML file");
      return;
    }

    switch (type.ToString())
    {
      case "Node":
        await this.UpdateNodesCollection((List<object>)dataObject);
        await this.UpdateIntegrityRecord("Nodes", version);
        break;

      default:
        this.logger.LogWarning($"Unknown type {type}");
        break;
    }
  }

  private async Task UpdateNodesCollection(List<object> data)
  {
    var existingNodes = await this.nodeController.GetNodes();

    foreach (var key in data)
    {
      var nodes = (Dictionary<object, object>)key;

      var node = new Node
      {
        Name = nodes["name"].ToString(),
        Icon = nodes["icon"].ToString(),
        Position = ((List<object>)nodes["position"]).Select(x => Convert.ToInt32(x)).ToArray(),
        ParentNode = nodes.TryGetValue("parentNode", out var parentNodeId) ? parentNodeId.ToString() : null,
        ShowNodes = ((List<object>)nodes["showNodes"]).Select(x => x.ToString()).ToList(),
        NodeType = Enum.Parse<NodeType>(nodes["nodeType"].ToString()),
      };

      var existingNode = existingNodes.FirstOrDefault(n => n.Name == node.Name);
      if (existingNode is not null)
      {
        node.Id = existingNode.Id;
        await this.nodeController.UpdateNode(existingNode.Id.ToString(), node);
      }
      else
      {
        await this.nodeController.CreateNode(node);
      }
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

  private async Task UpdateIntegrityRecord(string name, string version)
  {
    var integrityRecord = await this.integrityController.GetByName(name);
    integrityRecord.Version = version;
    logger.LogInformation($"Updating integrity record {name} to version {version}");
    await this.integrityController.UpdateIntegrity(integrityRecord.Id.ToString(), integrityRecord);
  }
}