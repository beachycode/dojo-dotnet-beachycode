using MongoDB.Bson.Serialization.Attributes;

namespace DojoDaGalera.Classes
{
    public class Dojo
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("titulo")]
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string Titulo { get; set; }

        [BsonElement("descricao")]
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string Descricao { get; set; }
    }
}

/*
[BsonId]
[BsonRepresentation]
[BsonElement]
 */