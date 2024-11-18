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
  private readonly ProjectController projectController;
  private readonly SkillController skillController;
  private readonly EducationController educationController;
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
    ProjectController projectController,
    SkillController skillController,
    EducationController educationController,
    ILogger<IntegrityService> logger)
  {
    this.integrityController = integrityController;
    this.nodeController = nodeController;
    this.employmentController = employmentController;
    this.projectController = projectController;
    this.skillController = skillController;
    this.educationController = educationController;
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
      var fileVersion = yaml["version"];

      if (fileVersion is null)
      {
        this.logger.LogError($"Version not found in YAML file for {file}");
        continue;
      }

      var integrityVersion = integrityRecords.FirstOrDefault(r => r.Name == fileName)?.Version;
      if ((string)fileVersion == integrityVersion)
      {
        this.logger.LogInformation($"No changes detected for {fileName}");
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

        case "Projects":
          await this.UpdateProjectCollection(fileData);
          break;

        case "Skills":
          await this.UpdateSkillCollection(fileData);
          break;

        case "Education":
          await this.UpdateEducationCollection(fileData);
          break;

        default:
          this.logger.LogWarning($"Unknown type {fileName}");
          return;
      }

      await this.UpdateIntegrityRecord(fileName, (string)fileVersion!);
    }

    this.isCheckingIntegrity = false;
  }

  private async Task UpdateNodesCollection(List<object> data)
  {
    var existingNodes = await this.nodeController.GetNodes();
    var dictionary = data.Cast<Dictionary<object, object>>();

    foreach (var node in dictionary)
    {
      var newNode = new Node
      {
        Name = node["name"].ToString()!,
        Icon = node["icon"].ToString()!,
        Position = ((List<object>)node["position"]).Select(x => Convert.ToInt32(x)).ToArray(),
        ParentNode = node["parentNode"]?.ToString(),
        ShowNodes = ((List<object>)node["showNodes"]).Select(x => x.ToString()!).ToList(),
        NodeType = Enum.Parse<NodeType>(node["nodeType"].ToString()!),
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
      if (dictionary.All(n => n["name"].ToString() != existingNode.Name))
      {
        await this.nodeController.DeleteNode(existingNode.Id.ToString());
      }
    }
  }

  private async Task UpdateEmploymentCollection(List<object> data)
  {
    var existing = await this.employmentController.GetEmployments();
    var dictionary = data.Cast<Dictionary<object, object>>();

    foreach (var employment in dictionary)
    {
      var newEmployment = new Employment
      {
        Company = employment["company"].ToString()!,
        Image = employment["image"].ToString(),
        Links = ((Dictionary<object, object>)employment["links"]).ToDictionary(k => k.Key.ToString()!, v => v.Value.ToString()!),
        Location = employment["location"].ToString(),
        Blurb = employment["blurb"].ToString(),
        Dates = ((List<object>)employment["dates"]).Cast<string>().ToList(),
        Position = employment["position"].ToString()!,
        TechStack = ((List<object>)employment["techStack"]).Cast<string>().ToList(),
        ResponsibilitiesHR = ((List<object>)employment["responsibilitiesHR"]).Cast<string>().ToList(),
        ResponsibilitiesEng = ((List<object>)employment["responsibilitiesEng"]).Cast<string>().ToList(),
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
      if (dictionary.All(e => e["company"].ToString() != existingEmployment.Company))
      {
        await this.employmentController.DeleteEmployment(existingEmployment.Id.ToString());
      }
    }
  }

  private async Task UpdateProjectCollection(List<object> data)
  {
    var existing = await this.projectController.GetProjects();
    var dictionary = data.Cast<Dictionary<object, object>>();

    foreach (var project in dictionary)
    {
      var newProject = new Project
      {
        Name = project["name"].ToString()!,
        Link = project["link"].ToString(),
        Description = project["description"].ToString(),
        Technologies = ((List<object>)project["technologies"]).Cast<string>().ToList(),
        Images = ((List<object>)project["images"]).Cast<string>().ToList(),
      };

      var existingProject = existing.FirstOrDefault(p => p.Name == newProject.Name);
      if (existingProject is null)
      {
        await this.projectController.CreateProject(newProject);
        continue;
      }

      newProject.Id = existingProject.Id;
      await this.projectController.UpdateProject(existingProject.Id.ToString(), newProject);
    }

    // Delete projects that are not in the YAML file
    foreach (var existingProject in existing)
    {
      if (dictionary.All(p => p["name"].ToString() != existingProject.Name))
      {
        await this.projectController.DeleteProject(existingProject.Id.ToString());
      }
    }
  }

  public async Task UpdateSkillCollection(List<object> data)
  {
    var existing = await this.skillController.GetSkills();
    var dictionary = data.Cast<Dictionary<object, object>>();

    foreach (var skill in dictionary)
    {
      var newSkill = ParseSkill(skill);

      var existingSkill = existing.FirstOrDefault(s => s.Name == newSkill.Name);
      if (existingSkill is null)
      {
        await this.skillController.CreateSkill(newSkill);
        continue;
      }

      newSkill.Id = existingSkill.Id;
      await this.skillController.UpdateSkill(existingSkill.Id.ToString(), newSkill);
    }

    // Delete skills that are not in the YAML file
    foreach (var existingSkill in existing)
    {
      if (dictionary.All(s => s.ToString() != existingSkill.Name))
      {
        await this.skillController.DeleteSkill(existingSkill.Id.ToString());
      }
    }

    Skill ParseSkill(Dictionary<object, object> skill)
    {
      var newSkill = new Skill
      {
        Name = skill["skill"].ToString()!,
        Type = Enum.Parse<SkillType>(skill["type"].ToString() ?? "Other", true),
        Explanation = skill.TryGetValue("explanation", out var explanation) ? explanation.ToString() : null,
      };

      if (skill.TryGetValue("subskills", out var subs))
      {
        newSkill.SubSkills = new List<Skill>();

        var subskills = (List<object>)subs;
        foreach (var subskill in subskills)
        {
          newSkill.SubSkills.Add(ParseSkill((Dictionary<object, object>)subskill));
        }
      }

      return newSkill;
    }
  }

  public async Task UpdateEducationCollection(List<object> data)
  {
    var existing = await this.educationController.GetEducation();
    var dictionary = data.Cast<Dictionary<object, object>>();

    foreach (var education in dictionary)
    {
      var institution = (Dictionary<object, object>)education["institution"];
      var degrees = (List<object>)education["degrees"];

      var newEducation = new Education
      {
        Institution = new Institution
        {
          Name = institution["name"].ToString()!,
          Location = institution.TryGetValue("location", out var location) ? location.ToString() : null,
          Image = institution.TryGetValue("image", out var image) ? image.ToString() : null,
          Links = institution.TryGetValue("links", out var links)
                    ? ((Dictionary<object, object>)links).ToDictionary(k => k.Key.ToString()!, v => v.Value.ToString()!)
                    : null,
        },
        Degrees = degrees.Select(d =>
        {
          var degree = (Dictionary<object, object>)d;
          return new Degree
          {
            Name = degree["name"].ToString()!,
            Major = degree.TryGetValue("major", out var major) ? major.ToString() : null,
            Dates = degree.TryGetValue("dates", out var dates) ? ((List<object>)dates).Cast<string>().ToList() : null,
          };
        }).ToList(),
      };

      var existingEducation = existing.FirstOrDefault(e => e.Institution.Name == newEducation.Institution.Name);
      if (existingEducation is null)
      {
        await this.educationController.CreateEducation(newEducation);
        continue;
      }

      newEducation.Id = existingEducation.Id;
      await this.educationController.UpdateEducation(existingEducation.Id.ToString(), newEducation);
    }

    // Delete education records that are not in the YAML file
    foreach (var existingEducation in existing)
    {
      if (dictionary.All(e => ((Dictionary<object, object>)e["institution"])["name"].ToString() != existingEducation.Institution.Name))
      {
        await this.educationController.DeleteEducation(existingEducation.Id.ToString());
      }
    }
  }

  private async Task UpdateIntegrityRecord(string name, string version)
  {
    var record = await this.integrityController.GetByName(name);
    if (record is null)
    {
      this.logger.LogInformation($"Creating integrity record {name} at version {version}");
      await this.integrityController.CreateIntegrity(new Integrity { Name = name, Version = version });
      return;
    }

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
