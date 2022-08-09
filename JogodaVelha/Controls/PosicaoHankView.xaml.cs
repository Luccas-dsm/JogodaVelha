using JogodaVelha.Libs;
using JogodaVelha.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JogodaVelha.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PosicaoHankView : ContentView
    {
        public PosicaoHankView()
        {
            InitializeComponent();
        }
        public Criajogador jogador;
        public PosicaoHankView(string nome, int pontuacao, int posicao, Criajogador jogador)
        {
            InitializeComponent();
            Nome.Text = nome;
            Pontuacao.Text = pontuacao.ToString();
            Posicao.Text = posicao.ToString();
            this.jogador = jogador;
        }

        private async void Posicao_Clicked(object sender, EventArgs e)
{
            await Navigation.PushAsync(new PerfilPage(jogador,Nome.Text));
        }
    }
}