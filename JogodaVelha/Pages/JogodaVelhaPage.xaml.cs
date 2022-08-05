using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Color = System.Drawing.Color;
using JogodaVelha.Libs;
using Xamarin.Essentials;

namespace JogodaVelha.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JogodaVelhaPage : ContentPage
    {
        public bool Jogador { get; set; } = true;

        
        public string[,] posicoes;

        public int NumerodeJogadas { get; set; } = 0;

        public Criajogador Jogadores { get; set; }


        public JogodaVelhaPage(Criajogador jogadores)
        {
            InitializeComponent();
            this.Jogadores = jogadores;
            Iniciar();
        }


        public void Iniciar()
        {
            posicoes = new string[3, 3] { { "8", "1", "6" }, { "3", "5", "7" }, { "4", "9", "2" } };

            PontosO.Text = Jogadores.RetornaPontuacao("O").ToString();
            PontosX.Text = Jogadores.RetornaPontuacao("X").ToString();


        }


        private void Button_Clicked(object sender, EventArgs e)
        {

            if (!((Button)sender).Text.Equals("X") && !((Button)sender).Text.Equals("O"))
            {
                string pos = ((Button)sender).BindingContext.ToString();
                if (Jogador == true)
                {
                    ((Button)sender).Text = "X";
                    ((Button)sender).TextColor = Color.White;
                    ((Button)sender).BackgroundColor = (Color)ColorConverters.FromHex("#6DA653");                 
                    MarcaJogada(pos, ((Button)sender).Text);

                }
                else
                {
                    ((Button)sender).Text = "O";
                    ((Button)sender).TextColor = Color.White;
                    ((Button)sender).BackgroundColor = (Color)ColorConverters.FromHex("#F2E4BB");
                    MarcaJogada(pos, ((Button)sender).Text);
                }
                Jogador = !Jogador;
                NumerodeJogadas++;
            }
        }

     

        public void MarcaJogada(string valor, string jogador)
        {

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (valor == posicoes[i, j])
                        posicoes[i, j] = jogador;
                }
            }

            ConfereVitoria(jogador);
        }

        public void ConfereVitoria(string jogador)
        {
            if (VitoriaLinha() || VitoriaColuna() || VitoriaDiagonalP() || VitoriaDiagonalS())
            {
                LbVitoria.Text = $"Vitória do time {jogador}";
                Jogadores.AdicionaPontos(jogador, 500);

            }
            else if (Velha())
            {
                LbVitoria.Text = "Vish! Parece que deu velha.";
                
            }
        }

        public bool Velha()
        {
            if (NumerodeJogadas == 8)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (posicoes[i, j] != "X" || posicoes[i, j] != "O")
                            return true;
                    }
                }
            }
            return false;
        }

        public bool VitoriaLinha()
        {
            int igual = 1;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (posicoes[i, j] == posicoes[i, j + 1])
                    {
                        igual+=1;
                    }
                    if (igual == 3)
                    {
                        return true;
                       
                    }
                }
                igual = 1;
            }
            return false;
        }

        public bool VitoriaColuna()
        {
            int igual = 1;

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (posicoes[i, j] == posicoes[i + 1, j])
                    {
                        igual+=1;
                    }
                    if (igual == 3)
                    {
                        return true;
                    }
                }
                igual = 1;
            }
            return false;
        }
        public bool VitoriaDiagonalP()
        {
            int igual = 1;

            for (int i = 0; i < 2; i++)
            {
                if (posicoes[i, i] == posicoes[i + 1, i + 1])
                {
                    igual+=1;
                }
                if (igual == 3)
                {
                    return true;
                }

            }
            return false;
        }
        public bool VitoriaDiagonalS()
        {

            int igual = 1;

            for (int i = 0; i < 2; i++)
            {
                if (posicoes[i, 3 - i - 1] == posicoes[i + 1, 3 - i - 2])
                {
                    igual+=1;
                }
                if (igual == 3)
                {
                    return true;
                }

            }
            return false;
        }

        private  void Reiniciar_Clicked(object sender, EventArgs e)
        {
            

        }
        private async void Desistir_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
        private void Sair_Clicked(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

  
    }

    public class teste : Behavior<Button>
    {


    }
    
}