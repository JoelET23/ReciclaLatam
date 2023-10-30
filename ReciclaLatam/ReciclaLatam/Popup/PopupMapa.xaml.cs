using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReciclaLatam.Popup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupMapa : Rg.Plugins.Popup.Pages.PopupPage
    {
       
        public PopupMapa(string tag)
        {
            InitializeComponent();
            lbldesmap.Text = tag;
        }

        private void btnclosemodal(object sender, EventArgs e)
        {
            Navigation.PopPopupAsync();
            
        }

        private void Popupbgclick(object sender, EventArgs e)
        {

        }
    }
}