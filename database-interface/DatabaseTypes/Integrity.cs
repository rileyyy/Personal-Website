using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DatabaseInterface.DatabaseTypes;

public struct Integrity
{
  [BsonId]
  [BsonElement("_id")]
  public ObjectId Id { get; set; }

  [BsonElement("name")]
  public string Name { get; set; }

  [BsonElement("version")]
  public string Version { get; set; }
}
