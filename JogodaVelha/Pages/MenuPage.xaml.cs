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
            jogadores.MockdeDados();

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new JogodaVelhaPage(jogadores));
        }

        private  void Sair_Clicked(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }
        private async void Hanking_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HankingPage(jogadores));
        }
        private async void Perfil_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PerfilPage(jogadores));         
        }

    }
}