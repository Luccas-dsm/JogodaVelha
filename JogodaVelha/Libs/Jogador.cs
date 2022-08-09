using System;
using System.Collections.Generic;
using System.Text;

namespace JogodaVelha.Libs
{
    public class Jogador 
    {
        public int Id { get; set; } = 1;
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public string Email { get; set; }
        public int Pontos { get; set; } = 0;
        public int Posicao { get; set; }
        public int Partidas { get; set; } = 0;
        public int Vitorias { get; set; } = 0;
        public int Derrotas { get; set; } = 0;

        public Jogador(string nome, string apelido, string email)
        {
            this.Id = Id;
            this.Nome = nome;
            this.Apelido = apelido; 
            this.Email = email;           
            this.Id++;
        }

    }
}
