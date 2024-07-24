using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChistesPrueba.Services
{
    public class ChisteService
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public async Task<string> ObtenerChisteAsync()
        {
            var response = await _httpClient.GetStringAsync("https://api.chucknorris.io/jokes/random");
            var chisteJson = JObject.Parse(response);
            return chisteJson["value"].ToString();
        }
    }
}
