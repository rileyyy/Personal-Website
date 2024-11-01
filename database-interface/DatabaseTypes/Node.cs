using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DatabaseInterface.DatabaseTypes;

public class Node
{
  [BsonId]
  [BsonElement("_id")]
  public ObjectId Id { get; set; }

  [BsonElement("name")]
  public required string Name { get; set; }

  [BsonElement("icon")]
  public required string Icon { get; set; }

  [BsonElement("position")]
  public required int[] Position { get; set; }

  [BsonElement("parentNode")]
  public string? ParentNode { get; set; }

  [BsonElement("showNodes")]
  public required List<string> ShowNodes { get; set; }

  [BsonElement("nodeType")]
  public NodeType NodeType { get; set; }

  public override bool Equals(object? obj)
  {
    if (obj is Node otherNode)
    {
      return Name == otherNode.Name &&
             Icon == otherNode.Icon &&
             Position.SequenceEqual(otherNode.Position) &&
             ParentNode == otherNode.ParentNode &&
             ShowNodes.SequenceEqual(otherNode.ShowNodes) &&
             NodeType == otherNode.NodeType;
    }
    return false;
  }

  public override int GetHashCode()
  {
    int hash = 17;
    hash = hash * 23 + (Name?.GetHashCode() ?? 0);
    hash = hash * 23 + (Icon?.GetHashCode() ?? 0);
    hash = hash * 23 + (Position?.GetHashCode() ?? 0);
    hash = hash * 23 + (ParentNode?.GetHashCode() ?? 0);
    hash = hash * 23 + (ShowNodes?.GetHashCode() ?? 0);
    hash = hash * 23 + NodeType.GetHashCode();
    return hash;
  }
}