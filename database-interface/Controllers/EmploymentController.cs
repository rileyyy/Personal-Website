using System.Collections.Generic;
using System.Threading.Tasks;
using DatabaseInterface.DatabaseTypes;
using DatabaseInterface.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace DatabaseInterface.Controllers;

[Route("/employments")]
[ApiController]
public class EmploymentController : ControllerBase
{
  private readonly IMongoCollection<Employment> employments;
  private readonly ILogger<EmploymentController> logger;

  public EmploymentController(MongoService mongoService, ILogger<EmploymentController> logger)
  {
    this.employments = mongoService.WebsiteDesignDatabase.GetCollection<Employment>("employments");
    this.logger = logger;
  }

  [HttpGet]
  public async Task<IEnumerable<Employment>> GetEmployments() =>
    await this.employments.Find(employment => true).ToListAsync();

  [HttpGet("{id}")]
  public async Task<Employment> GetById(string id) =>
    await this.employments.Find(employment => employment.Id.ToString() == id).FirstOrDefaultAsync();

  [HttpPost]
  public async Task<ActionResult> CreateEmployment(Employment employment)
  {
    logger.LogInformation($"Creating employment with company {employment.Company}");
    await this.employments.InsertOneAsync(employment);
    return CreatedAtAction(nameof(GetById), new { id = employment.Id }, employment);
  }

  [HttpPut("{id}")]
  public async Task<ActionResult> UpdateEmployment(string id, Employment employment)
  {
    logger.LogInformation($"Updating employment with id {id}");
    var result = await this.employments.ReplaceOneAsync(employment => employment.Id.ToString() == id, employment);
    return result.MatchedCount == 0 ? NotFound() : Ok();
  }

  [HttpDelete("{id}")]
  public async Task<ActionResult> DeleteEmployment(string id)
  {
    logger.LogInformation($"Deleting employment with id {id}");
    var result = await this.employments.DeleteOneAsync(employment => employment.Id.ToString() == id);
    return result.DeletedCount == 0 ? NotFound() : Ok();
  }
}