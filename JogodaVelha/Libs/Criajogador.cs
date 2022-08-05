using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace JogodaVelha.Libs
{
    public class Criajogador
    {

        private List<Jogador> jogadorList = new List<Jogador>();

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

    }
}
