using Microsoft.EntityFrameworkCore;
using PessoaApi.Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PessoaApi.Repository.db
{
    public class Context : DbContext
    {

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<Pessoa> Pessoa { get; set; }
    }
}
