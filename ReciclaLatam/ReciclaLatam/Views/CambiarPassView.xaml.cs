using Newtonsoft.Json;
using ReciclaLatam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReciclaLatam.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CambiarPassView : ContentPage
    {
        #region Variables

        public string latitudDm;
        public string geolocalizacionDm;
        public string apellidosDm;
        public string direccionDm;
        public string termycondDm;
        public string nombresDm;
        public int usuario_idDm;
        public string correoDm;
        public string passwordDm;
        public string id_municipalidadDm;
        public string telefonoDm;
        public string fotoDm;
        public string longitudDm;

        #endregion
        public CambiarPassView(string l, string g, string ap, string dir, string ter, string nom, int id, string cor, string pas, string idmu, string tel, string fot, string lon)
        {
            InitializeComponent();

            #region Variables2
            latitudDm = l;
            geolocalizacionDm = g;
            apellidosDm = ap;
            direccionDm = dir;
            termycondDm = ter;
            nombresDm = nom;
            usuario_idDm = id;
            correoDm = cor;
            passwordDm = pas;
            id_municipalidadDm = idmu;
            telefonoDm = tel;
            fotoDm = fot;
            longitudDm = lon;
            #endregion
        }

        private void EditBack(object sender, EventArgs e)
        {
            Application.Current.MainPage = new EditaView(latitudDm, geolocalizacionDm, apellidosDm, direccionDm, termycondDm, nombresDm, usuario_idDm, correoDm, passwordDm, id_municipalidadDm, telefonoDm, fotoDm, longitudDm);
        }
        private async void ChangePass(object sender, EventArgs e)
        {
            string oldpass = ClaveAct.Text;
            string newpass = ClaveNew.Text;
            string newtpass = ClaveNewt.Text;

            if (string.IsNullOrEmpty(oldpass) || string.IsNullOrEmpty(newpass) || string.IsNullOrEmpty(newtpass))
            {
                await App.Current.MainPage.DisplayAlert("Campos vacíos", "No debe haber campos vacíos", "Ok");
            }
            else
            {
                if (oldpass == passwordDm)
                {
                    if (newpass == newtpass)
                    {
                        passwordDm = newpass;

                        var UserUp = new UsuarioUpdate
                        {
                            latitud = latitudDm,
                            geolocalizacion = geolocalizacionDm,
                            apellidos = apellidosDm,
                            direccion = direccionDm,
                            termycond = termycondDm,
                            nombres = nombresDm,
                            correo = correoDm,
                            id = usuario_idDm,
                            password = newpass,
                            id_municipalidad = id_municipalidadDm,
                            telefono = telefonoDm,
                            foto = fotoDm
                        };
                        var stringPayload = JsonConvert.SerializeObject(UserUp);

                        var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");

                        var httpClient = new HttpClient();
                        var httpResponse = await httpClient.PutAsync("https://4f6xpxszn6.execute-api.us-east-1.amazonaws.com/items", httpContent);

                        if (httpResponse.Content != null)
                        {
                            var responseContent = await httpResponse.Content.ReadAsStringAsync();
                        }

                        Application.Current.MainPage = new MiInfoView(latitudDm, geolocalizacionDm, apellidosDm, direccionDm, termycondDm, nombresDm, usuario_idDm, correoDm, passwordDm, id_municipalidadDm, telefonoDm, fotoDm, longitudDm);
                    }
                    else
                    {
                        await DisplayAlert("Error", "Las contraseñas no son iguales", "OK");
                        ClaveNew.Text = "";
                        ClaveNewt.Text = "";
                    }
                }
                else
                {
                    await DisplayAlert("Error", "No es la contraseña actual", "OK");
                }
            }
        }
    }
}