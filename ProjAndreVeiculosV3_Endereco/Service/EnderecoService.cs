using Models;
using MongoDB.Driver;
using ProjAndreVeiculosV3_Endereco.Utils;
using System.Net;

namespace ProjAndreVeiculosV3_Endereco.Service
{
    public class EnderecoService
    {
        private readonly IMongoCollection<Endereco> endereco;

        public EnderecoService(IProjMongoDBAPIDataBaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            endereco = database.GetCollection<Endereco>(settings.EnderecoCollectionName);

        }

        public List<Endereco> Get()
        {
            return endereco.Find(end => true).ToList();
        }

        public Endereco Get(string id) => endereco.Find<Endereco>(end => end.Id.ToString() == id).FirstOrDefault();

        public Endereco Create(Endereco endereco)
        {
            this.endereco.InsertOne(endereco);
            return endereco;
        }

        internal void GetMany(List<Endereco> enderecosSql)
        {
            this.endereco.InsertMany(enderecosSql);
        }
    }
}
