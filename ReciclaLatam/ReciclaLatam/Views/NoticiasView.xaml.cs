using ReciclaLatam.ApiRest;
using ReciclaLatam.Models;
using ReciclaLatam.ViewsModels;
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
    public partial class NoticiasView : ContentPage
    {
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

        public string TitNoticia;
        public string FecNoticia;
        public string CatNoticia;
        public string ImgNoticia;
        public string DesNoticia;

        #endregion

        public NoticiasView(string l, string g, string ap, string dir, string ter, string nom, int id, string cor, string pas, string idmu, string tel, string fot, string lon)
        {
            InitializeComponent();
            //BindingContext = new NoticiaVM();
            getNoticias();
            NoticiaPage.SelectionChanged += NoticiaPageChanged;

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

        private async void getNoticias()
        {
            ApiNoticias objApiNoticias = new ApiNoticias();
            Task<NoticiasLista> returnNoticiasLista = objApiNoticias.WebApi();
            NoticiasLista objNoticiasLista = await returnNoticiasLista;

            NoticiaPage.ItemsSource = objNoticiasLista.Items;
        }

        private void NoticiaPageChanged(object sender, SelectionChangedEventArgs e)
        {
            var _ItemNoticia = e.CurrentSelection;

            for (int i = 0; i < _ItemNoticia.Count; i++)
            {
                var _itemNot = _ItemNoticia[i] as NoticiasModels;
                TitNoticia = _itemNot.titulo;
                FecNoticia = _itemNot.fecha_pub;
                CatNoticia = _itemNot.categoria;
                ImgNoticia = _itemNot.imagen;
                DesNoticia = _itemNot.contenido_noticia;

                Application.Current.MainPage = new NoticiasDetalleView(latitud, geolocalizacion, apellidos, direccion, termycond, nombres, usuario_id, correo, password, id_municipalidad, telefono, foto, longitud, TitNoticia, FecNoticia, CatNoticia, ImgNoticia, DesNoticia); 
            }
        }
        private void ConfiguracionTap(object sender, EventArgs e)
        {
            Application.Current.MainPage = new ConfiguracionView(latitud, geolocalizacion, apellidos, direccion, termycond, nombres, usuario_id, correo, password, id_municipalidad, telefono, foto, longitud);
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