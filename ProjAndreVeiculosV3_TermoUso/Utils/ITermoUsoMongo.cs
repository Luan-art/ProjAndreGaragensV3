namespace ProjAndreVeiculosV3_TermoUso.Utils
{
    public interface ITermoUsoMongo
    {
        string TermoUsoCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
