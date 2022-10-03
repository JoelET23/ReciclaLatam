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
    public partial class CambiarPassView : ContentPage
    {
        public CambiarPassView()
        {
            InitializeComponent();
        }
        private void EditBack(object sender, EventArgs e)
        {
            Application.Current.MainPage = new EditaView();
        }
        private void ChangePass(object sender, EventArgs e)
        {
            Application.Current.MainPage = new InicioView();
        }
    }
}