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
    public partial class RutasView : ContentPage
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

        public RutasView(string l, string g, string ap, string dir, string ter, string nom, int id, string cor, string pas, string idmu, string tel, string fot, string lon)
        {
            InitializeComponent();

            BindingContext = PuntosMapaVM_ = new PuntosMapaVM();

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

        void GetRutas()
        {
            var contents = PuntosMapaVM_.LoadVehicles();

            if (contents != null)
            {
                foreach (var item in contents)
                {
                    Pin VehiclePins = new Pin()
                    {
                        Label = item.Reciclador,
                        Type = PinType.Place,
                        Icon = (Device.RuntimePlatform == Device.Android) ? BitmapDescriptorFactory.FromBundle("PickupPin.png") : BitmapDescriptorFactory.FromView(new Image() { Source = "PickupPin.png", WidthRequest = 60, HeightRequest = 60 }),
                        Position = new Position(Convert.ToDouble(item.Latitude), Convert.ToDouble(item.Longitude)),
                    };
                    map.Pins.Add(VehiclePins);
                }
            }

            //This is your location and it should be near to your car location.
            var positions = new Position(-12.121854, -77.030698);//Latitude, Longitude
            map.MoveToRegion(MapSpan.FromCenterAndRadius(positions, Distance.FromMeters(500)));
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