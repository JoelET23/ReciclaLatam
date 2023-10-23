using Newtonsoft.Json;
using ReciclaLatam.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ReciclaLatam.ApiRest
{
    public class ApiZonas
    {
        private const string url = "https://nl7987o5m1.execute-api.us-east-1.amazonaws.com/items";
        private HttpClient _Client = new HttpClient();
        public async Task<ZonasLista> WebApi()
        {
            var content = await _Client.GetStringAsync(url);
            var post_ = JsonConvert.DeserializeObject<ZonasLista>(content);

            return post_;

        }
    }
}
