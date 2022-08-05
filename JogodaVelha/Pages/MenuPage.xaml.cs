using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JogodaVelha.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        public MenuPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new JogodaVelhaPage());
        }

        private async void Sair_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MenuPage());
        }
        private async void Hanking_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HankingPage());
        }
        private async void Perfil_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PerfilPage());
        }

    }
}