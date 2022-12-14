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

        public string Jogador1 { get; set; }

        public string Jogador2 { get; set; }

        public JogodaVelhaPage(Criajogador Jogador)
        {
            InitializeComponent();
            this.Jogadores = Jogador;
            Iniciar();
            
        }


        public void Iniciar()
        {
            posicoes = new string[3, 3] { { "8", "1", "6" }, { "3", "5", "7" }, { "4", "9", "2" } };


            Jogador1 = "Luccas";
            Jogador2 = "Marcelly";

            PontosO.Text = Jogadores.RetornaPontuacao(Jogador1).ToString();
            PontosX.Text = Jogadores.RetornaPontuacao(Jogador2).ToString();



            

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

     

        public void MarcaJogada(string valor, string peao)
        {

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (valor == posicoes[i, j])
                        posicoes[i, j] = peao;
                }
            }
            
            ConfereVitoria(peao);
        }

        public void ConfereVitoria(string peao)
        {
            if (VitoriaLinha() || VitoriaColuna() || VitoriaDiagonalP() || VitoriaDiagonalS())
            {
                LbVitoria.Text = $"Vitória do time {peao}";

                if (peao.Equals("X"))
                {
                    Jogadores.AdicionaPontos(Jogador2, 500);
                    Jogadores.AdicionaVitorias(Jogador2);
                    Jogadores.AdicionaDerrotas(Jogador1);
                }
                else
                {
                    Jogadores.AdicionaPontos(Jogador1, 500);
                    Jogadores.AdicionaVitorias(Jogador1);
                    Jogadores.AdicionaDerrotas(Jogador2);
                }
            }
            else if (Velha())
            {
                LbVitoria.Text = "Vish! Parece que deu velha.";

            }

            //logica para detectar bugs em cada metodo
            //if(VitoriaLinha())
            //{
            //    LbVitoria.Text = $"Vitória do time {jogador}";
            //    Jogadores.AdicionaPontos(jogador, 500);
            //}
            //else if(VitoriaColuna())
            //{
            //    LbVitoria.Text = $"Vitória do time {jogador}";
            //    Jogadores.AdicionaPontos(jogador, 500);
            //}
            //else if (VitoriaDiagonalP())
            //{
            //    LbVitoria.Text = $"Vitória do time {jogador}";
            //    Jogadores.AdicionaPontos(jogador, 500);
            //}
            //else if (VitoriaDiagonalS())
            //{
            //    LbVitoria.Text = $"Vitória do time {jogador}";
            //    Jogadores.AdicionaPontos(jogador, 500);
            //}
            //else if (Velha())
            //{
            //    LbVitoria.Text = "Vish! Parece que deu velha.";
            //}


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
           
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    if (posicoes[i, j] == posicoes[i, j+1] && posicoes[i, j] == posicoes[i, j+2])
                    {
                        return true;
                    }
                }
              
            }
            return false;
        }

        public bool VitoriaColuna()
        {
            
            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (posicoes[i, j] == posicoes[i + 1, j ] && posicoes[i, j] == posicoes[i + 2, j])
                    {
                        return true;
                    }     
                }             
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