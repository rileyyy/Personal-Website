using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DatabaseInterface.DatabaseTypes;

public class Skill
{
  [BsonId]
  [BsonElement("_id")]
  public ObjectId Id { get; set; }

  [BsonElement("name")]
  public required string Name { get; set; }

  [BsonElement("type")]
  [BsonRepresentation(BsonType.String)]
  [JsonConverter(typeof(StringEnumConverter))]
  public required SkillType Type { get; set; }

  [BsonElement("explanation")]
  public required string Explanation { get; set; }

  [BsonElement("subSkills")]
  public List<Skill>? SubSkills { get; set; }
}

public enum SkillType
{
  Language,
  Framework,
  Package,
  Tool,
  Other,
}