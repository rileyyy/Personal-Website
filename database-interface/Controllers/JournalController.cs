using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DatabaseInterface.DatabaseTypes;
using DatabaseInterface.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace DatabaseInterface.Controllers;

[Route("/journals")]
[ApiController]
public class JournalController : ControllerBase
{
  private readonly MongoService mongoService;
  private readonly ILogger<JournalController> logger;

  public JournalController(MongoService mongoService, ILogger<JournalController> logger)
  {
    this.mongoService = mongoService;
    this.logger = logger;
  }

  [HttpGet]
  public async Task<IEnumerable<Journal>> GetJournals() =>
    await this.mongoService.WebsiteDesignDatabase.GetCollection<Journal>("journals").Find(journal => true).ToListAsync();

  [HttpGet("listed")]
  public async Task<IEnumerable<Journal>> GetListedJournals() =>
    await this.mongoService.WebsiteDesignDatabase
            .GetCollection<Journal>("journals")
            // null ListDate means the journal is to remain unlisted
            .Find(journal => journal.ListDate != null && journal.ListDate <= DateTime.Now)
            .ToListAsync();

  [HttpGet("{fileId}")]
  public async Task<Journal?> GetByFileId(int fileId) =>
    await this.mongoService.WebsiteDesignDatabase.GetCollection<Journal>("journals").Find(journal => journal.FileId == fileId).FirstOrDefaultAsync();

  [HttpPost]
  public async Task<ActionResult> CreateJournal(Journal journal)
  {
    logger.LogInformation($"Creating {journal.Title} journal post");
    await this.mongoService.WebsiteDesignDatabase.GetCollection<Journal>("journals").InsertOneAsync(journal);
    return CreatedAtAction(nameof(GetByFileId), new { fileId = journal.FileId }, journal);
  }

  [HttpPut("{id}")]
  public async Task<ActionResult> UpdateJournal(string id, Journal journal)
  {
    var result = await this.mongoService.WebsiteDesignDatabase.GetCollection<Journal>("journals").ReplaceOneAsync(journal => journal.Id.ToString() == id, journal);
    return result.MatchedCount == 0 ? NotFound() : Ok();
  }

  [HttpDelete("{id}")]
  public async Task<ActionResult> DeleteJournal(string id)
  {
    var result = await this.mongoService.WebsiteDesignDatabase.GetCollection<Journal>("journals").DeleteOneAsync(journal => journal.Id.ToString() == id);
    return result.DeletedCount == 0 ? NotFound() : Ok();
  }
}