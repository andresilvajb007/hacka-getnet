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
        public DbSet<EnderecoEmpreendedor> EnderecoEmpreendedor { get; set; }
        public DbSet<CartaoEmpreendedor> CartaoEmpreendedor { get; set; }
        public DbSet<SolicitacaoCredito> SolicitacaoCredito { get; set; }
        public DbSet<ComprovanteIncentivo> ComprovanteIncentivo { get; set; }
        public DbSet<PagamentoEmpreendedorPIX> PagamentoEmpreendedorPIX { get; set; }
        public DbSet<PagamentoSolicitacaoCreditoPIX> PagamentoSolicitacaoCreditoPIX { get; set; }
        public DbSet<CobrancaRecorrente> CobrancaRecorrente { get; set; }
        public DbSet<ConfiguracaoApp> ConfiguracaoApp { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Incentivador>(ConfigureIncentivador);
            modelBuilder.Entity<Empreendedor>(ConfigureEmpreendedor);
            modelBuilder.Entity<EnderecoEmpreendedor>(ConfigureEnderecoEmpreendedor);
            modelBuilder.Entity<CartaoEmpreendedor>(ConfigureCartaoEmpreendedor);
            modelBuilder.Entity<SolicitacaoCredito>(ConfigureSolicitacaoCredito);
            modelBuilder.Entity<ComprovanteIncentivo>(ConfigureComprovanteIncentivo);
            modelBuilder.Entity<PagamentoEmpreendedorPIX>(ConfigurePagamentoEmpreendedorPIX);
            modelBuilder.Entity<PagamentoSolicitacaoCreditoPIX>(ConfigurePagamentoSolicitacaoCreditoPIX);
            modelBuilder.Entity<CobrancaRecorrente>(ConfigureCobrancaRecorrente);
            modelBuilder.Entity<ConfiguracaoApp>(ConfigureConfiguracaoApp);
        }


        private void ConfigureCartaoEmpreendedor(EntityTypeBuilder<CartaoEmpreendedor> obj)
        {
            obj.HasKey(x => x.Id);
        }

        private void ConfigureEnderecoEmpreendedor(EntityTypeBuilder<EnderecoEmpreendedor> obj)
        {
            obj.HasKey(x => x.Id);
        }

        private void ConfigureConfiguracaoApp(EntityTypeBuilder<ConfiguracaoApp> obj)
        {
            obj.HasKey(x => x.Id);
        }

        private void ConfigureCobrancaRecorrente(EntityTypeBuilder<CobrancaRecorrente> obj)
        {
            obj.HasKey(x => x.Id);

            obj.HasOne(x => x.Empreendedor)
                .WithMany(x => x.Cobrancas)
                .HasForeignKey(x => x.EmpreendedorId);
        }

        private void ConfigurePagamentoSolicitacaoCreditoPIX(EntityTypeBuilder<PagamentoSolicitacaoCreditoPIX> obj)
        {
            obj.HasKey(x => x.Id);

            obj.HasOne(x => x.SolicitacaoCredito)
                .WithMany(x => x.Pagamentos)
                .HasForeignKey(x => x.SolicitacaoCreditoId);
        }

        private void ConfigurePagamentoEmpreendedorPIX(EntityTypeBuilder<PagamentoEmpreendedorPIX> obj)
        {
            obj.HasKey(x => x.Id);

            obj.HasOne(x => x.Empreendedor)
                .WithMany(x => x.PagamentosRecebidos)
                .HasForeignKey(x => x.EmpreendedorId);
        }

        private void ConfigureComprovanteIncentivo(EntityTypeBuilder<ComprovanteIncentivo> obj)
        {
            obj.HasKey(x => x.Id);

            obj.HasOne(x => x.Incentivador)
                .WithMany(x => x.ComprovanteIncentivo)
                .HasForeignKey(x => x.IncentivadorId);

            obj.HasOne(x => x.SolicitacaoCredito)
                .WithMany(x => x.ComprovanteIncentivo)
                .HasForeignKey(x => x.SolicitacaoCreditoId);


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

            obj
              .HasOne(a => a.Endereco)
              .WithOne(b => b.Empreendedor)
              .HasForeignKey<EnderecoEmpreendedor>(b => b.EmpreendedorId);

            obj
              .HasOne(a => a.Cartao)
              .WithOne(b => b.Empreendedor)
              .HasForeignKey<CartaoEmpreendedor>(b => b.EmpreendedorId);

        }

        private void ConfigureIncentivador(EntityTypeBuilder<Incentivador> obj)
        {
            obj.HasKey(x => x.Id);
        }
    }
}
