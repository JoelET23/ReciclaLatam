using Newtonsoft.Json;
using ReciclaLatam.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ReciclaLatam.ApiRest
{
    public class ApiGuias
    {
        private const string url = "https://45e16kkxva.execute-api.us-east-1.amazonaws.com/items";
        private HttpClient _Client = new HttpClient();
        public async Task<GuiasLista> WebApi()
        {
            var content = await _Client.GetStringAsync(url);
            var post_ = JsonConvert.DeserializeObject<GuiasLista>(content);

            return post_;
            //Post_List.ItemsSource = post_.Items; 
            //base.WebApi();
        }
    }
}
