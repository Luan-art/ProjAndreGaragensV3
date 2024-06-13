using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Banco
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)] 
        public string CNPJ { get; set; }
        public string NomeBanco { get; set; }
        public DateTime DataFundacao { get; set; }
    }
}