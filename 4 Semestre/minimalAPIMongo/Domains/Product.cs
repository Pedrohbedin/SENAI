﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace minimalAPIMongo.Domains
{
    public class Product
    {
        [BsonId]
        [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("name")]
        public string? Name { get; set; }
        [BsonElement("price")]
        public decimal? Price { get; set; }
        public Dictionary<string, string> AdditionAttributes { get; set; }
        public Product()
        {
            AdditionAttributes = new Dictionary<string, string>();
        }
    }
}
