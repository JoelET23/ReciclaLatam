using Newtonsoft.Json;
using ReciclaLatam.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ReciclaLatam.ApiRest
{
    public class ApiRecicladorRecolector
    {
        private const string url = "https://fkfvijwa5l.execute-api.us-east-1.amazonaws.com/items";
        private HttpClient _Client = new HttpClient();
        public async Task<RecicladorRecoletorLista> WebApi()
        {
            var content = await _Client.GetStringAsync(url);
            var post_ = JsonConvert.DeserializeObject<RecicladorRecoletorLista>(content);

            return post_;
            //Post_List.ItemsSource = post_.Items; 
            //base.WebApi();
        }
    }
}
