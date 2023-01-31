using ReciclaLatam.ApiRest;
using ReciclaLatam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReciclaLatam.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MisionView : ContentPage
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
        #endregion
        public MisionView(double l, string g, string ap, string dir, string ter, string nom, int id, string cor, string pas, string idmu, string tel, string fot, double lon)
        {
            InitializeComponent();
            getNosotros();

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

        private async void getNosotros()
        {
            ApiNosotros objApiNosotros = new ApiNosotros();
            Task<NosotrosLista> returnNosotrosLista = objApiNosotros.WebApi();
            NosotrosLista objNosotrosLista = await returnNosotrosLista;

            foreach (var nosotros in objNosotrosLista.Items)
            {
                switch (nosotros.tipo_nosotros)
                {
                    case 2:
                        ImgNos.Source = nosotros.imagen;
                        TxtTitNot.Text = nosotros.titulo;
                        TxtDesNot.Text = nosotros.descripcion;
                        break;
                }
            }
        }

        private void HomeBack(object sender, EventArgs e)
        {
            Application.Current.MainPage = new InicioView(latitud, geolocalizacion, apellidos, direccion, termycond, nombres, usuario_id, correo, password, id_municipalidad, telefono, foto, longitud);
        }

        private void NosotrosTbView(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NosotrosView(latitud, geolocalizacion, apellidos, direccion, termycond, nombres, usuario_id, correo, password, id_municipalidad, telefono, foto, longitud);
        }

        private void MisionTbView(object sender, EventArgs e)
        {
            Application.Current.MainPage = new MisionView(latitud, geolocalizacion, apellidos, direccion, termycond, nombres, usuario_id, correo, password, id_municipalidad, telefono, foto, longitud);
        }

        private void VisionTbView(object sender, EventArgs e)
        {
            Application.Current.MainPage = new VisionView(latitud, geolocalizacion, apellidos, direccion, termycond, nombres, usuario_id, correo, password, id_municipalidad, telefono, foto, longitud);
        }

        private void PalmosaTbView(object sender, EventArgs e)
        {
            Application.Current.MainPage = new PalmosaView(latitud, geolocalizacion, apellidos, direccion, termycond, nombres, usuario_id, correo, password, id_municipalidad, telefono, foto, longitud);
        }
    }
}