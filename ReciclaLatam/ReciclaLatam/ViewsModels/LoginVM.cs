using ReciclaLatam.ApiRest;
using ReciclaLatam.Models;
using ReciclaLatam.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ReciclaLatam.ViewsModels
{
    public class LoginVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _userName;
        private string _password;
        private string UserLog;
        private string PassLog;

        public string UserName
        {
            get { return _userName; }
            set { _userName = value;
                PropertyChanged(this, new PropertyChangedEventArgs("UserName"));
            }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }
        
        /*public LoginVM()
        {
            _userName = "Joel";
            _password = "123456";
        }*/

        public Command LoginCommand
        {
            get { return new Command(Login); }
        }

        private async void Login()
        {
            ApiUsuario objApiUsuario = new ApiUsuario();
            Task<UsuarioLista> returnUsuarioLista = objApiUsuario.WebApi();
            UsuarioLista objUsuarioLista = await returnUsuarioLista;

            if (string.IsNullOrEmpty(_userName) || string.IsNullOrEmpty(_password))
            {
                await App.Current.MainPage.DisplayAlert("Campos vacíos", "Por favor, ingresar usuario y contraseña", "Ok");
            }
            else
            {
                foreach (var usuariosList in objUsuarioLista.Items)
                {
                    UserLog = usuariosList.correo;
                    PassLog = usuariosList.password;

                    if (UserLog == _userName && PassLog == _password)
                    {
                        string latitud = usuariosList.latitud;
                        string geolocalizacion = usuariosList.geolocalizacion;
                        string apellidos = usuariosList.apellidos;
                        string direccion = usuariosList.direccion;
                        string termycond = usuariosList.termycond;
                        string nombres = usuariosList.nombres;
                        int usuario_id = usuariosList.usuario_id;
                        string correo = usuariosList.correo;
                        string password = usuariosList.password;
                        string id_municipalidad = usuariosList.id_municipalidad;
                        string telefono = usuariosList.telefono;
                        string foto = usuariosList.foto;
                        string longitud = usuariosList.longitud;

                        Application.Current.MainPage = new InicioView(latitud, geolocalizacion, apellidos, direccion, termycond, nombres, usuario_id, correo, password, id_municipalidad, telefono, foto, longitud);
                    }
                }

                /*if (UserLog != _userName || PassLog != _password)
                {
                    await App.Current.MainPage.DisplayAlert("Login fallido", "Ingresar correctamente el usuario o contraseña", "Ok");
                }*/
             }
        }
    }
}