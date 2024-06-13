namespace ProjAndreVeiculosV3_Banco.Utils
{
    public interface IBancoMongo
    {
        string BancoCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
