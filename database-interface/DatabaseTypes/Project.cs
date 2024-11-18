using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DatabaseInterface.DatabaseTypes;

public class Project
{
  [BsonId]
  [BsonElement("_id")]
  public ObjectId Id { get; set; }

  [BsonElement("name")]
  public required string Name { get; set; }

  [BsonElement("link")]
  public string? Link { get; set; }

  [BsonElement("description")]
  public string? Description { get; set; }

  [BsonElement("technologies")]
  public required List<string> Technologies { get; set; }

  [BsonElement("images")]
  public List<string>? Images { get; set; }

  public override bool Equals(object? obj)
  {
    if (obj == null || GetType() != obj.GetType())
    {
      return false;
    }

    var project = (Project)obj;
    return Id == project.Id &&
           Name == project.Name &&
           Link == project.Link &&
           Description == project.Description &&
           Technologies == project.Technologies &&
           Images == project.Images;
  }

  public override int GetHashCode() =>
    HashCode.Combine(Id, Name, Link, Description, Technologies, Images);
}