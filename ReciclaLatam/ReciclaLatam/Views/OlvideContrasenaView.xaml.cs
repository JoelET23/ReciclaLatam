﻿using ReciclaLatam.ViewsModels;
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
    public partial class OlvideContrasenaView : ContentPage
    {
        OlvideContrasenaVM OlvideIndex;
        public OlvideContrasenaView()
        {
            InitializeComponent();
            OlvideIndex = new OlvideContrasenaVM();
            BindingContext = OlvideIndex;
        }
        private void LoginBack(object sender, EventArgs e)
        {
            Application.Current.MainPage = new LoginView();
        }
    }
}