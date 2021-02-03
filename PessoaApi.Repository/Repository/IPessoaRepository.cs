using PessoaApi.Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PessoaApi.Repository.Repository
{
    public interface IPessoaRepository
    {
        void Cadastrar(Pessoa pessoa);
        List<Pessoa> Consultar();
        Pessoa Consultar(string numeroPessoa);
        void Atualizar(Pessoa pessoa);
        void Deletar(string numeroPessoa);
    }
}
