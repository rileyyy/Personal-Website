using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DatabaseInterface.DatabaseTypes;

public class Education
{
  [BsonId]
  [BsonElement("_id")]
  public ObjectId Id { get; set; }

  public required string Icon { get; set; }

  public required Institution Institution { get; set; }

  public required List<Degree> Degrees { get; set; }
}

public class Institution
{
  public required string Name { get; set; }

  public string? Location { get; set; }

  public string? Image { get; set; }

  public Dictionary<string, string>? Links { get; set; }
}

public class Degree
{
  public required string Name { get; set; }

  public string? Major { get; set; }

  public List<string>? Dates { get; set; }
}