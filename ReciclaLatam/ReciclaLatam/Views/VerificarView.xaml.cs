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
    public partial class VerificarView : ContentPage
    {
        public VerificarView()
        {
            InitializeComponent();
        }
        private void LoginBack(object sender, EventArgs e)
        {
            Application.Current.MainPage = new OlvideContrasenaView();
        }

        private void VolverCodigo(object sender, EventArgs e)
        {
            //Application.Current.MainPage = new LoginView();
        }
    }
}