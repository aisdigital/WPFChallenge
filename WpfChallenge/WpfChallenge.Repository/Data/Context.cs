using System;
using System.Collections.Generic;
using System.Text;
using WpfChallenge.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace WpfChallenge.Repository.Data
{
    public class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public virtual DbSet<Cliente> Usuario { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=prod-sql.prosegnet.com.br;Database=Ilia;User Id=userIlia;Password=Ilia@#$;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("TblCliente");

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.Nome).IsRequired().HasColumnName("NomeCliente");
                entity.Property(e => e.Email).IsRequired().HasColumnName("EmailCliente");
                entity.Property(e => e.Telefone).IsRequired().HasColumnName("TelefoneCliente");
                entity.Property(e => e.Endereco).IsRequired().HasColumnName("EnderecoCliente");
            });

        }

    }
}