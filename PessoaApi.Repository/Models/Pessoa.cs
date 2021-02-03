using System;
using System.Collections.Generic;
using System.Text;

namespace PessoaApi.Repository.Models
{
    public class Pessoa
    {
        public Pessoa(string nome, string email, int idade, string sexo)
        {
            Numero = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10).ToUpper();
            Nome = nome;
            Email = email;
            Idade = idade;
            Sexo = sexo;

        }

        public string Numero { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public int Idade { get; private set; }
        public string Sexo { get; private set; }
    }
}
