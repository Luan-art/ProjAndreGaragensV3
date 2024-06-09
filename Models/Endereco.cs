using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Models
{
    public class Endereco
    {
        public int Id { get; set; }

        [JsonPropertyName("logradouro")]
        public string Logradouro { get; set; }

        [JsonPropertyName("cep")]
        public string CEP { get; set; }

        [JsonPropertyName("bairro")]
        public string Bairro { get; set; }

        [JsonPropertyName("complemento")]
        public string? Complemento { get; set; }

        [JsonPropertyName("localidade")]
        public string Localidade { get; set; }

        [JsonPropertyName("uf")]
        public string UF { get; set; }

        public Endereco() { }
        public Endereco(HttpClient httpClient, string url)
        {
            HttpResponseMessage resposta = httpClient.GetAsync(url).Result;

            if (resposta.IsSuccessStatusCode)
            {
                var json = resposta.Content.ReadAsStringAsync().Result;
                var enderecoViaCep = JsonConvert.DeserializeObject<Endereco>(json);
                if (enderecoViaCep == null || enderecoViaCep.CEP == null)
                {
                    throw new Exception("Endereço ou CEP nullo");
                }
                else
                {
                    this.CEP = enderecoViaCep.CEP;
                    this.Logradouro = enderecoViaCep.Logradouro;
                    this.Bairro = enderecoViaCep.Bairro;
                    this.Localidade = enderecoViaCep.Localidade;
                    this.UF = enderecoViaCep.UF;
                }
            }
        }
    }
}
