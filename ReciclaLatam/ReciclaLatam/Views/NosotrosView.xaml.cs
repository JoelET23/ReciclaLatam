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
    public partial class NosotrosView : ContentPage
    {
        public NosotrosView()
        {
            InitializeComponent();
        }
        private void HomeBack(object sender, EventArgs e)
        {
            Application.Current.MainPage = new InicioView();
        }
        private void TuRecojoView(object sender, EventArgs e)
        {
            Application.Current.MainPage = new InicioView();
        }
    }
}