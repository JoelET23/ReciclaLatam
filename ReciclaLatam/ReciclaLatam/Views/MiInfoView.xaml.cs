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
    public partial class MiInfoView : ContentPage
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
        #endregion

        public MiInfoView(string l, string g, string ap, string dir, string ter, string nom, int id, string cor, string pas, string idmu, string tel, string fot, string lon)
        {
            InitializeComponent();

            LblNomInfo.Text = nom + " " + ap;
            LblCorrInfo.Text = cor;
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
        private void ConfigBack(object sender, EventArgs e)
        {
            Application.Current.MainPage = new ConfiguracionView(latitud, geolocalizacion, apellidos, direccion, termycond, nombres, usuario_id, correo, password, id_municipalidad, telefono, foto, longitud);
        }

        private void BtnEdit(object sender, EventArgs e)
        {
            Application.Current.MainPage = new EditaView(latitud, geolocalizacion, apellidos, direccion, termycond, nombres, usuario_id, correo, password, id_municipalidad, telefono, foto, longitud);
        }
    }
}