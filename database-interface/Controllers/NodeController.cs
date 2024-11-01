using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

using DatabaseInterface.DatabaseTypes;
using DatabaseInterface.Infrastructure;

namespace DatabaseInterface.Controllers;

[Route("/nodes")]
[ApiController]
public class NodeController : ControllerBase
{
  private readonly IMongoCollection<Node> nodes;
  private readonly ILogger<NodeController> logger;

  public NodeController(MongoService mongoService, ILogger<NodeController> logger)
  {
    this.nodes = mongoService.WebsiteDesignDatabase.GetCollection<Node>("nodes");
    this.logger = logger;
  }

  [HttpGet]
  public async Task<IEnumerable<Node>> GetNodes() =>
    await this.nodes.Find(node => true).ToListAsync();

  [HttpGet("{id}")]
  public async Task<Node> GetById(string id) =>
    await this.nodes.Find(node => node.Id.ToString() == id).FirstOrDefaultAsync();

  [HttpPost]
  public async Task<ActionResult> CreateNode(Node node)
  {
    logger.LogInformation($"Creating node with name {node.Name}");
    await this.nodes.InsertOneAsync(node);
    return CreatedAtAction(nameof(GetById), new { id = node.Id }, node);
  }

  [HttpPut("{id}")]
  public async Task<ActionResult> UpdateNode(string id, Node node)
  {
    logger.LogInformation($"Updating node with id {id}");
    var result = await this.nodes.ReplaceOneAsync(node => node.Id.ToString() == id, node);
    return result.MatchedCount == 0 ? NotFound() : Ok();
  }

  [HttpDelete("{id}")]
  public async Task<ActionResult> DeleteNode(string id)
  {
    logger.LogInformation($"Deleting node with id {id}");
    var result = await this.nodes.DeleteOneAsync(node => node.Id.ToString() == id);
    return result.DeletedCount == 0 ? NotFound() : Ok();
  }
}