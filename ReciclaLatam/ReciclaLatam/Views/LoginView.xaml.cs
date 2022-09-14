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
    public partial class LoginView : ContentPage
    {
        LoginVM LoginIndex;
        public LoginView()
        {
            InitializeComponent();
            LoginIndex = new LoginVM();
            BindingContext = LoginIndex;
        }
    }
}