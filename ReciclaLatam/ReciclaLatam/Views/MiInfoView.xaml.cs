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
    public partial class MiInfoView : ContentPage
    {
        public MiInfoView()
        {
            InitializeComponent();
        }
        private void ConfigBack(object sender, EventArgs e)
        {
            Application.Current.MainPage = new ConfiguracionView();
        }

        private void BtnEdit(object sender, EventArgs e)
        {
            Application.Current.MainPage = new EditaView();
        }
    }
}