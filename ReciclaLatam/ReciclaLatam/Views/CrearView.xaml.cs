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
    public partial class CrearView : ContentPage
    {
        public CrearView()
        {
            InitializeComponent();
        }
        private void LoginBack(object sender, EventArgs e)
        {
            Application.Current.MainPage = new LoginView();
        }
        private void LoginPass(object sender, EventArgs e)
        {
            Application.Current.MainPage = new LoginView();
        }

        private void SaveLog(object sender, EventArgs e)
        {
            Application.Current.MainPage = new LoginView();
        }
    }
}