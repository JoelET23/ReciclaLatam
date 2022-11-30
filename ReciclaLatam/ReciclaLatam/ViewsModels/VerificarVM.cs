using ReciclaLatam.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace ReciclaLatam.ViewsModels
{
    public class VerificarVM
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _codigo;

        public string Codigo
        {
            get { return _codigo; }
            set
            {
                _codigo = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Codigo"));
            }
        }
        public VerificarVM()
        {
            _codigo = "Joel";
        }
        public Command ValidarCommand
        {
            get { return new Command(ValidarClave); }
        }
        private void ValidarClave()
        {
            if (string.IsNullOrEmpty(_codigo))
            {
                App.Current.MainPage.DisplayAlert("Verificación", "Por favor ingresar el código", "Ok");
            }
            else
            {
                if (Codigo == "Joel")
                {
                    //Application.Current.MainPage = new InicioView();
                }
                else
                {
                    App.Current.MainPage.DisplayAlert("Error", "Ingresar correctamente el código", "Ok");
                }
            }

        }
    }
}
