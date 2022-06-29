using Microsoft.EntityFrameworkCore;
using AppAud5s.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppAud5s.BancoDados
{
    internal class BancoContext : DbContext
    {
       public DbSet<ModeloNota> ModeloNotas { get; set; }

       public DbSet<Indicador> Indicador { get; set; }

       public DbSet<ModeloPergunta>  ModeloPergunta { get; set; }

       public DbSet<Pergunta> Pergunta { get; set; }

       public DbSet<Questionario> Questionario { get; set; }

       public DbSet<QuestionarioSenso> QuestionarioSenso { get; set; } 

        public BancoContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite($"FileName={Constantes.CaminhoBanco}");
        }

        internal static object Table<T>()
        {
            throw new NotImplementedException();
        }
    }
}
