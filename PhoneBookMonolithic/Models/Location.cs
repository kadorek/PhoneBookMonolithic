using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PhoneBookMonolithic.Models
{
    public class Location : IModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string UUID { get; set; }
        public string Name { get; set; }
    }
}
