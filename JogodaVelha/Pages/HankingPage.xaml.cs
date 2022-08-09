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
    public partial class HankingPage : ContentPage
    {

        private Criajogador Jogadores;
        public HankingPage()
        {
            InitializeComponent();         
        }


        public HankingPage(Criajogador jogador)
        {
            InitializeComponent();
            this.Jogadores = jogador;
            GeraHank();
        }


        public void GeraHank()
        {

            int posicao = 1;
            List<Jogador> jogadorList = Jogadores.RetornaListadeJogadores();           
            List<Jogador> lista = (from e in jogadorList
                                   orderby e.Pontos descending
                                   select e).ToList()  ;
       
            foreach (var item in lista)
            {

                switch (posicao)
                {
                    case 1:
                        lbNomeP.Text = item.Nome;
                        lbPontosP.Text = item.Pontos.ToString();
                        break;
                    case 2:
                        lbNomeS.Text=item.Nome;
                        lbPontosS.Text = item.Pontos.ToString();
                        break;
                    case 3:
                        lbNomeT.Text = item.Nome;
                        lbPontosT.Text = item.Pontos.ToString();
                        break;
                    default:
                        var obj = new PosicaoHankView(item.Nome, item.Pontos, posicao, Jogadores);
                        ContainerHank.Children.Add(obj);
                        break;
                }
                     posicao++;    
              
            }
        }

        private async void Jogador_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PerfilPage(Jogadores, ((Button)sender).Text));
        }
    }

}