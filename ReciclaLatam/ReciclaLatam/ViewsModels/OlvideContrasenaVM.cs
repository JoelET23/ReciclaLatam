using ReciclaLatam.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace ReciclaLatam.ViewsModels
{
    public class OlvideContrasenaVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set { _userName = value;
                PropertyChanged(this, new PropertyChangedEventArgs("UserName"));
            }
        }
        public OlvideContrasenaVM()
        {
            _userName = "Joel";
        }
        public Command OlvideCommand
        {
            get { return new Command(OlvideClave); }
        }
        private void OlvideClave()
        {
            if (string.IsNullOrEmpty(_userName))
            {
                App.Current.MainPage.DisplayAlert("Empy values", "Por favor, ingresar usuario", "Ok");
            }
            else
            {
                if (UserName == "Joel")
                {
                    Application.Current.MainPage = new VerificarView();
                }
                else
                {
                    App.Current.MainPage.DisplayAlert("Error", "Ingresar correctamente el usuario", "Ok");
                }
            }

        }
    }
}
