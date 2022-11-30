using Newtonsoft.Json;
using ReciclaLatam.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ReciclaLatam.ApiRest
{
    public class ApiUsuario
    {
        private const string url = "https://4f6xpxszn6.execute-api.us-east-1.amazonaws.com/items";
        private HttpClient _Client = new HttpClient();
        public async Task<UsuarioLista> WebApi()
        {
            var content = await _Client.GetStringAsync(url);
            var post_ = JsonConvert.DeserializeObject<UsuarioLista>(content);

            return post_;

        }
    }
}
