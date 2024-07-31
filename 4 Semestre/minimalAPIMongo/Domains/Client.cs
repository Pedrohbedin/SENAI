using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace minimalAPIMongo.Domains
{
    public class Client
    {
        [BsonId]
        [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("userId")]
        public string? UserId { get; set; }
        public User? User { get; set; }
        [BsonElement("cpf")]
        public string? Cpf { get; set; }
        [BsonElement("phone")]
        public string? Phone { get; set; }
        [BsonElement("address")]
        public string? Address { get; set; }
        public Dictionary<string, string> AdditionAttributes { get; set; }
        public Client()
        {
            AdditionAttributes = new Dictionary<string, string>();
        }
    }
}
