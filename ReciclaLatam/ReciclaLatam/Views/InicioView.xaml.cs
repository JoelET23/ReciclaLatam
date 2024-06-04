using ReciclaLatam.ApiRest;
using ReciclaLatam.Models;
using ReciclaLatam.ViewsModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
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
        public int zonaRuta;
        public string horazon;
        #endregion

        RecojosModels recojosModelsEnt;

        DateTime fechaActual = DateTime.Now;
        DateTime horaactual = DateTime.Now;

        public InicioView(double l, string g, string ap, string dir, string ter, string nom, int id, string cor, string pas, string idmu, string tel, string fot, double lon)
        {
            InitializeComponent();
            BindingContext = new InicioVM();
            MenuInicioPage.SelectionChanged += MenuInicioChanged;

            getRecojos();

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

        private async void getRecojos()
        {
            int dia1 = (int)fechaActual.DayOfWeek;
            string horax = horaactual.ToString("HH:mm");

            //int dia1 = 4;
            //string horax = "10:50";

            DateTime hora2 = DateTime.ParseExact(horax, "HH:mm",
                CultureInfo.InvariantCulture);

            recojosModelsEnt = new RecojosModels();

            ApiRecojos objApiRecojos = new ApiRecojos();
            var list = await Task.Run(() => objApiRecojos.WebApi());

            List<RecojosModels> recojosModels = new List<RecojosModels>();

            recojosModels = list.Items.Where(x => x.id_municipalidad == Convert.ToInt32(geolocalizacion)).ToList();
            recojosModels = recojosModels.OrderBy(x => x.hora_inicio).ToList();

            RecojosModels recojoProximo = new RecojosModels();
            int intProxRecojo = 0;
            int intLastRecojo = 7;

            double HoraWin = 1440;
            //int dia
            foreach (var item in recojosModels)
            {
                intProxRecojo = item.id_reciclador - dia1;

                if (intLastRecojo >= Math.Abs(intProxRecojo))
                {
                    string[] List = item.hora_inicio.Split('-');
                    string hora = List[1].Trim();

                    DateTime hora1 = DateTime.ParseExact(hora, "HH:mm",
                    CultureInfo.InvariantCulture);

                    TimeSpan ts = hora1 - hora2;
                    double xday = ts.TotalDays;
                    double ddifferenceInMinutes = ts.TotalMinutes; // This is in double

                    if (ddifferenceInMinutes > 0)
                    {
                        if (ddifferenceInMinutes < HoraWin)
                        {
                            recojoProximo = item;
                            HoraWin = ddifferenceInMinutes;
                        }
                    }

                    intLastRecojo = Math.Abs(intProxRecojo);
                }

               
            }

           /* if(recojosModels.Count == 0)
            {
                dia1++;
                horax = "08:00";
                hora2 = DateTime.ParseExact(horax, "HH:mm",
                CultureInfo.InvariantCulture);
                recojosModels = recojosModels.Where(x => x.id_reciclador == dia1).ToList();
            }

            double HoraWin = 1440;

            foreach (var item in recojosModels)
            {

                string[] List = item.hora_inicio.Split('-');
                string hora = List[1].Trim();

                DateTime hora1 = DateTime.ParseExact(hora, "HH:mm",
                CultureInfo.InvariantCulture);

                TimeSpan ts = hora1 - hora2;
                double xday = ts.TotalDays;
                double ddifferenceInMinutes = ts.TotalMinutes; // This is in double

                if (ddifferenceInMinutes > 0)
                {
                    if (ddifferenceInMinutes < HoraWin)
                    {
                        recojosModelsEnt = item;
                        HoraWin = ddifferenceInMinutes;
                    }
                }
            }*/
            diarec.Text = recojoProximo.fecha;
            horarec.Text = recojoProximo.hora_inicio;
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
                else if (NombreMenu == "Sugerencias")
                {
                    Application.Current.MainPage = new SugerenciasView(latitud, geolocalizacion, apellidos, direccion, termycond, nombres, usuario_id, correo, password, id_municipalidad, telefono, foto, longitud);
                }
            }
        }

        private void ViewConfig(object sender, EventArgs e)
        {
            Application.Current.MainPage = new ConfiguracionView(latitud, geolocalizacion, apellidos, direccion, termycond, nombres, usuario_id, correo, password, id_municipalidad, telefono, foto, longitud);
        }

        private void RutaTap(object sender, EventArgs e)
        {
           
            maparuta = recojosModelsEnt.hora_fin;

            Application.Current.MainPage = new PuntosMapaView(horazon, zonaRuta, maparuta, latitud, geolocalizacion, apellidos, direccion, termycond, nombres, usuario_id, correo, password, id_municipalidad, telefono, foto, longitud);
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