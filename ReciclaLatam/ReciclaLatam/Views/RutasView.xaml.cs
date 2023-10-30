using Plugin.Geolocator;
using ReciclaLatam.ApiRest;
using ReciclaLatam.Models;
using ReciclaLatam.ViewsModels;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Shapes;
using Xamarin.Forms.Xaml;

namespace ReciclaLatam.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RutasView : ContentPage
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
        public double latitudMap;
        public double longuitudMap;
        #endregion

        public RutasView(double l, string g, string ap, string dir, string ter, string nom, int id, string cor, string pas, string idmu, string tel, string fot, double lon)
        {
            InitializeComponent();

            ApplyMapTheme();

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

        private void ApplyMapTheme()
        {
            var assembly = typeof(MainPage).GetTypeInfo().Assembly;
            /*var stream = assembly.GetManifestResourceStream($"ReciclaLatam.MapResources.MapTheme.json");
            string themeFile;
            using (var reader = new System.IO.StreamReader(stream))
            {
                themeFile = reader.ReadToEnd();
                map.MapStyle = MapStyle.FromJson(themeFile);
                map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(28.12267, 82.29483), Distance.FromMeters(1000)), false);

            }*/

            GetRutas();

        }

        async void GetRutas()
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

            var positions = new Position(-12.12348, -77.03543);//Latitude, Longitude
            map.MoveToRegion(MapSpan.FromCenterAndRadius(positions, Distance.FromMeters(800)));
            //var positionsUser = new Position(latitudMap, longuitudMap);//Latitude, Longitude
            //map.MoveToRegion(MapSpan.FromCenterAndRadius(positionsUser, Distance.FromMeters(800)));

            ApiPuntos objApiPuntos = new ApiPuntos();
            Task<PuntosLista> returnPuntosLista = objApiPuntos.WebApi();
            PuntosLista objPuntosLista = await returnPuntosLista;

            foreach (var item in objPuntosLista.Items)
            {
                Pin VehiclePinsUser = new Pin()
                {
                    Label = item.Leyenda,
                    Type = PinType.Place,
                    Address = item.CampoO,
                    Icon = (Device.RuntimePlatform == Device.Android) ? BitmapDescriptorFactory.FromBundle("ruta.png") : BitmapDescriptorFactory.FromView(new Image() { Source = "ruta.png" }),
                    Position = new Position(item.Latitud, item.Longitud),
                    Tag = item.CampoO
                };
                map.Pins.Add(VehiclePinsUser);
            }
            map.PinClicked += Map_PinClicked;

            Pin VehiclePinsUserAct = new Pin()
            {
                Label = "Mi ubicación",
                Type = PinType.Place,
                Icon = (Device.RuntimePlatform == Device.Android) ? BitmapDescriptorFactory.FromBundle("usuario.png") : BitmapDescriptorFactory.FromView(new Image() { Source = "usuario.png" }),
                Position = new Position(latitudMap, longuitudMap),
            };
            map.Pins.Add(VehiclePinsUserAct); 
        }

   

        private void Map_PinClicked(object sender, PinClickedEventArgs e)
        {
            var p = e.Pin;
            string tag = p.Tag.ToString();

            Navigation.PushPopupAsync(new Popup.PopupMapa(tag));

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
    }
}