using System.Collections.Generic;
using System.Threading.Tasks;
using DatabaseInterface.DatabaseTypes;
using DatabaseInterface.Infrastructure;
using DnsClient.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace DatabaseInterface.Controllers;

[Route("/projects")]
[ApiController]
public class ProjectController : ControllerBase
{
  private readonly IMongoCollection<Project> projects;
  private readonly ILogger<ProjectController> logger;

  public ProjectController(MongoService mongoService, ILogger<ProjectController> logger)
  {
    this.projects = mongoService.WebsiteDesignDatabase.GetCollection<Project>("projects");
    this.logger = logger;
  }

  [HttpGet]
  public async Task<IEnumerable<Project>> GetProjects() =>
    await this.projects.Find(project => true).ToListAsync();

  [HttpGet("{id}")]
  public async Task<Project> GetById(string id) =>
    await this.projects.Find(project => project.Id.ToString() == id).FirstOrDefaultAsync();

  [HttpPost]
  public async Task<ActionResult> CreateProject(Project project)
  {
    logger.LogInformation($"Creating project with name {project.Name}");
    await this.projects.InsertOneAsync(project);
    return CreatedAtAction(nameof(GetById), new { id = project.Id }, project);
  }

  [HttpPut("{id}")]
  public async Task<ActionResult> UpdateProject(string id, Project project)
  {
    logger.LogInformation($"Updating project with id {id}");
    var result = await this.projects.ReplaceOneAsync(project => project.Id.ToString() == id, project);
    return result.MatchedCount == 0 ? NotFound() : Ok();
  }

  [HttpDelete("{id}")]
  public async Task<ActionResult> DeleteProject(string id)
  {
    logger.LogInformation($"Deleting project with id {id}");
    var result = await this.projects.DeleteOneAsync(project => project.Id.ToString() == id);
    return result.DeletedCount == 0 ? NotFound() : Ok();
  }
}