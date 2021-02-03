using Microsoft.Extensions.Configuration;
using PessoaApi.Repository.db;
using PessoaApi.Repository.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace PessoaApi.Repository.Repository
{


    /*
     * Usarei o Entity Framework e ADO.NET apenas para mostrar mais conhecimentos (Desempenho x Facilidade)
     * 
     * Não colocarei em um banco de dados real, para não precisar subir instancias em servidores,
     * mas deixarei as connections Strings no appsetings.json
     * 
     * Não Hospedarei no IIS, para não precisar subir a instancia no azure 
     * 
     * Não usarei os novos recursos do Entity Framework 5
     */
    public class PessoaRepository : IPessoaRepository
    {

        public PessoaRepository()
        {

        }

        public PessoaRepository(IConfiguration configuration, Context context)
        {
            _context = context;
            _configuration = configuration;
        }

        private IConfiguration _configuration;
        private Context _context;

        public string connectionstring()
        {
            string conn = _configuration.GetValue<string>("ConnectionSQL:SQLConnectionString");
            return conn;
        }

        public void Atualizar(Pessoa pessoa)
        {
            string conn = connectionstring();

            try
            {
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("CADASTRAR_PESSOA", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandTimeout = 240;
                        command.Parameters.Add("@Numero", SqlDbType.VarChar).Value = pessoa.Numero.ToString();
                        command.Parameters.Add("@Nome", SqlDbType.VarChar).Value = pessoa.Nome.ToString();
                        command.Parameters.Add("@Email", SqlDbType.VarChar).Value = pessoa.Email.ToString();
                        command.Parameters.Add("@Sexo", SqlDbType.VarChar).Value = pessoa.Sexo.ToString() ;
                        command.Parameters.Add("@Idade", SqlDbType.Int).Value = pessoa.Idade ;
                        command.Connection.Open();

                        using (SqlTransaction transaction = connection.BeginTransaction())
                        {
                            command.Transaction = transaction;
                            command.ExecuteNonQuery();
                            command.Transaction.Commit();
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public void Cadastrar(Pessoa pessoa)
        {
            try
            {
                _context.Pessoa.Add(pessoa);
                _context.SaveChanges();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public Pessoa Consultar(string numeroPessoa)
        {
            var pessoa = _context.Pessoa.Where(p => p.Numero.Equals(numeroPessoa)).SingleOrDefault();

            return pessoa;
        }

        public List<Pessoa> Consultar()
        {
            return _context.Pessoa.ToList();
        }

        public void Deletar(string numeroPessoa)
        {
            Pessoa pessoa = Consultar(numeroPessoa);
            _context.Remove(pessoa.Numero);
            _context.SaveChanges();
        }

       
    }
}
