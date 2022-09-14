using ReciclaLatam.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace ReciclaLatam.ViewsModels
{
    public class LoginVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _userName;
        private string _password;

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
        
        public LoginVM()
        {
            _userName = "Joel";
            _password = "123456";
        }

        public Command LoginCommand
        {
            get { return new Command(Login); }
        }

        private void Login()
        {
            if(string.IsNullOrEmpty(_userName) || string.IsNullOrEmpty(_password))
            {
                App.Current.MainPage.DisplayAlert("Empy values", "Por favor, ingresar usuario y contraseña", "Ok");
            }
            else
            {
                if(UserName == "Joel" && Password == "123456")
                {
                    Application.Current.MainPage = new InicioView();
                }
                else
                {
                    App.Current.MainPage.DisplayAlert("Login fallido", "Ingresar correctamente el usuario o contraseña", "Ok");
                }
            }

        }
    }
}
