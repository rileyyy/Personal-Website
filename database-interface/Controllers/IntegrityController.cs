using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

using database_interface.DatabaseTypes;
using database_interface.Infrastructure;

namespace database_interface.Controllers;

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

  [HttpGet("{id}")]
  public async Task<Integrity> GetById(string id) =>
    await this.integrity.Find(integrity => integrity.Id.ToString() == id).FirstOrDefaultAsync();

  [HttpPost]
  public async Task<ActionResult> CreateIntegrity(Integrity integrity)
  {
    logger.LogInformation($"Creating {integrity.Name} integrity record at version {integrity.Version}");
    await this.integrity.InsertOneAsync(integrity);
    return CreatedAtAction(nameof(GetById), new { id = integrity.Id }, integrity);
  }

  [HttpPut("{id}")]
  public async Task<ActionResult> UpdateIntegrity(string id, Integrity integrity)
  {
    logger.LogInformation($"Updating integrity record with id {id} to version {integrity.Version}");
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