using Newtonsoft.Json;
using Plugin.Geolocator;
using ReciclaLatam.ApiRest;
using ReciclaLatam.Models;
using ReciclaLatam.ViewsModels;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;

namespace ReciclaLatam.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PuntosMapaView : ContentPage
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
        public string maparuta;
        public int zonaRuta;
        public string horazon;

        public double longmapfin;
        public double latimapfin;
        #endregion

        public double latitudMap;
        public double longuitudMap;
        public double latreal;
        public double lonreal;

        public int index = 0;

        public PuntosMapaView(string zonhor, int znrt, string maprt, double l, string g, string ap, string dir, string ter, string nom, int id, string cor, string pas, string idmu, string tel, string fot, double lon)
        {
            InitializeComponent();

            //ApplyMapTheme();

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
            maparuta = maprt;
            zonaRuta = znrt;
            horazon = zonhor;
            #endregion

            RutaVehiculo();
            getRecojosMapas();


            var positions = new Position(latitud, longitud);
            map.MoveToRegion(MapSpan.FromCenterAndRadius(positions, Distance.FromMeters(500)));

            Device.StartTimer(TimeSpan.FromSeconds(3), () =>
            {
                Task.Run(async () =>
                {

                    ApiRecicladorRecolector objApiRecolector = new ApiRecicladorRecolector();
                    Task<RecicladorRecoletorLista> returnRecolectorLista = objApiRecolector.WebApi();
                    RecicladorRecoletorLista objRecolectorLista = await returnRecolectorLista;

                    latreal = objRecolectorLista.Items.FirstOrDefault().latitud;
                    lonreal = objRecolectorLista.Items.FirstOrDefault().longitud;

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

                                
                                Pin VehiclePins = new Pin()
                                {
                                    Label = "Reciclador",
                                    Type = PinType.Place,
                                    Icon = (Device.RuntimePlatform == Device.Android) ? BitmapDescriptorFactory.FromBundle("conductor.png") : BitmapDescriptorFactory.FromView(new Image() { Source = "conductor.png" }),
                                    Position = new Position(latreal, lonreal),
                                };
                                if (index == 0)
                                {
                                    map.Pins.Add(VehiclePins);
                                }
                                else
                                {
                                    var cPin = map.Pins.FirstOrDefault();
                                    if (cPin != null)
                                    {
                                        cPin.Position = new Xamarin.Forms.GoogleMaps.Position(latreal, lonreal);
                                        cPin.Icon = (Device.RuntimePlatform == Device.Android) ? BitmapDescriptorFactory.FromBundle("conductor.png") : BitmapDescriptorFactory.FromView(new Image() { Source = "conductor.png"});
                                        //map.MoveToRegion(MapSpan.FromCenterAndRadius(cPin.Position, Distance.FromMeters(500)));
                                    }
                                }
                                index++;
                            };
                        }
                    }
                });
                return true;
            });
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
            //StartRutaVehiculo();
        }

        void RutaVehiculo()
        {
            var assembly = typeof(PuntosMapaView).GetTypeInfo().Assembly;
            var nombmapa = maparuta;
            var maparecorridon = $"ReciclaLatam.MapResources." + nombmapa;

            var stream = assembly.GetManifestResourceStream(maparecorridon);
            string trackPathFile;

            using (var reader = new System.IO.StreamReader(stream))
            {
                trackPathFile = reader.ReadToEnd();
            }

            var myJson = JsonConvert.DeserializeObject<List<Xamarin.Forms.GoogleMaps.Position>>(trackPathFile);

            map.Polylines.Clear();

            var polyline = new Xamarin.Forms.GoogleMaps.Polyline();
            polyline.StrokeColor = Color.Black;
            polyline.StrokeWidth = 5;

            foreach (var p in myJson)
            {
                polyline.Positions.Add(p);

            }
            map.Polylines.Add(polyline);

            latimapfin = polyline.Positions.LastOrDefault().Latitude;
            longmapfin  = polyline.Positions.LastOrDefault().Longitude;

            map.MoveToRegion(MapSpan.FromCenterAndRadius(new Xamarin.Forms.GoogleMaps.Position(polyline.Positions[0].Latitude, polyline.Positions[0].Longitude), Xamarin.Forms.GoogleMaps.Distance.FromMiles(0.30f)));

            var pin = new Xamarin.Forms.GoogleMaps.Pin
            {
                Type = PinType.SearchResult,
                Position = new Xamarin.Forms.GoogleMaps.Position(polyline.Positions.First().Latitude, polyline.Positions.First().Longitude),
                Label = "Inicio",
                Address = "Inicio",
                Tag = "Inicio",
                Icon = (Device.RuntimePlatform == Device.Android) ? BitmapDescriptorFactory.FromBundle("usuario.png") : BitmapDescriptorFactory.FromView(new Image() { Source = "usuario.png", WidthRequest = 25, HeightRequest = 25 })

            };
            map.Pins.Add(pin);

            var Endpin = new Xamarin.Forms.GoogleMaps.Pin
            {
                Type = PinType.SearchResult,
                Position = new Xamarin.Forms.GoogleMaps.Position(polyline.Positions.Last().Latitude, polyline.Positions.Last().Longitude),
                Label = "Fin",
                Address = "Fin",
                Tag = "Fin",
                Icon = (Device.RuntimePlatform == Device.Android) ? BitmapDescriptorFactory.FromBundle("conductor.png") : BitmapDescriptorFactory.FromView(new Image() { Source = "conductor.png", WidthRequest = 25, HeightRequest = 25 })

            };
            map.Pins.Add(Endpin);

            Pin VehiclePins = new Pin()
            {
                Label = "Mi ubicación",
                Type = PinType.Place,
                Icon = (Device.RuntimePlatform == Device.Android) ? BitmapDescriptorFactory.FromBundle("pinubicacion.png") : BitmapDescriptorFactory.FromView(new Image() { Source = "pinubicacion.png" }),
                Position = new Position(latitud, longitud),
                IsDraggable = true
            };
            map.Pins.Add(VehiclePins);

            var positionsUser = new Position(latitud, longitud);//Latitude, Longitude
            map.MoveToRegion(MapSpan.FromCenterAndRadius(positionsUser, Distance.FromMeters(1200)));

        }

        private async void getRecojosMapas()
        {
            ApiZonas objApiZonas = new ApiZonas();
            Task<ZonasLista> returnZonasLista = objApiZonas.WebApi();
            ZonasLista objZonasLista = await returnZonasLista;

            

            foreach (var zonalist in objZonasLista.Items)
            {
                if (zonalist.numzona == zonaRuta)
                {
                    var latlong = zonalist.latlong.Split('/');

                    var polygon1 = new Polygon();

                    foreach (var item in latlong)
                    {
                        var Mlatlong = item.Split(',');

                        polygon1.Positions.Add(new Position(double.Parse(Mlatlong[0], CultureInfo.InvariantCulture), double.Parse(Mlatlong[1], CultureInfo.InvariantCulture)));

                    }
                    polygon1.IsClickable = true;
                    polygon1.Tag = zonalist.numzona;
                    polygon1.StrokeWidth = 2f;
                    polygon1.StrokeColor = Color.FromHex("#" + zonalist.campoO);
                    polygon1.FillColor = Color.FromHex("#4D" + zonalist.campoO);
                    map.Polygons.Add(polygon1);
                }
            }

            // Fit to all shapes
            var bounds = Xamarin.Forms.GoogleMaps.Bounds.FromPositions(map.Polygons.SelectMany(poly => poly.Positions));
            map.InitialCameraUpdate = CameraUpdateFactory.NewBounds(bounds, 5);

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

        private void CloseFrm(object sender, EventArgs e)
        {
            FrameThn.IsVisible = false;
        }
    }
}