using Models;
using MongoDB.Driver;
using ProjAndreVeiculosV3_TermoUso.Utils;

namespace ProjAndreVeiculosV3_TermoUso.Service
{
    public class TermoUsoService
    {
        private readonly IMongoCollection<TermoDeUso> _banco;

        public TermoUsoService(ITermoUsoMongo settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _banco = database.GetCollection<TermoDeUso>(settings.TermoUsoCollectionName);

        }

        public List<TermoDeUso> Get()
        {
            return _banco.Find(TermoDeUso => true).ToList();
        }

        public TermoDeUso Get(string id) => _banco.Find<TermoDeUso>(banco => banco.Id == id).FirstOrDefault();

        public TermoDeUso Create(TermoDeUso tU)
        {
            _banco.InsertOne(tU);
            return tU;
        }
    }
}
