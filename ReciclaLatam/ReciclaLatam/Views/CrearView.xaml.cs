using Newtonsoft.Json;
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
                latitud = null,
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
                foto = "EditFoto.png"
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