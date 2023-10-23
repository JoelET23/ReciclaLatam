using Newtonsoft.Json;
using Plugin.Geolocator;
using ReciclaLatam.ApiRest;
using ReciclaLatam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReciclaLatam.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CrearView : ContentPage
    {
        public double latitudMap;
        public double longuitudMap;
        public CrearView()
        {
            InitializeComponent();
        }
        private void LoginBack(object sender, EventArgs e)
        {
            Application.Current.MainPage = new LoginView();
        }
        
        private void LoginPass(object sender, EventArgs e)
        {

            Application.Current.MainPage = new LoginView();
        }

        private async void SaveLog(object sender, EventArgs e)
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 1000;

            var position = await locator.GetPositionAsync(TimeSpan.FromMilliseconds(1000));

            if (position == null)
            {
                return;
            }
            latitudMap = position.Latitude;
            longuitudMap = position.Longitude;

            ApiUsuario objApiUsuario = new ApiUsuario();
            Task<UsuarioLista> returnUsuarioLista = objApiUsuario.WebApi();
            UsuarioLista objUsuarioLista = await returnUsuarioLista;

            int iddim = 0;
            foreach (var userfr in objUsuarioLista.Items)
            {
                iddim++;
            }

            int idjson = iddim + 1;

            string NomInput = EntNom.Text;
            string CorInput = EntCor.Text;
            string PasInput = EntPas.Text;

            var UserUp = new UsuarioUpdate
            {
                latitud = latitudMap,
                geolocalizacion = null,
                apellidos = null,
                direccion = null,
                termycond = "Si",
                nombres = NomInput,
                correo = CorInput,
                id = idjson,
                password = PasInput,
                id_municipalidad = null,
                telefono = null,
                foto = "EditFoto.png",
                longitud = longuitudMap
            };
            var stringPayload = JsonConvert.SerializeObject(UserUp);

            var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");

            var httpClient = new HttpClient();
            var httpResponse = await httpClient.PutAsync("https://4f6xpxszn6.execute-api.us-east-1.amazonaws.com/items", httpContent);

            if (httpResponse.Content != null)
            {
                var responseContent = await httpResponse.Content.ReadAsStringAsync();
            }

            await DisplayAlert("Cuenta creada", "Inicie sesión por favor", "OK");

            Application.Current.MainPage = new LoginView();
        }
    }
}