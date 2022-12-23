using Plugin.Geolocator;
using ReciclaLatam.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;

namespace ReciclaLatam.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GeolocalizacionView : ContentPage
    {
        PuntosMapaVM PuntosMapaVM_;

        #region Variables
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
        #endregion

        public double latitudMap;
        public double longuitudMap;

        public GeolocalizacionView(string l, string g, string ap, string dir, string ter, string nom, int id, string cor, string pas, string idmu, string tel, string fot, string lon)
        {
            InitializeComponent();

            BindingContext = PuntosMapaVM_ = new PuntosMapaVM();

            //UbicacionReal();
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

        /*private async void UbicacionReal()
        {
            
        }*/

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

        private async void GetRutas()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;
            if (locator.IsGeolocationAvailable)
            {
                if (locator.IsGeolocationEnabled)
                {
                    if (!locator.IsListening)
                    {
                        await locator.StartListeningAsync(TimeSpan.FromSeconds(1), 5);
                    }
                    locator.PositionChanged += (cambio, args) =>
                    {
                        var loc = args.Position;

                        /*LonMp.Text = loc.Longitude.ToString();
                        latitudMap = double.Parse(LonMp.Text);*/
                        latitudMap = loc.Latitude;

                        /*LatMp.Text = loc.Latitude.ToString();
                        longuitudMap = double.Parse(LatMp.Text);*/
                        longuitudMap = loc.Longitude;


                        Pin VehiclePins = new Pin()
                        {
                            Label = "Mi ubicación",
                            Type = PinType.Place,
                            Icon = (Device.RuntimePlatform == Device.Android) ? BitmapDescriptorFactory.FromBundle("PickupPin.png") : BitmapDescriptorFactory.FromView(new Image() { Source = "PickupPin.png", WidthRequest = 60, HeightRequest = 60 }),
                            Position = new Position(latitudMap, longuitudMap),
                        };
                        map.Pins.Add(VehiclePins);

                        //This is your location and it should be near to your car location.
                        var positions = new Position(latitudMap, longuitudMap);//Latitude, Longitude
                        map.MoveToRegion(MapSpan.FromCenterAndRadius(positions, Distance.FromMeters(500)));

                    };
                }
            }
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