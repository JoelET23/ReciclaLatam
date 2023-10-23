using ReciclaLatam.ApiRest;
using ReciclaLatam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using static Xamarin.Essentials.Permissions;

namespace ReciclaLatam.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecojoView : ContentPage
    {
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

        public string maparuta;


        public RecojoView(double l, string g, string ap, string dir, string ter, string nom, int id, string cor, string pas, string idmu, string tel, string fot, double lon)
        {
            InitializeComponent();
            
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

            getRecojos();


        }

        private async void getRecojos()
        {
            //int IdZonQu = Int32.Parse(geolocalizacion);
            int IdZonQu = Convert.ToInt32(geolocalizacion);
            //int IdZonQu = int.Parse(geolocalizacion);
            


            ApiRecojos objApiRecojos = new ApiRecojos();
            Task<RecojosLista> returnRecojosLista = objApiRecojos.WebApi();
            RecojosLista objRecojosLista = await returnRecojosLista;

            //RecojosPage.ItemsSource = objRecojosLista.Items.OrderByDescending(x => x.recoleccion_id);
            //RecojosPage.ItemsSource = objRecojosLista.Items.OrderBy(x => x.recoleccion_id).ToList();

            var forlustrut = objRecojosLista.Items.OrderBy(x => x.recoleccion_id).ToList();

            var ListRutCl = new ObservableCollection<RecojosModels>();
            foreach (var item in forlustrut)
            {
                if (item.id_municipalidad == IdZonQu)
                {
                    ListRutCl.Add(item);
                }
            }
            RecojosPage.ItemsSource = ListRutCl;
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
            Application.Current.MainPage = new RutasView(latitud, geolocalizacion, apellidos, direccion, termycond, nombres, usuario_id, correo, password, id_municipalidad, telefono, foto, longitud);
        }
        private void MenMan(object sender, EventArgs e)
        {
            Application.Current.MainPage = new ManualesView(latitud, geolocalizacion, apellidos, direccion, termycond, nombres, usuario_id, correo, password, id_municipalidad, telefono, foto, longitud);
        }
        private void MenNot(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NoticiasView(latitud, geolocalizacion, apellidos, direccion, termycond, nombres, usuario_id, correo, password, id_municipalidad, telefono, foto, longitud);
        }

        private void RutaTap(object sender, EventArgs e)
        {
            var frame = sender as Frame;
            var model = frame.BindingContext as RecojosModels;

            maparuta = model.hora_fin;

            Application.Current.MainPage = new PuntosMapaView(maparuta, latitud, geolocalizacion, apellidos, direccion, termycond, nombres, usuario_id, correo, password, id_municipalidad, telefono, foto, longitud);
        }
    }
}