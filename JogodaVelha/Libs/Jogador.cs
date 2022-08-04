using System;
using System.Collections.Generic;
using System.Text;

namespace JogodaVelha.Libs
{
    public class Jogador : Pontuacao
    {
        public int Id { get; set; } = 1;
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public string Email { get; set; }

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
