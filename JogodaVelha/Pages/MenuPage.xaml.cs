using JogodaVelha.Libs;
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
        private Criajogador jogadores;

        public MenuPage()
        {
            InitializeComponent();

            jogadores = new Criajogador();
            jogadores.NovoJogador("X", "testeX", "emailtesteX");
            jogadores.NovoJogador("O", "testeO", "emailtesteO");

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new JogodaVelhaPage(jogadores));
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