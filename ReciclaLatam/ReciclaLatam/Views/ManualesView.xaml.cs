using ReciclaLatam.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReciclaLatam.ApiRest;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ReciclaLatam.Models;
using Xamarin.Essentials;
using System.Windows.Input;

namespace ReciclaLatam.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ManualesView : ContentPage
    {
        public ICommand DonwnloadPdf => new Command<string>(async (url) => await Launcher.OpenAsync(url));

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

        public ManualesView(double l, string g, string ap, string dir, string ter, string nom, int id, string cor, string pas, string idmu, string tel, string fot, double lon)
        {
            InitializeComponent();
            //BindingContext = new ManualVM();
            getGuias();
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

            ManualPage.SelectionChanged += ManualPageChanged;
        }

        private async void getGuias()
        {
            ApiGuias objApiGuias = new ApiGuias();
            Task<GuiasLista> returnGuiasLista = objApiGuias.WebApi();
            GuiasLista objGuiasLista = await returnGuiasLista;

            ManualPage.ItemsSource = objGuiasLista.Items;
        }

        private void ConfiguracionTap(object sender, EventArgs e)
        {
            Application.Current.MainPage = new ConfiguracionView(latitud, geolocalizacion, apellidos, direccion, termycond, nombres, usuario_id, correo, password, id_municipalidad, telefono, foto, longitud);
        }

        /*private void DonwnloadPdf(object sender, EventArgs e)
        {
            var url = LnkLblT;
            //var url = "https://alavista.tech/vibe/pdf/Brochure_VIBE.pdf";
            Launcher.OpenAsync(new Uri(url));
            //Device.OpenUri(new Uri(url));
        }*/
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

        private void ManualPageChanged(object sender, SelectionChangedEventArgs e)
        {
            var _ItemMenu = e.CurrentSelection;

            for (int i = 0; i < _ItemMenu.Count; i++)
            {
                var _item = _ItemMenu[i] as GuiaModels;
                var RutaItem = _item.ruta;
                var IdManualItem = _item.guias_id;
                if (IdManualItem == 1)
                {
                    var url1 = RutaItem;
                    Launcher.OpenAsync(new Uri(url1));
                }
                else if (IdManualItem == 2)
                {
                    var url2 = RutaItem;
                    Launcher.OpenAsync(new Uri(url2));
                }
                else if (IdManualItem == 3)
                {
                    var url3 = RutaItem;
                    Launcher.OpenAsync(new Uri(url3));
                }
                else if (IdManualItem == 4)
                {
                    var url4 = RutaItem;
                    Launcher.OpenAsync(new Uri(url4));
                }
            }
        }
    }
}