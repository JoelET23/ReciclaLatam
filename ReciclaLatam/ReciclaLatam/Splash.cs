﻿using ReciclaLatam.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ReciclaLatam
{
    public class Splash
    {
        /*Image SplashImage;

        public Splash()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            var sub = new AbsoluteLayout();
            SplashImage = new Image
            {
                Source = "Splash.png",
                WidthRequest = 360,
                HeightRequest = 640
            };

            AbsoluteLayout.SetLayoutFlags(SplashImage, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(SplashImage, new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            sub.Children.Add(SplashImage);

            this.BackgroundColor = Color.FromHex("#000000");
            this.Content = sub;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await SplashImage.ScaleTo(1, 2000);
            await SplashImage.ScaleTo(0.9, 1500, Easing.Linear);
            await SplashImage.ScaleTo(150, 2000, Easing.Linear);
            Application.Current.MainPage = new NavigationPage(new LoginView());
        }*/
    }
}
