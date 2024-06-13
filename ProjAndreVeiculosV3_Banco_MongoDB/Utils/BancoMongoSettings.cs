namespace ProjAndreVeiculosV3_Banco_MongoDB.Utils
{
    public class BancoMongoSettings : IBancoMongoSettings
    {
        public string BancoCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
