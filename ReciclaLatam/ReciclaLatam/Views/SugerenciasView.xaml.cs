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
    public partial class SugerenciasView : ContentPage
    {
        #region Variables
        public double latitud;
        public string geolocalizacion;
        public string apellidos;
        public string direccion;
        public string termycond;
        public string nombres;
        public int usuario_id;
        public string correo;
        public string password;
        public string id_municipalidad;
        public string telefono;
        public string foto;
        public double longitud;
        #endregion
        public SugerenciasView(double l, string g, string ap, string dir, string ter, string nom, int id, string cor, string pas, string idmu, string tel, string fot, double lon)
        {
            InitializeComponent();

            #region Variables2
            latitud = l;
            geolocalizacion = g;
            apellidos = ap;
            direccion = dir;
            termycond = ter;
            nombres = nom;
            usuario_id = id;
            correo = cor;
            password = pas;
            id_municipalidad = idmu;
            telefono = tel;
            foto = fot;
            longitud = lon;
            #endregion
        }

        private void InicioBack(object sender, EventArgs e)
        {
            Application.Current.MainPage = new InicioView(latitud, geolocalizacion, apellidos, direccion, termycond, nombres, usuario_id, correo, password, id_municipalidad, telefono, foto, longitud);
        }

        private async void SaveSuger(object sender, EventArgs e)
        {
            ApiSugerencias objApiSugerencias = new ApiSugerencias();
            Task<SugerenciasLista> returnSugerenciasLista = objApiSugerencias.WebApi();
            SugerenciasLista objSugerenciasLista = await returnSugerenciasLista;

            int iddim = 0;
            foreach (var userfr in objSugerenciasLista.Items)
            {
                iddim++;
            }

            int idjson = iddim + 1;

            string Asunnput = EntTit.Text;
            string MenInput = EntMen.Text;

            var SugerAdd = new SugerenciasModels
            {
                titulo_sugerencia = Asunnput,
                resume_sugerencia = MenInput,
                usuario_sugerencia = nombres,
                id = idjson,
            };
            var stringPayload = JsonConvert.SerializeObject(SugerAdd);

            var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");

            var httpClient = new HttpClient();
            var httpResponse = await httpClient.PutAsync("https://csgpa5g22h.execute-api.us-east-1.amazonaws.com/items", httpContent);

            if (httpResponse.Content != null)
            {
                var responseContent = await httpResponse.Content.ReadAsStringAsync();
            }

            await DisplayAlert("Sugerencia", "Se envió correctamente su sugerencia", "OK");

            Application.Current.MainPage = new InicioView(latitud, geolocalizacion, apellidos, direccion, termycond, nombres, usuario_id, correo, password, id_municipalidad, telefono, foto, longitud);
        }

        private void CancelarSuger(object sender, EventArgs e)
        {
            Application.Current.MainPage = new InicioView(latitud, geolocalizacion, apellidos, direccion, termycond, nombres, usuario_id, correo, password, id_municipalidad, telefono, foto, longitud);
        }
    }
}