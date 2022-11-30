using ReciclaLatam.ApiRest;
using ReciclaLatam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReciclaLatam.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecojoView : ContentPage
    {
        public string latitud;
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
        public string longitud;
        public RecojoView(string l, string g, string ap, string dir, string ter, string nom, int id, string cor, string pas, string idmu, string tel, string fot, string lon)
        {
            InitializeComponent();
            getRecojos();
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
        }

        private async void getRecojos()
        {
            ApiRecojos objApiRecojos = new ApiRecojos();
            Task<RecojosLista> returnRecojosLista = objApiRecojos.WebApi();
            RecojosLista objRecojosLista = await returnRecojosLista;

            RecojosPage.ItemsSource = objRecojosLista.Items;

        }



        private void ConfiguracionTap(object sender, EventArgs e)
        {
            Application.Current.MainPage = new ConfiguracionView(latitud, geolocalizacion, apellidos, direccion, termycond, nombres, usuario_id, correo, password, id_municipalidad, telefono, foto, longitud);
        }

        private void TuReciView(object sender, EventArgs e)
        {
            Application.Current.MainPage = new TuRecicladorView(latitud, geolocalizacion, apellidos, direccion, termycond, nombres, usuario_id, correo, password, id_municipalidad, telefono, foto, longitud);
        }
        private void MenHom(object sender, EventArgs e)
        {
            Application.Current.MainPage = new InicioView(latitud, geolocalizacion, apellidos, direccion, termycond, nombres, usuario_id, correo, password, id_municipalidad, telefono, foto, longitud);
        }
        private void MenReco(object sender, EventArgs e)
        {
            Application.Current.MainPage = new RecojoView(latitud, geolocalizacion, apellidos, direccion, termycond, nombres, usuario_id, correo, password, id_municipalidad, telefono, foto, longitud);
        }
        private void MenPun(object sender, EventArgs e)
        {
            Application.Current.MainPage = new PuntosMapaView(latitud, geolocalizacion, apellidos, direccion, termycond, nombres, usuario_id, correo, password, id_municipalidad, telefono, foto, longitud);
        }
        private void MenMan(object sender, EventArgs e)
        {
            Application.Current.MainPage = new ManualesView(latitud, geolocalizacion, apellidos, direccion, termycond, nombres, usuario_id, correo, password, id_municipalidad, telefono, foto, longitud);
        }
        private void MenNot(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NoticiasView(latitud, geolocalizacion, apellidos, direccion, termycond, nombres, usuario_id, correo, password, id_municipalidad, telefono, foto, longitud);
        }
    }
}