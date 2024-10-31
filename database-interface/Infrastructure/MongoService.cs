using System.IO;
using System.Linq;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace database_interface.Infrastructure;

public class MongoService
{
  private readonly IMongoDatabase nodesDatabase;
  private readonly ILogger<MongoService> logger;

  public MongoService(ILogger<MongoService> logger)
  {
    this.logger = logger;

    var connectionString = GetConnectionString();
    var client = new MongoClient(connectionString);

    this.nodesDatabase = client.GetDatabase("website-design");
  }

  public IMongoDatabase NodesDatabase => this.nodesDatabase;

  private static string GetConnectionString()
  {
    var username = string.Empty;
    var password = string.Empty;
    File.ReadAllLines("/run/secrets/mongodb_username")
        .ToList()
        .ForEach(line => username = line);
    File.ReadAllLines("/run/secrets/mongodb_password")
        .ToList()
        .ForEach(line => password = line);

    return $"mongodb://{username}:{password}@mongodb:27017";
  }
}