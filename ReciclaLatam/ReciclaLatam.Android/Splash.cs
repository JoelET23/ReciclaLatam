using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReciclaLatam.Droid
{
    /*[Activity(Label = "Splash")]
    public class Splash : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
        }
    }*/

    [Activity(Label = "Recicla Latam", Icon = "@drawable/iconorecicla", Theme = "@style/SplashScreen", MainLauncher = true, NoHistory = true)]
    public class Splash : AppCompatActivity
    {
        protected override void OnResume()
        {
            base.OnResume();
            StartActivity(typeof(MainActivity));
        }
    }


}