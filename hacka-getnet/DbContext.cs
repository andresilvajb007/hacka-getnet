using System;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Incentivador>(ConfigureIncentivador);
            modelBuilder.Entity<Empreendedor>(ConfigureEmpreendedor);

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
