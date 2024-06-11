namespace ProjAndreVeiculosV3_Endereco.Utils
{
    public class ProjMongoDBAPIDataBaseSettings : IProjMongoDBAPIDataBaseSettings
    {
        public string EnderecoCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
