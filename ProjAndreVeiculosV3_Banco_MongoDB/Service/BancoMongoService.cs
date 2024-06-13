using Models;
using MongoDB.Driver;
using ProjAndreVeiculosV3_Banco_MongoDB.Utils;
using System.Net;

namespace ProjAndreVeiculosV3_Banco.Service
{
    public class BancoMongoService
    {
        private readonly IMongoCollection<Banco> _banco;

        public BancoMongoService(IBancoMongoSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _banco = database.GetCollection<Banco>(settings.BancoCollectionName);

        }

        public async Task<Banco> CreateAsync(Banco banco)
        {
            await _banco.InsertOneAsync(banco);
            return banco;
        }
    }
}
