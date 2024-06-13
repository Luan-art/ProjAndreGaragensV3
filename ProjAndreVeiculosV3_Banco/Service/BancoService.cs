using Models;
using MongoDB.Driver;
using ProjAndreVeiculosV3_Banco.Utils;
using System.Net;

namespace ProjAndreVeiculosV3_Banco.Service
{
    public class BancoService
    {
        private readonly IMongoCollection<Banco> _banco;

        public BancoService(IBancoMongo settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _banco = database.GetCollection<Banco>(settings.BancoCollectionName);

        }

        public List<Banco> Get()
        {
            return _banco.Find(banco => true).ToList();
        }

        public Banco Get(string id) => _banco.Find<Banco>(banco => banco.CNPJ == id).FirstOrDefault();

        public Banco Create(Banco banco)
        {
            _banco.InsertOne(banco);
            return banco;
        }
    }
}
