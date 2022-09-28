using ReciclaLatam.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReciclaLatam.ViewsModels
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoticiasDetalleView : ContentPage
    {
        public NoticiasDetalleView()
        {
            InitializeComponent();
        }

        private void NoticiaBack(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NoticiasView();
        }
        private void ConfiguracionTap(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NoticiasView();
        }
    }
}