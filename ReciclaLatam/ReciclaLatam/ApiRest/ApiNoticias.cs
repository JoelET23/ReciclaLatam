using Newtonsoft.Json;
using ReciclaLatam.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ReciclaLatam.ApiRest
{
    public class ApiNoticias
    {
        private const string url = "https://8u8crqacek.execute-api.us-east-1.amazonaws.com/items";
        private HttpClient _Client = new HttpClient();
        public async Task<NoticiasLista> WebApi()
        {
            var content = await _Client.GetStringAsync(url);
            var post_ = JsonConvert.DeserializeObject<NoticiasLista>(content);

            return post_;

        }
    }
}
