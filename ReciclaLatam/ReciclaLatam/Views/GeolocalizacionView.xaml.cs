using Newtonsoft.Json;
using ReciclaLatam.ApiRest;
using ReciclaLatam.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;
using Color = Xamarin.Forms.Color;
using Image = Xamarin.Forms.Image;
using Polygon = Xamarin.Forms.GoogleMaps.Polygon;

namespace ReciclaLatam.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GeolocalizacionView : ContentPage
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

        public double latitudMap;
        public double longuitudMap;
        public double latreal;
        public double lonreal;

        public int idrutazon;

        Button lastframe;
        Button lastrut;

        public double latsearch;
        public double lonsearch;

        public string idzonaclick;

        public int index = 0;

        ZonasLista objZonasLista1 = new ZonasLista();

        public GeolocalizacionView(double l, string g, string ap, string dir, string ter, string nom, int id, string cor, string pas, string idmu, string tel, string fot, double lon)
        {
            InitializeComponent();

            GetListZonas();

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

            ApplyMapTheme();
            getRecojosMapas();
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
            GetGelocalization();
        }

        private void GetGelocalization()
        {
           
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

        private async void TabZonaSel(object sender, EventArgs e)
        {

            if (lastframe == null)
                lastframe = sender as Button;
            else
            {
                lastframe.BorderWidth = 0;
                lastframe.Text = "";
                lastframe = sender as Button;
            }

            map.Polylines.Clear();

            var frame = sender as Button;
            var model = frame.BindingContext as ZonasModels;

            //frame.BackgroundColor = Color.Red;
            frame.BorderWidth = 3;
            frame.BorderColor = Color.FromHex("#3B5165");
            frame.Text = "x";
            frame.TextColor = Color.White;

            FechaZonaRt.Text = model.diarecojo;
            StackBlk.IsVisible = true;

            idrutazon = model.numzona;

            ApiRecojos objApiRecojos = new ApiRecojos();
            Task<RecojosLista> returnRecojosLista = objApiRecojos.WebApi();
            RecojosLista objRecojosLista = await returnRecojosLista;

            var forlustrut = objRecojosLista.Items.OrderBy(x => x.hora_inicio).ToList();

            var ListRutCl = new ObservableCollection<RecojosModels>();
            foreach (var item in forlustrut)
            {
                if(item.id_usuario == idrutazon)
                {
                    ListRutCl.Add(item);
                }
            }
            RutasPage.ItemsSource = ListRutCl;

            //idzonaclick = model.diarecojo;
            //DisplayAlert("Fecha Recojo", idzonaclick, "OK");

        }
       
        private void map_PinDragStart(object sender, PinDragEventArgs e)
        {

        }

        private void map_PinDragEnd(object sender, PinDragEventArgs e)
        {
            var positions = new Position(e.Pin.Position.Latitude, e.Pin.Position.Longitude);//Latitude, Longitude
            map.MoveToRegion(MapSpan.FromCenterAndRadius(positions, Distance.FromMeters(1200)));

            latsearch = e.Pin.Position.Latitude;
            lonsearch = e.Pin.Position.Longitude;

            //AreaWithin(positions);

            //await App.Current.MainPage.DisplayAlert("Alert", "Pick up location : Latitude :" + e.Pin.Position.Latitude + " Longitude :" + e.Pin.Position.Longitude, "Ok");
            //await App.Current.GeolocalizacionView.DisplayAlert("Alert", "Pick up location : Latitude :" + e.Pin.Position.Latitude + " Longitude :" + e.Pin.Position.Longitude, "Ok");
        }

        private async void SaveUbicacion(object sender, EventArgs e)
        {
            ApiUsuario objApiUsuario = new ApiUsuario();
            Task<UsuarioLista> returnUsuarioLista = objApiUsuario.WebApi();
            UsuarioLista objUsuarioLista = await returnUsuarioLista;

            if (latsearch == 0) 
            {
                latsearch = latitud;
                lonsearch = longitud;
            }

            var UserUp = new UsuarioUpdate
            {
                latitud = latsearch,
                geolocalizacion = idrutazon.ToString(),
                apellidos = apellidos,
                direccion = direccion,
                termycond = "Si",
                nombres = nombres,
                correo = correo,
                id = usuario_id,
                password = password,
                id_municipalidad = null,
                telefono = null,
                foto = "EditFoto.png",
                longitud = lonsearch
            };

            latitud = latsearch;
            longitud = lonsearch;
            geolocalizacion = idrutazon.ToString();

            var stringPayload = JsonConvert.SerializeObject(UserUp);

            var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");

            var httpClient = new HttpClient();
            var httpResponse = await httpClient.PutAsync("https://4f6xpxszn6.execute-api.us-east-1.amazonaws.com/items", httpContent);

            if (httpResponse.Content != null)
            {
                var responseContent = await httpResponse.Content.ReadAsStringAsync();
            }
            await DisplayAlert("Registro de ubicación", "Zona y ruta asignada", "OK");
        }

        private void CancelUbic(object sender, EventArgs e) {
            Application.Current.MainPage = new InicioView(latitud, geolocalizacion, apellidos, direccion, termycond, nombres, usuario_id, correo, password, id_municipalidad, telefono, foto, longitud);
        }

        private async void getRecojosMapas()
        {
            ApiZonas objApiZonas = new ApiZonas();
            Task<ZonasLista> returnZonasLista = objApiZonas.WebApi();
            ZonasLista objZonasLista = await returnZonasLista;

            foreach (var zonalist in objZonasLista.Items)
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
                polygon1.Clicked += Polygon1_Clicked;
                polygon1.StrokeWidth = 2f;
                polygon1.StrokeColor = Color.FromHex("#"+zonalist.campoO);
                polygon1.FillColor = Color.FromHex("#4D"+zonalist.campoO);
                map.Polygons.Add(polygon1);
            }

            // Fit to all shapes
            var bounds = Xamarin.Forms.GoogleMaps.Bounds.FromPositions(map.Polygons.SelectMany(poly => poly.Positions));
            map.InitialCameraUpdate = CameraUpdateFactory.NewBounds(bounds, 5);

        }

        private void Polygon1_Clicked(object sender, EventArgs e)
        {
            var polygon = (Polygon)sender;
            string tag = polygon.Tag.ToString();

            //RecojosPage.FindByName(tag);

            //var pp = lastframe.Parent;

            CollectionView cview1 = this.FindByName<CollectionView>("RecojosPage");
            var cview = this.FindByName("RecojosPage");
            var stk0 = this.FindByName<StackLayout>("btnsonzn");


            //foreach (var item in RecojosPage.GetChildElements())
            //{

            //}
            //button.cli
            //DisplayAlert("Polygon", tag, "Close");

            //DisplayAlert("Ubicación", "Ubicación registrada", "OK");
        }

        private async void GetListZonas()
        {
            ApiZonas objApiZonas = new ApiZonas();
            Task<ZonasLista> returnZonasLista = objApiZonas.WebApi();
            ZonasLista objZonasLista = await returnZonasLista;

            RecojosPage.ItemsSource = objZonasLista.Items.OrderBy(x => x.zona_id).ToList();
        }

        /*
         * public bool AreaWithin(Position selectedPosition)
        {
            bool c = false;
            int i = 0;
            int j = AvailableRegions.Count - 1;
            foreach (var point in AvailableRegions)
            {
                double lat_i = point.Latitude;
                double lon_i = point.Longitude;

                double lat_j = AvailableRegions[j].Latitude;
                double lon_j = AvailableRegions[j].Longitude;

                if (((lat_i > selectedPosition.Latitude != (lat_j > selectedPosition.Latitude)) &&
                        (selectedPosition.Longitude < (lon_j - lon_i) * (selectedPosition.Latitude - lat_i) / (lat_j - lat_i) + lon_i)))
                    c = !c;
                j = i++;
            }
            return c;
        }
         */

        public bool AreaWithin(Position selectedPosition)
        {

            bool c = false;
            foreach (var item in objZonasLista1.Items)
            {
                int i = 0;
             
                var listPoints = item.latlong.Split('/');
                int j = listPoints.Length - 1;

                foreach (var point in listPoints)
                    {

                    var iniLatlong = point.Split(',');

                    double lat_i = double.Parse(iniLatlong[0], CultureInfo.InvariantCulture);
                    double lon_i = double.Parse(iniLatlong[1], CultureInfo.InvariantCulture);

                    var finLatlong = listPoints[j].ToString().Split(',');

                    double lat_j = double.Parse(finLatlong[0], CultureInfo.InvariantCulture);
                    double lon_j = double.Parse(finLatlong[1], CultureInfo.InvariantCulture);

                    if (((lat_i > selectedPosition.Latitude != (lat_j > selectedPosition.Latitude)) &&
                                (selectedPosition.Longitude < (lon_j - lon_i) * (selectedPosition.Latitude - lat_i) / (lat_j - lat_i) + lon_i)))
                    {
                        DisplayAlert("Hola", "estas en la zona: " + item.zona_id.ToString(), "Close");
                        c = !c;
                        break;
                    }
                    j = i++;
                    }
                   
            }
            return c;
        }

        private void TabRutaSel(object sender, EventArgs e)
        {

            if (lastrut == null)
                lastrut = sender as Button;
            else
            {
                lastrut.BackgroundColor = Color.FromHex("#E5F2F7");
                lastrut.TextColor = Color.FromHex("#25333F");
                lastrut.ImageSource = "RecojoHora.png";
                lastrut = sender as Button;
            }


            var frameRut = sender as Button;
            var modelRut = frameRut.BindingContext as RecojosModels;

            frameRut.BackgroundColor = Color.FromHex("#25333F");
            frameRut.TextColor = Color.FromHex("#FFFFFF");
            frameRut.ImageSource = "RecojoHoraact.png";



            var assembly = typeof(GeolocalizacionView).GetTypeInfo().Assembly;
            var nombmapa = modelRut.hora_fin;
            var maparecorridon = $"ReciclaLatam.MapResources."+nombmapa;

            //var maparecorridon = $"ReciclaLatam.MapResources.Martes1715R10.json";
            
            var stream = assembly.GetManifestResourceStream(maparecorridon);
            string trackPathFile;

            using (var reader = new System.IO.StreamReader(stream))
            {
                trackPathFile = reader.ReadToEnd();
            }

            var myJson = JsonConvert.DeserializeObject<List<Xamarin.Forms.GoogleMaps.Position>>(trackPathFile);

            map.Polylines.Clear();

            var polyline = new Xamarin.Forms.GoogleMaps.Polyline();
            polyline.StrokeColor = Color.FromHex("#494949");
            polyline.StrokeWidth = 2;

            foreach (var p in myJson)
            {
                polyline.Positions.Add(p);

            }
            map.Polylines.Add(polyline);



            //DisplayAlert("JSON Ruta", modelRut.hora_fin.ToString(), "OK");
        }
    }
}