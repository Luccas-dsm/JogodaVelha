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
    public partial class JogodaVelhaPage : ContentPage
    {
        public bool Jogador { get; set; } = true;

        /*public string[,] posicoes = new string[3, 3] { { "", "", "" }, { "", "", "" },  { "", "", "" } };
                                                      /*  0   1   2      3    4   5        6   7   8   */


        public string[,] posicoes = new string[3, 3] { { "8", "1", "6" }, { "3", "5", "7" }, { "4", "9", "2" } };
        /*  0    1    2       3    4    5      6    7    8   */

        
        public JogodaVelhaPage()
        {
            InitializeComponent();
        }
        private void Button_Clicked(object sender, EventArgs e)
        {

            if (!((Button)sender).BindingContext.ToString().Equals("X") && !((Button)sender).BindingContext.ToString().Equals("O"))
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

    }
    
}