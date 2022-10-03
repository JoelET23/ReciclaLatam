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
    public partial class RecojoView : ContentPage
    {
        public RecojoView()
        {
            InitializeComponent();
        }
        private void ConfiguracionTap(object sender, EventArgs e)
        {
            Application.Current.MainPage = new ConfiguracionView();
        }

        private void TuReciView(object sender, EventArgs e)
        {
            Application.Current.MainPage = new TuRecicladorView();
        }
        private void MenHom(object sender, EventArgs e)
        {
            Application.Current.MainPage = new InicioView();
        }
        private void MenReco(object sender, EventArgs e)
        {
            Application.Current.MainPage = new RecojoView();
        }
        private void MenPun(object sender, EventArgs e)
        {

        }
        private void MenMan(object sender, EventArgs e)
        {
            Application.Current.MainPage = new ManualesView();
        }
        private void MenNot(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NoticiasView();
        }
    }
}