using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DatabaseInterface.DatabaseTypes;

public class Employment
{
  [BsonId]
  [BsonElement("_id")]
  public ObjectId Id { get; set; }

  public required string Company { get; set; }

  public string? Image { get; set; }

  public List<string>? Links { get; set; }

  public string? Location { get; set; }

  public string? Blurb { get; set; }

  public List<string>? Dates { get; set; }

  public required string Position { get; set; }

  public List<string>? TechStack { get; set; }

  public List<string>? ResponsibilitiesHR { get; set; }

  public List<string>? ResponsibilitiesEng { get; set; }

  public override bool Equals(object? obj)
  {
    if (obj is Employment otherEmployment)
    {
      return Id == otherEmployment.Id &&
             this.Company == otherEmployment.Company &&
             this.Image == otherEmployment.Image &&
             (this.Links ?? new List<string>()).SequenceEqual(otherEmployment.Links ?? new List<string>()) &&
             this.Location == otherEmployment.Location &&
             this.Blurb == otherEmployment.Blurb &&
             (this.Dates ?? new List<string>()).SequenceEqual(otherEmployment.Dates ?? new List<string>()) &&
             this.Position == otherEmployment.Position &&
             (this.TechStack ?? new List<string>()).SequenceEqual(otherEmployment.TechStack ?? new List<string>()) &&
             (this.ResponsibilitiesHR ?? new List<string>()).SequenceEqual(otherEmployment.ResponsibilitiesHR ?? new List<string>()) &&
             (this.ResponsibilitiesEng ?? new List<string>()).SequenceEqual(otherEmployment.ResponsibilitiesEng ?? new List<string>());
    }
    return false;
  }

  public override int GetHashCode()
  {
    int hash = 17;
    hash = hash * 23 + (Id?.GetHashCode() ?? 0);
    hash = hash * 23 + (Company?.GetHashCode() ?? 0);
    hash = hash * 23 + (Image?.GetHashCode() ?? 0);
    hash = hash * 23 + (Links?.GetHashCode() ?? 0);
    hash = hash * 23 + (Location?.GetHashCode() ?? 0);
    hash = hash * 23 + (Blurb?.GetHashCode() ?? 0);
    hash = hash * 23 + (Dates?.GetHashCode() ?? 0);
    hash = hash * 23 + (Position?.GetHashCode() ?? 0);
    hash = hash * 23 + (TechStack?.GetHashCode() ?? 0);
    hash = hash * 23 + (ResponsibilitiesHR?.GetHashCode() ?? 0);
    hash = hash * 23 + (ResponsibilitiesEng?.GetHashCode() ?? 0);
    return hash;
  }
}
