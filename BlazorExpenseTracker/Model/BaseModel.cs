using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BlazorExpenseTracker.Model
{
    public abstract class BaseModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
    }
}
