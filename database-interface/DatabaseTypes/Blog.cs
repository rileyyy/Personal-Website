using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DatabaseInterface.DatabaseTypes;

public class Blog
{
  [BsonId]
  [BsonElement("_id")]
  public ObjectId Id { get; set; }

  [BsonElement("fileId")]
  public required int FileId { get; set; }

  [BsonElement("tags")]
  public required List<string> Tags { get; set; }

  [BsonElement("title")]
  public required string Title { get; set; }

  [BsonElement("content")]
  public required string Content { get; set; }

  [BsonElement("listDate")]
  public DateTime? ListDate { get; set; }

  public override bool Equals(object? obj)
  {
    if (obj == null || GetType() != obj.GetType())
    {
      return false;
    }

    var blog = (Blog)obj;
    return FileId == blog.FileId &&
           Title == blog.Title &&
           Content == blog.Content &&
           Tags.SequenceEqual(blog.Tags) &&
           ListDate == blog.ListDate;
  }

  public override int GetHashCode() =>
    HashCode.Combine(FileId, Title, Content, Tags, ListDate);
}