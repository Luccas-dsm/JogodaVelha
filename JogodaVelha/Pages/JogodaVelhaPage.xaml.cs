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

namespace JogodaVelha.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JogodaVelhaPage : ContentPage
    {
        public bool Jogador { get; set; } = true;

        
        public string[,] posicoes;

        public int NumerodeJogadas { get; set; } = 0;
        
        

        public JogodaVelhaPage()
        {
            InitializeComponent();
            Iniciar();
            
        }


        public void Iniciar()
        {
            posicoes = new string[3, 3] { { "8", "1", "6" }, { "3", "5", "7" }, { "4", "9", "2" } };

        }


        private void Button_Clicked(object sender, EventArgs e)
        {

            if (!((Button)sender).Text.Equals("X") && !((Button)sender).Text.Equals("O"))
            {
                string pos = ((Button)sender).BindingContext.ToString();
                if (Jogador == true)
                {
                    ((Button)sender).Text = "X";
                    ((Button)sender).TextColor = Color.Coral;
                    MarcaJogada(pos, ((Button)sender).Text);

                }
                else
                {
                    ((Button)sender).Text = "O";
                    ((Button)sender).TextColor = Color.Blue;
                    MarcaJogada(pos, ((Button)sender).Text);
                }
                Jogador = !Jogador;
                NumerodeJogadas++;
            }
        }

        public void Velha()
        {
            if (NumerodeJogadas == 8)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (posicoes[i, j] != "X" || posicoes[i, j] != "O")
                            LbVitoria.Text = "Vish! Parece que deu velha.";
                    }
                }
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

            VitoriaLinha(jogador);
            VitoriaColuna(jogador);
            VitoriaDiagonalP(jogador);
            VitoriaDiagonalS(jogador);
            Velha();
        }

        public void VitoriaLinha(string jogador)
        {
            int igual = 1;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (posicoes[i, j] == posicoes[i, j + 1])
                    {
                        igual++;
                    }
                    if (igual == 4)
                        LbVitoria.Text = $"Vitória do time {jogador}";
                }
            }
        }

        public void VitoriaColuna(string jogador)
        {
            int igual = 1;

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (posicoes[i, j] == posicoes[i + 1, j])
                    {
                        igual++;
                    }
                    if (igual == 4)
                        LbVitoria.Text = $"Vitória do time {jogador}";
                }
            }
        }
        public void VitoriaDiagonalP(string jogador)
        {
            int igual = 1;

            for (int i = 0; i < 2; i++)
            {
                if (posicoes[i, i] == posicoes[i + 1, i + 1])
                {
                    igual++;
                }
                if (igual == 3)
                    LbVitoria.Text = $"Vitória do time {jogador}";

            }
        }
        public void VitoriaDiagonalS(string jogador)
        {

            int igual = 1;

            for (int i = 0; i < 2; i++)
            {
                if (posicoes[i, 3 - i - 1] == posicoes[i + 1, 3 - i - 2])
                {
                    igual++;
                }
                if (igual == 3)
                    LbVitoria.Text = $"Vitória do time {jogador}";

            }

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