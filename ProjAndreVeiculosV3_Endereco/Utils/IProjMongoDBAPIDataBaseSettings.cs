namespace ProjAndreVeiculosV3_Endereco.Utils
{
    public interface IProjMongoDBAPIDataBaseSettings
    {
        string EnderecoCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
