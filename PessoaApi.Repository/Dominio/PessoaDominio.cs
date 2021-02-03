using PessoaApi.Repository.Models;
using PessoaApi.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace PessoaApi.Repository.Dominio
{

    /*
     * ESTA CLASSE É REPOSAVEL PELA REGRA DE NEGOCIO DO TESTE, COMO NÃO TEMOS NENHUMA REGRA 
     * ELA SÓ IRA FICAR ENTRE A CAMADA DE INFRA PARA API 
     * 
     * Coloquei apenas para o uso do patterns
     */
    public class PessoaDominio : IPessoaDominio
    {
        public PessoaDominio(IPessoaRepository repository)
        {
            _repository = repository;
        }

        public IPessoaRepository _repository;

        public void Atualizar(Pessoa pessoa)
        {
            _repository.Atualizar(pessoa);
        }

        public void Cadastrar(Pessoa pessoa)
        {
            _repository.Cadastrar(pessoa);
        }

        public List<Pessoa> Consultar()
        {
            return _repository.Consultar();
        }

        public Pessoa Consultar(string numeroPessoa)
        {
           return _repository.Consultar(numeroPessoa);
        }

        public void Deletar(string numeroPessoa)
        {
            _repository.Consultar(numeroPessoa);
        }
    }
}
