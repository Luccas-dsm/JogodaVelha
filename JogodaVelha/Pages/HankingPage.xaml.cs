using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using JogodaVelha.Controls;

namespace JogodaVelha.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HankingPage : ContentPage
    {
        public HankingPage()
        {
            InitializeComponent();
            GeraHank();
        }


        public void GeraHank()
        {
            List<Jogador> lista = ListaPosicoes();


            foreach (var item in lista)
            {
                var obj = new PosicaoHankView(item.Nome, item.Pontos, item.Posicao);
                ContainerHank.Children.Add(obj);

            }

        }


        public List<Jogador> ListaPosicoes()
        {
            var lista = new List<Jogador>()
            {
                new Jogador { Nome="Luccas",Pontos=1500,Posicao=1},
                 new Jogador { Nome="Marcelly",Pontos=1500,Posicao=2},
                  new Jogador { Nome="Luiza",Pontos=1500,Posicao=3},
                   new Jogador { Nome="Márcia",Pontos=1500,Posicao=4},
                    new Jogador { Nome="Rogério",Pontos=1500,Posicao=5},
                     new Jogador { Nome="Kátia",Pontos=1500,Posicao=6},
                      new Jogador { Nome="Victor",Pontos=1500,Posicao=7},
                       new Jogador { Nome="Lobo",Pontos=1500,Posicao=8},
            };
            return lista;
        }

    }
    public class Jogador
    {
        public string Nome { get; set; }
        public int Pontos { get; set; }
        public int Posicao { get; set; }

      
    }
}