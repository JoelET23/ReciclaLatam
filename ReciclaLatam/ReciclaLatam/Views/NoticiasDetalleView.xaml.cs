using ReciclaLatam.ApiRest;
using ReciclaLatam.Models;
using ReciclaLatam.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReciclaLatam.ViewsModels
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoticiasDetalleView : ContentPage
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

        //const int VarNoticia;
        public NoticiasDetalleView(string l, string g, string ap, string dir, string ter, string nom, int id, string cor, string pas, string idmu, string tel, string fot, string lon, string titnot, string fecnot, string catnot, string imgnot, string connot)
        {
            InitializeComponent();
            ContNot.Text = connot;
            LblTitNot.Text = titnot;
            LblFechNot.Text = fecnot;
            LblCatNot.Text = catnot;
            ImgNot.Source = imgnot;

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

  

        private void NoticiaBack(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NoticiasView(latitud, geolocalizacion, apellidos, direccion, termycond, nombres, usuario_id, correo, password, id_municipalidad, telefono, foto, longitud);
        }
        private void ConfiguracionTap(object sender, EventArgs e)
        {
            Application.Current.MainPage = new ConfiguracionView(latitud, geolocalizacion, apellidos, direccion, termycond, nombres, usuario_id, correo, password, id_municipalidad, telefono, foto, longitud);
        }
    }
}