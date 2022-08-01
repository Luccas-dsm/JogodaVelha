using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using JogodaVelha.Pages;

namespace JogodaVelha
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new JogodaVelhaPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
