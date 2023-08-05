using ReciclaLatam.Models;
using ReciclaLatam.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReciclaLatam.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InicioView : ContentPage
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
        public string maparuta;
        public double longitud;
        #endregion

        public InicioView(double l, string g, string ap, string dir, string ter, string nom, int id, string cor, string pas, string idmu, string tel, string fot, double lon)
        {
            InitializeComponent();
            BindingContext = new InicioVM();
            MenuInicioPage.SelectionChanged += MenuInicioChanged;

            LblNomInicio.Text = "Hola, " + nom;

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

        private void MenuInicioChanged(object sender, SelectionChangedEventArgs e)
        {
            var _ItemMenu = e.CurrentSelection;

            for(int i=0; i<_ItemMenu.Count; i++)
            {
                var _item = _ItemMenu[i] as MenuInicioModels;
                var NombreMenu = _item.Nombre;
                var IdMenuItem = _item.Id;
                //await Navigation.PushAsync(new ManualesView());
                if (IdMenuItem == 1)
                {
                    Application.Current.MainPage = new RecojoView(latitud, geolocalizacion, apellidos, direccion, termycond, nombres, usuario_id, correo, password, id_municipalidad, telefono, foto, longitud);
                }
                else if (NombreMenu == "Puntos")
                {
                    Application.Current.MainPage = new RutasView(latitud, geolocalizacion, apellidos, direccion, termycond, nombres, usuario_id, correo, password, id_municipalidad, telefono, foto, longitud);
                }
                else if (IdMenuItem == 3)
                {
                    Application.Current.MainPage = new ManualesView(latitud, geolocalizacion, apellidos, direccion, termycond, nombres, usuario_id, correo, password, id_municipalidad, telefono, foto, longitud);
                }
                else if (NombreMenu == "Noticias")
                {
                    Application.Current.MainPage = new NoticiasView(latitud, geolocalizacion, apellidos, direccion, termycond, nombres, usuario_id, correo, password, id_municipalidad, telefono, foto, longitud);
                }
                else if (NombreMenu == "Mi info")
                {
                    Application.Current.MainPage = new MiInfoView(latitud, geolocalizacion, apellidos, direccion, termycond, nombres, usuario_id, correo, password, id_municipalidad, telefono, foto, longitud);
                }
                else if (NombreMenu == "Nosotros")
                {
                    Application.Current.MainPage = new NosotrosView(latitud, geolocalizacion, apellidos, direccion, termycond, nombres, usuario_id, correo, password, id_municipalidad, telefono, foto, longitud);
                }
            }
        }

        private void ViewConfig(object sender, EventArgs e)
        {
            Application.Current.MainPage = new ConfiguracionView(latitud, geolocalizacion, apellidos, direccion, termycond, nombres, usuario_id, correo, password, id_municipalidad, telefono, foto, longitud);
        }

        private void RutaTap(object sender, EventArgs e)
        {
            Application.Current.MainPage = new PuntosMapaView(maparuta, latitud, geolocalizacion, apellidos, direccion, termycond, nombres, usuario_id, correo, password, id_municipalidad, telefono, foto, longitud);
        }
        private void LinkFace(object sender, EventArgs e)
        {
            var url = "https://www.facebook.com/ReciclaLatamPe";
            Launcher.OpenAsync(new Uri(url));
            //Device.OpenUri(new Uri(url));
        }
        private void LinkInst(object sender, EventArgs e)
        {
            var url = "https://www.instagram.com/reciclape_peru";
            Launcher.OpenAsync(new Uri(url));
            //Device.OpenUri(new Uri(url));
        }
        private void LinkYout(object sender, EventArgs e)
        {
            var url = "https://www.youtube.com/channel/UCOT0cMWji4dfSw5imh7vtkw";
            Launcher.OpenAsync(new Uri(url));
            //Device.OpenUri(new Uri(url));
        }
        private void LinkLink(object sender, EventArgs e)
        {
            var url = "https://www.linkedin.com/company/reciclalatam";
            Launcher.OpenAsync(new Uri(url));
            //Device.OpenUri(new Uri(url));
        }
    }
}