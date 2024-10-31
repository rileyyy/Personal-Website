using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace database_interface.DatabaseTypes;

public struct Node
{
  [BsonId]
  [BsonElement("_id")]
  [BsonRepresentation(BsonType.ObjectId)]

  public string Id { get; set; }

  [BsonElement("name")]
  public string Name { get; set; }

  [BsonElement("icon")]
  public string Icon { get; set; }

  [BsonElement("position")]
  public int[] Position { get; set; }

  [BsonElement("parentNodeId")]
  public string ParentNodeId { get; set; }

  [BsonElement("shownNodeIds")]
  public List<string> ShownNodeIds { get; set; }

  [BsonElement("nodeType")]
  public NodeType NodeType { get; set; }
}