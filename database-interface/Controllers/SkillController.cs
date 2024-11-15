using System.Collections.Generic;
using System.Threading.Tasks;
using DatabaseInterface.DatabaseTypes;
using DatabaseInterface.Infrastructure;
using DnsClient.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace DatabaseInterface.Controllers;

[Route("/skills")]
[ApiController]
public class SkillController : ControllerBase
{
  private readonly MongoService mongoService;
  private readonly ILogger<SkillController> logger;

  public SkillController(MongoService mongoService, ILogger<SkillController> logger)
  {
    this.mongoService = mongoService;
    this.logger = logger;
  }

  [HttpGet]
  public async Task<IEnumerable<Skill>> GetSkills() =>
    await this.mongoService.WebsiteDesignDatabase.GetCollection<Skill>("skills").Find(skill => true).ToListAsync();

  [HttpGet("{id}")]
  public async Task<Skill> GetById(string id) =>
    await this.mongoService.WebsiteDesignDatabase.GetCollection<Skill>("skills").Find(skill => skill.Id.ToString() == id).FirstOrDefaultAsync();

  [HttpPost]
  public async Task<ActionResult> CreateSkill(Skill skill)
  {
    logger.LogInformation($"Creating skill with name {skill.Name}");
    await this.mongoService.WebsiteDesignDatabase.GetCollection<Skill>("skills").InsertOneAsync(skill);
    return CreatedAtAction(nameof(GetById), new { id = skill.Id }, skill);
  }

  [HttpPut("{id}")]
  public async Task<ActionResult> UpdateSkill(string id, Skill skill)
  {
    logger.LogInformation($"Updating skill with id {id}");
    var result = await this.mongoService.WebsiteDesignDatabase.GetCollection<Skill>("skills").ReplaceOneAsync(skill => skill.Id.ToString() == id, skill);
    return result.MatchedCount == 0 ? NotFound() : Ok();
  }

  [HttpDelete("{id}")]
  public async Task<ActionResult> DeleteSkill(string id)
  {
    logger.LogInformation($"Deleting skill with id {id}");
    var result = await this.mongoService.WebsiteDesignDatabase.GetCollection<Skill>("skills").DeleteOneAsync(skill => skill.Id.ToString() == id);
    return result.DeletedCount == 0 ? NotFound() : Ok();
  }
}