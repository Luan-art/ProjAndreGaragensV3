using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjAndreVeiculosV3_Banco_Consumer.Service
{
    public class BancoService
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public async Task<Banco> PostBanco(Banco bank)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(bank), Encoding.UTF8, "application/json");
                HttpResponseMessage respose = await BancoService._httpClient.PostAsync("https://localhost:7262/api/Bancos", content);
                respose.EnsureSuccessStatusCode();
                var contentM = new StringContent(JsonConvert.SerializeObject(bank), Encoding.UTF8, "application/json");
                HttpResponseMessage resposeM = await BancoService._httpClient.PostAsync("https://localhost:7134/api/Bancos", content);
                respose.EnsureSuccessStatusCode();
                string bankReturn = await respose.Content.ReadAsStringAsync();
                string bankMReturn = await respose.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<Banco>(bankReturn);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
