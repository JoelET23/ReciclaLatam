﻿using ReciclaLatam.Models;
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
    public partial class InicioView : ContentPage
    {
        public InicioView()
        {
            InitializeComponent();
            BindingContext = new InicioVM();
            MenuInicioPage.SelectionChanged += MenuInicioChanged;
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
                    DisplayAlert("Alerta", "Entra a página de recojo", "OK");
                }
                else if (NombreMenu == "Puntos")
                {
                    DisplayAlert("Alerta", "Entra a página de puntos", "OK");
                }
                else if (IdMenuItem == 3)
                {
                    Application.Current.MainPage = new ManualesView();
                }
                else if (NombreMenu == "Noticias")
                {
                    Application.Current.MainPage = new NoticiasView();
                }
                else if (NombreMenu == "Mi info")
                {
                    DisplayAlert("Alerta", "Entra a página de Mi info", "OK");
                }
                else if (NombreMenu == "Nosotros")
                {
                    DisplayAlert("Alerta", "Entra a página de nosotros", "OK");
                }
            }
        }
    }
}