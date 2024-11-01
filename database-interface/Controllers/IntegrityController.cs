using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

using DatabaseInterface.DatabaseTypes;
using DatabaseInterface.Infrastructure;

namespace DatabaseInterface.Controllers;

[Route("/integrity")]
[ApiController]
public class IntegrityController : ControllerBase
{
  private readonly IMongoCollection<Integrity> integrity;
  private readonly ILogger<IntegrityController> logger;

  public IntegrityController(MongoService mongoService, ILogger<IntegrityController> logger)
  {
    this.integrity = mongoService.WebsiteDesignDatabase.GetCollection<Integrity>("integrity");
    this.logger = logger;
  }

  [HttpGet]
  public async Task<IEnumerable<Integrity>> GetIntegrity() =>
    await this.integrity.Find(integrity => true).ToListAsync();

  [HttpGet("{name}")]
  public async Task<Integrity?> GetByName(string name) =>
    await this.integrity.Find(integrity => integrity.Name == name).FirstOrDefaultAsync();

  [HttpPost]
  public async Task<ActionResult> CreateIntegrity(Integrity integrity)
  {
    logger.LogInformation($"Creating {integrity.Name} integrity record at version {integrity.Version}");
    await this.integrity.InsertOneAsync(integrity);
    return CreatedAtAction(nameof(GetByName), new { id = integrity.Id }, integrity);
  }

  [HttpPut("{id}")]
  public async Task<ActionResult> UpdateIntegrity(string id, Integrity integrity)
  {
    var result = await this.integrity.ReplaceOneAsync(integrity => integrity.Id.ToString() == id, integrity);
    return result.MatchedCount == 0 ? NotFound() : Ok();
  }

  [HttpDelete("{id}")]
  public async Task<ActionResult> DeleteIntegrity(string id)
  {
    var result = await this.integrity.DeleteOneAsync(integrity => integrity.Id.ToString() == id);
    return result.DeletedCount == 0 ? NotFound() : Ok();
  }
}