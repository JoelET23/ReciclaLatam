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
       
        public PopupMapa(string tag, string lbl)
        {
            InitializeComponent();
            lbldesmap.Text = tag;
            lbltitmap.Text = lbl;

            lbldesmapFl.Text = tag;
            lbltitmapFl.Text = lbl;
        }

        private void btnclosemodal(object sender, EventArgs e)
        {
            Navigation.PopPopupAsync(); 


        }

        private void Popupbgclick(object sender, EventArgs e)
        {
            Navigation.PopPopupAsync();
        }

        private void BtnClMdFl(object sender, EventArgs e)
        {
            Navigation.PopPopupAsync();
        }

        private void BtnLink(object sender, EventArgs e)
        {
            FrameFull.IsVisible = false;
            FrameLink.IsVisible = true;
            ContPrin.BackgroundColor = Color.FromHex("#FFFFFF");
        }

        private void onFrameNl(object sender, EventArgs e)
        {
            FrameFull.IsVisible = false;
            FrameContFl.IsVisible = true;
            FrameContFl.HasShadow = false;
            ContPrin.VerticalOptions = LayoutOptions.Center;
        }

        private void BtnFlLeg(object sender, EventArgs e)
        {
            FrameContFl.IsVisible = false;
            FrameLink.IsVisible = true;
            ContPrin.BackgroundColor = Color.FromHex("#FFFFFF");
            ContPrin.VerticalOptions = LayoutOptions.End;
        }

    }
}