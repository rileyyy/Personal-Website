using System.Collections.Generic;
using System.Threading.Tasks;
using DatabaseInterface.DatabaseTypes;
using DatabaseInterface.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace DatabaseInterface.Controllers;

[Route("/education")]
[ApiController]
public class EducationController : ControllerBase
{
  private readonly IMongoCollection<Education> education;
  private readonly ILogger<EducationController> logger;

  public EducationController(MongoService mongoService, ILogger<EducationController> logger)
  {
    this.education = mongoService.WebsiteDesignDatabase.GetCollection<Education>("education");
    this.logger = logger;
  }

  [HttpGet]
  public async Task<IEnumerable<Education>> GetEducation() =>
    await this.education.Find(education => true).ToListAsync();

  [HttpGet("{id}")]
  public async Task<Education> GetById(string id) =>
    await this.education.Find(education => education.Id.ToString() == id).FirstOrDefaultAsync();

  [HttpPost]
  public async Task<ActionResult> CreateEducation(Education education)
  {
    await this.education.InsertOneAsync(education);
    return CreatedAtAction(nameof(GetById), new { id = education.Id }, education);
  }

  [HttpPut("{id}")]
  public async Task<ActionResult> UpdateEducation(string id, Education education)
  {
    logger.LogInformation($"Updating education record with id {id}");
    var result = await this.education.ReplaceOneAsync(education => education.Id.ToString() == id, education);
    return result.MatchedCount == 0 ? NotFound() : Ok();
  }

  [HttpDelete("{id}")]
  public async Task<ActionResult> DeleteEducation(string id)
  {
    logger.LogInformation($"Deleting education record with id {id}");
    var result = await this.education.DeleteOneAsync(education => education.Id.ToString() == id);
    return result.DeletedCount == 0 ? NotFound() : Ok();
  }
}