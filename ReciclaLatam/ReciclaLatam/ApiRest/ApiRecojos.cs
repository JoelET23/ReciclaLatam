using Newtonsoft.Json;
using ReciclaLatam.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ReciclaLatam.ApiRest
{
    public class ApiRecojos
    {
        private const string url = "https://k4stsvtf8h.execute-api.us-east-1.amazonaws.com/items";
        private HttpClient _Client = new HttpClient();
        public async Task<RecojosLista> WebApi()
        {
            var content = await _Client.GetStringAsync(url);
            var post_ = JsonConvert.DeserializeObject<RecojosLista>(content);

            return post_;

        }
    }
}
