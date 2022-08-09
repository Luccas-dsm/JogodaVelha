using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Xamarin.Essentials;

namespace JogodaVelha.Libs
{
    public class Criajogador
    {

        private List<Jogador> jogadorList = new List<Jogador>();
        public List<Jogador> RetornaListadeJogadores() => jogadorList;

        public void NovoJogador(string nome,string apelido, string email)
        {       
            jogadorList.Add( new Jogador(nome, apelido, email));
     
        }
         
        public object BuscaJogador (string nome)
        {
            object jogador= new List<object>();
          
                foreach (var item in jogadorList)
                {
                    if(item.Nome == nome)
                    {
                        jogador = new List<object>()
                        {
                            item.Nome,
                            item.Apelido,
                            item.Email,
                            item.Id,
                            item.Pontos
                        };                    
                    }
                }   
            return jogador;
        }

        public int RetornaPontuacao(string nome)
        {
            
            foreach (var item in jogadorList)
            {
                if (item.Nome == nome)
                {
                    return item.Pontos;
                }
            }
            return 0;
        }


        public void AdicionaPontos(string nome, int pontos)
        {
            foreach (var item in jogadorList)
            {
                if (item.Nome == nome)
                {
                    item.Pontos += pontos;
               
                }
            }
        }
        public void AdicionaDerrotas(string nome)
        {
            foreach (var item in jogadorList)
            {
                if (item.Nome == nome)
                {
                    item.Derrotas+=1;
                    item.Partidas+=1;
                }
            }
        }
        public void AdicionaVitorias(string nome)
        {
            foreach (var item in jogadorList)
            {
                if (item.Nome == nome)
                {
                    item.Vitorias += 1;
                    item.Partidas += 1;
                }
            }
        }


        public void EditarJogador(string nome, string email="", string apelido ="", string nomeNovo="" )
        {
            try
            {
                foreach (var item in jogadorList)
                {
                    if (item.Nome == nome)
                    {
                        if(!string.IsNullOrEmpty(nomeNovo)) item.Nome = nomeNovo;
                        if (!string.IsNullOrEmpty(email)) item.Email = email;
                        if (!string.IsNullOrEmpty(apelido)) item.Apelido = apelido;
                    }
                }
              
            }
            catch
            {
                
            }
        }


        public void MockdeDados()
        {
            List<Mock> lista = ListaMockada();
            Random random = new Random(); 

            foreach (var item in lista)
            {
                jogadorList.Add(new Jogador(item.Nome, item.Apelido, item.Email));
            }

            foreach (var item in lista)
            {
                AdicionaPontos(item.Nome, (int)random.Next(0,1000));

            }
        }

   

        public List<Mock> ListaMockada()
        {
           List<Mock> lista = new List<Mock>()
            {
                new Mock { Nome="Luccas",Apelido="Luc",Email="@email",Posicao=1},
                 new Mock { Nome="Marcelly",Apelido="Luc",Email="@email",Posicao=2},
                  new Mock { Nome="Luiza",Apelido="Luc",Email="@email",Posicao=3},
                   new Mock { Nome="Márcia",Apelido="Luc",Email="@email",Posicao=4},
                    new Mock { Nome="Rogério",Apelido="Luc",Email="@email",Posicao=5},
                     new Mock { Nome="Kátia",Apelido="Luc",Email="@email",Posicao=6},
                      new Mock { Nome="Victor",Apelido="Luc",Email="@email",Posicao=7},
                       new Mock { Nome="Lobo",Apelido="Luc",Email="@email",Posicao=8},
            };
            return lista;
        }


    }

    public class Mock
    {
        public int Id { get; set; } = 1;
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public string Email { get; set; }
        public int Pontos { get; set; } = 0;
        public int Posicao { get; set; }
      

    }

}
