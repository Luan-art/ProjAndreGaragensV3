namespace ProjAndreVeiculosV3_Banco.Utils
{
    public class BancoMongo : IBancoMongo
    {
        public string BancoCollectionName { get; set; }
        public string ConnectionString { get; set ; }
        public string DatabaseName { get; set ; }
    }
}
