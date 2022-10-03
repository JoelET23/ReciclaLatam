﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReciclaLatam.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConfiguracionView : ContentPage
    {
        public ConfiguracionView()
        {
            InitializeComponent();
        }
        private void InicioBack(object sender, EventArgs e)
        {
            Application.Current.MainPage = new InicioView();
        }
        private void ViewInfo(object sender, EventArgs e)
        {
            Application.Current.MainPage = new MiInfoView();
        }
        private void CerrarTap(object sender, EventArgs e)
        {
            Application.Current.MainPage = new LoginView();
        }
    }
}