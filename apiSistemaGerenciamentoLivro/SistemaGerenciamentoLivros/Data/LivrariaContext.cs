using SistemaGerenciamentoLivros.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace SistemaGerenciamentoLivros.Data
{
    public class LivrariaContext : DbContext
    {

        public LivrariaContext() : base("name=db")
        {

        }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Editora> Editoras { get; set; }


        // Remove a plurarização nas tabelas.
        protected override void OnModelCreating(DbModelBuilder dbModelBuilder)
        {
            dbModelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}