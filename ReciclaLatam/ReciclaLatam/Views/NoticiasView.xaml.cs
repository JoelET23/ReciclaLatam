using ReciclaLatam.Models;
using ReciclaLatam.ViewsModels;
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
    public partial class NoticiasView : ContentPage
    {
        public NoticiasView()
        {
            InitializeComponent();
            BindingContext = new NoticiaVM();

            NoticiaPage.SelectionChanged += NoticiaPageChanged;
        }

        private void NoticiaPageChanged(object sender, SelectionChangedEventArgs e)
        {
            var _ItemNoticia = e.CurrentSelection;

            for (int i = 0; i < _ItemNoticia.Count; i++)
            {
                var _itemNot = _ItemNoticia[i] as NoticiasModels;
                var NombreNot = _itemNot.Titulo;
                var IdNotItem = _itemNot.Id;

                //DisplayAlert("Alerta", "Entra a página detalle", "OK");
                Application.Current.MainPage = new NoticiasDetalleView();
                /*if (IdMenuItem == 1)
                {
                    DisplayAlert("Alerta", "Entra a página de recojo", "OK");
                }
                else if (NombreMenu == "Puntos")
                {
                    DisplayAlert("Alerta", "Entra a página de puntos", "OK");
                }
                else if (IdMenuItem == 3)
                {
                    Application.Current.MainPage = new ManualesView();
                }
                else if (NombreMenu == "Noticias")
                {
                    DisplayAlert("Alerta", "Entra a página de noticias", "OK");
                }
                else if (NombreMenu == "Mi info")
                {
                    DisplayAlert("Alerta", "Entra a página de Mi info", "OK");
                }
                else if (NombreMenu == "Nosotros")
                {
                    DisplayAlert("Alerta", "Entra a página de nosotros", "OK");
                }*/
            }
        }
    }
}