using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using JogodaVelha.Controls;
using JogodaVelha.Libs;

namespace JogodaVelha.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PerfilPage : ContentPage
    {
        private Criajogador Jogadores;

        public PerfilPage()
        {
            InitializeComponent();
        }

        public PerfilPage(Criajogador jogador, string nomejogador="Luccas")
        {
            InitializeComponent();
            this.Jogadores = jogador;

            if (!string.IsNullOrEmpty(nomejogador))
                ExibeDados(nomejogador);
        }

        public void ExibeDados(string nomeJogador)
        {

            List<Jogador> jogadorList = Jogadores.RetornaListadeJogadores();
            foreach (var item in jogadorList)
            {
                if (item.Nome == nomeJogador)
                {
                    lbNome.Text = item.Nome;
                    LbPtotal.Text = item.Pontos.ToString();
                    LbNpartidas.Text = item.Partidas.ToString();
                    LbQvitorias.Text = item.Vitorias.ToString();
                    LbQderrotas.Text = item.Derrotas.ToString();
                }
            }
        }

    }
}