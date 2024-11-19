using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DatabaseInterface.DatabaseTypes;
using DatabaseInterface.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace DatabaseInterface.Controllers;

public class BlogController : ControllerBase
{
  private readonly MongoService mongoService;
  private readonly ILogger<BlogController> logger;

  public BlogController(MongoService mongoService, ILogger<BlogController> logger)
  {
    this.mongoService = mongoService;
    this.logger = logger;
  }

  [HttpGet]
  public async Task<IEnumerable<Blog>> GetBlogs() =>
    await this.mongoService.WebsiteDesignDatabase.GetCollection<Blog>("blogs").Find(blog => true).ToListAsync();

  [HttpGet("listed")]
  public async Task<IEnumerable<Blog>> GetListedBlogs() =>
    await this.mongoService.WebsiteDesignDatabase
            .GetCollection<Blog>("blogs")
            // null ListDate means the blog is to remain unlisted
            .Find(blog => blog.ListDate != null && blog.ListDate <= DateTime.Now)
            .ToListAsync();

  [HttpGet("{title}")]
  public async Task<Blog?> GetByFileId(int fileId) =>
    await this.mongoService.WebsiteDesignDatabase.GetCollection<Blog>("blogs").Find(blog => blog.FileId == fileId).FirstOrDefaultAsync();

  [HttpPost]
  public async Task<ActionResult> CreateBlog(Blog blog)
  {
    logger.LogInformation($"Creating {blog.Title} blog post");
    await this.mongoService.WebsiteDesignDatabase.GetCollection<Blog>("blogs").InsertOneAsync(blog);
    return CreatedAtAction(nameof(GetByFileId), new { fileId = blog.FileId }, blog);
  }

  [HttpPut("{id}")]
  public async Task<ActionResult> UpdateBlog(string id, Blog blog)
  {
    var result = await this.mongoService.WebsiteDesignDatabase.GetCollection<Blog>("blogs").ReplaceOneAsync(blog => blog.Id.ToString() == id, blog);
    return result.MatchedCount == 0 ? NotFound() : Ok();
  }

  [HttpDelete("{id}")]
  public async Task<ActionResult> DeleteBlog(string id)
  {
    var result = await this.mongoService.WebsiteDesignDatabase.GetCollection<Blog>("blogs").DeleteOneAsync(blog => blog.Id.ToString() == id);
    return result.DeletedCount == 0 ? NotFound() : Ok();
  }
}