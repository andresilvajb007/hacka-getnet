﻿using System;
using hacka_getnet.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace hacka_getnet
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Incentivador> Incentivador { get; set; }
        public DbSet<Empreendedor> Empreendedor { get; set; }
        public DbSet<SolicitacaoCredito> SolicitacaoCredito { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Incentivador>(ConfigureIncentivador);
            modelBuilder.Entity<Empreendedor>(ConfigureEmpreendedor);
            modelBuilder.Entity<SolicitacaoCredito>(ConfigureSolicitacaoCredito);

        }

        private void ConfigureSolicitacaoCredito(EntityTypeBuilder<SolicitacaoCredito> obj)
        {
            obj.HasKey(x => x.Id);

            obj.HasOne(x => x.Empreendedor)
                .WithMany(x=>x.SolicitacoesCredito)
                .HasForeignKey(x=>x.EmpreendedorId);
        }

        private void ConfigureEmpreendedor(EntityTypeBuilder<Empreendedor> obj)
        {
            obj.HasKey(x => x.Id);
            
        }

        private void ConfigureIncentivador(EntityTypeBuilder<Incentivador> obj)
        {
            obj.HasKey(x => x.Id);
        }
    }
}
