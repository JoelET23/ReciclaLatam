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
    public partial class EditaView : ContentPage
    {
        public EditaView()
        {
            InitializeComponent();
        }
        private void InfoBack(object sender, EventArgs e)
        {
            Application.Current.MainPage = new MiInfoView();
        }
        private void ChangePass(object sender, EventArgs e)
        {
            Application.Current.MainPage = new CambiarPassView();
        }
    }
}