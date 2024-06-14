namespace ProjAndreVeiculosV3_TermoUso.Utils
{
    public class TermoUsoMongo : ITermoUsoMongo
    {
        public string TermoUsoCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
