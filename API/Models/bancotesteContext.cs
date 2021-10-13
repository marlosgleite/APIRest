using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace API.Models
{
    public partial class bancotesteContext : DbContext
    {
        public bancotesteContext()
        {
        }

        public bancotesteContext(DbContextOptions<bancotesteContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Encomendum> Encomenda { get; set; }
        public virtual DbSet<Entregador> Entregadors { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<RelEncomendaProduto> RelEncomendaProdutos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("data source=127.0.0.1;initial catalog=bancoteste;user id=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.21-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("clientes");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Data)
                    .HasColumnType("date")
                    .HasColumnName("data")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("nome");

                entity.Property(e => e.Token)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("token");
            });

            modelBuilder.Entity<Encomendum>(entity =>
            {
                entity.ToTable("encomenda");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.DateCreate)
                    .HasColumnType("date")
                    .HasColumnName("date_create")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.DateDelivery)
                    .HasColumnType("date")
                    .HasColumnName("date_delivery");

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("endereco");
            });

            modelBuilder.Entity<Entregador>(entity =>
            {
                entity.ToTable("entregador");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("descricao");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("nome");

                entity.Property(e => e.Placa)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("placa");
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.ToTable("produto");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("descricao");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("nome");

                entity.Property(e => e.Valor)
                    .HasPrecision(1, 1)
                    .HasColumnName("valor");
            });

            modelBuilder.Entity<RelEncomendaProduto>(entity =>
            {
                entity.ToTable("rel_encomenda_produto");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.IdEncomenda)
                    .HasColumnType("int(11)")
                    .HasColumnName("idEncomenda");

                entity.Property(e => e.IdEntregador)
                    .HasColumnType("int(11)")
                    .HasColumnName("idEntregador");

                entity.Property(e => e.IdProduto)
                    .HasColumnType("int(11)")
                    .HasColumnName("idProduto");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
