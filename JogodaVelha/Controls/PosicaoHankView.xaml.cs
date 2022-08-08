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
        public PosicaoHankView(string nome, int pontuacao, int posicao)
        {
            InitializeComponent();
            Nome.Text = nome;
            Pontuacao.Text = pontuacao.ToString();
            Posicao.Text = posicao.ToString();

        }
    }
}