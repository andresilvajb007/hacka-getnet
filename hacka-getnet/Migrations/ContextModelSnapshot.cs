﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using hacka_getnet;

namespace hacka_getnet.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("hacka_getnet.Entidades.CartaoEmpreendedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("AnoVencimento")
                        .HasColumnType("text");

                    b.Property<string>("Bandeira")
                        .HasColumnType("text");

                    b.Property<string>("CVV")
                        .HasColumnType("text");

                    b.Property<int>("EmpreendedorId")
                        .HasColumnType("integer");

                    b.Property<string>("MesVencimento")
                        .HasColumnType("text");

                    b.Property<string>("NomePortador")
                        .HasColumnType("text");

                    b.Property<string>("NumeroCartao")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("EmpreendedorId")
                        .IsUnique();

                    b.ToTable("CartaoEmpreendedor");
                });

            modelBuilder.Entity("hacka_getnet.Entidades.CobrancaRecorrente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DataCobranca")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("EmpreendedorId")
                        .HasColumnType("integer");

                    b.Property<int>("SolicitacaoCreditoId")
                        .HasColumnType("integer");

                    b.Property<int>("StatusCobrancaRecorrente")
                        .HasColumnType("integer");

                    b.Property<decimal>("Valor")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("EmpreendedorId");

                    b.HasIndex("SolicitacaoCreditoId");

                    b.ToTable("CobrancaRecorrente");
                });

            modelBuilder.Entity("hacka_getnet.Entidades.ComprovanteIncentivo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DataUpload")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("IncentivadorId")
                        .HasColumnType("integer");

                    b.Property<int>("SolicitacaoCreditoId")
                        .HasColumnType("integer");

                    b.Property<string>("UrlImagem")
                        .HasColumnType("text");

                    b.Property<decimal>("Valor")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("IncentivadorId");

                    b.HasIndex("SolicitacaoCreditoId");

                    b.ToTable("ComprovanteIncentivo");
                });

            modelBuilder.Entity("hacka_getnet.Entidades.ConfiguracaoApp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ChavePixApp")
                        .HasColumnType("text");

                    b.Property<DateTime>("DataConfiguracao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("GetNetId")
                        .HasColumnType("text");

                    b.Property<double>("TaxaJurosACobrarDoEmpreendedor")
                        .HasColumnType("double precision");

                    b.Property<double>("TaxaJurosAPagarAoIncentivador")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("ConfiguracaoApp");
                });

            modelBuilder.Entity("hacka_getnet.Entidades.Empreendedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CNPJ")
                        .HasColumnType("text");

                    b.Property<string>("Celular")
                        .HasColumnType("text");

                    b.Property<string>("ChavePix")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.Property<string>("PrimeiroNome")
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .HasColumnType("text");

                    b.Property<string>("Senha")
                        .HasColumnType("text");

                    b.Property<string>("UltimoNome")
                        .HasColumnType("text");

                    b.Property<string>("Usuario")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Empreendedor");
                });

            modelBuilder.Entity("hacka_getnet.Entidades.EnderecoEmpreendedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Bairro")
                        .HasColumnType("text");

                    b.Property<string>("CEP")
                        .HasColumnType("text");

                    b.Property<string>("Cidade")
                        .HasColumnType("text");

                    b.Property<string>("Complemento")
                        .HasColumnType("text");

                    b.Property<int>("EmpreendedorId")
                        .HasColumnType("integer");

                    b.Property<string>("Logradouro")
                        .HasColumnType("text");

                    b.Property<string>("Numero")
                        .HasColumnType("text");

                    b.Property<string>("Pais")
                        .HasColumnType("text");

                    b.Property<string>("SiglaEstado")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("EmpreendedorId")
                        .IsUnique();

                    b.ToTable("EnderecoEmpreendedor");
                });

            modelBuilder.Entity("hacka_getnet.Entidades.Incentivador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ChavePix")
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .HasColumnType("text");

                    b.Property<string>("Senha")
                        .HasColumnType("text");

                    b.Property<string>("Usuario")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Incentivador");
                });

            modelBuilder.Entity("hacka_getnet.Entidades.PagamentoEmpreendedorPIX", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ChavePixDestino")
                        .HasColumnType("text");

                    b.Property<string>("ChavePixOrigem")
                        .HasColumnType("text");

                    b.Property<DateTime>("DataPagamento")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("EmpreendedorId")
                        .HasColumnType("integer");

                    b.Property<string>("IdTransacaoPIX")
                        .HasColumnType("text");

                    b.Property<decimal>("Valor")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("EmpreendedorId");

                    b.ToTable("PagamentoEmpreendedorPIX");
                });

            modelBuilder.Entity("hacka_getnet.Entidades.PagamentoIncentivadorPIX", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ChavePixDestino")
                        .HasColumnType("text");

                    b.Property<string>("ChavePixOrigem")
                        .HasColumnType("text");

                    b.Property<DateTime>("DataPagamento")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("IdTransacaoPIX")
                        .HasColumnType("text");

                    b.Property<int>("IncentivadorId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Valor")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("IncentivadorId");

                    b.ToTable("PagamentoIncentivadorPIX");
                });

            modelBuilder.Entity("hacka_getnet.Entidades.PagamentoSolicitacaoCreditoPIX", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ChavePixDestino")
                        .HasColumnType("text");

                    b.Property<string>("ChavePixOrigem")
                        .HasColumnType("text");

                    b.Property<DateTime>("DataPagamento")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("IdTransacaoPIX")
                        .HasColumnType("text");

                    b.Property<int>("IncentivadorId")
                        .HasColumnType("integer");

                    b.Property<int>("SolicitacaoCreditoId")
                        .HasColumnType("integer");

                    b.Property<int>("StatusPagamento")
                        .HasColumnType("integer");

                    b.Property<decimal>("Valor")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("SolicitacaoCreditoId");

                    b.ToTable("PagamentoSolicitacaoCreditoPIX");
                });

            modelBuilder.Entity("hacka_getnet.Entidades.SolicitacaoCredito", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DataSolicitacao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("EmpreendedorId")
                        .HasColumnType("integer");

                    b.Property<string>("Motivo")
                        .HasColumnType("text");

                    b.Property<string>("NomeNegocio")
                        .HasColumnType("text");

                    b.Property<int>("QuantidadeParcelasReembolso")
                        .HasColumnType("integer");

                    b.Property<int>("StatusSolicitacaoCredito")
                        .HasColumnType("integer");

                    b.Property<string>("UrlImagem")
                        .HasColumnType("text");

                    b.Property<decimal>("Valor")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("EmpreendedorId");

                    b.ToTable("SolicitacaoCredito");
                });

            modelBuilder.Entity("hacka_getnet.Entidades.CartaoEmpreendedor", b =>
                {
                    b.HasOne("hacka_getnet.Entidades.Empreendedor", "Empreendedor")
                        .WithOne("Cartao")
                        .HasForeignKey("hacka_getnet.Entidades.CartaoEmpreendedor", "EmpreendedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("hacka_getnet.Entidades.CobrancaRecorrente", b =>
                {
                    b.HasOne("hacka_getnet.Entidades.Empreendedor", "Empreendedor")
                        .WithMany("Cobrancas")
                        .HasForeignKey("EmpreendedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("hacka_getnet.Entidades.SolicitacaoCredito", "SolicitacaoCredito")
                        .WithMany("Cobrancas")
                        .HasForeignKey("SolicitacaoCreditoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("hacka_getnet.Entidades.ComprovanteIncentivo", b =>
                {
                    b.HasOne("hacka_getnet.Entidades.Incentivador", "Incentivador")
                        .WithMany("ComprovanteIncentivo")
                        .HasForeignKey("IncentivadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("hacka_getnet.Entidades.SolicitacaoCredito", "SolicitacaoCredito")
                        .WithMany("ComprovanteIncentivo")
                        .HasForeignKey("SolicitacaoCreditoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("hacka_getnet.Entidades.EnderecoEmpreendedor", b =>
                {
                    b.HasOne("hacka_getnet.Entidades.Empreendedor", "Empreendedor")
                        .WithOne("Endereco")
                        .HasForeignKey("hacka_getnet.Entidades.EnderecoEmpreendedor", "EmpreendedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("hacka_getnet.Entidades.PagamentoEmpreendedorPIX", b =>
                {
                    b.HasOne("hacka_getnet.Entidades.Empreendedor", "Empreendedor")
                        .WithMany("PagamentosRecebidos")
                        .HasForeignKey("EmpreendedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("hacka_getnet.Entidades.PagamentoIncentivadorPIX", b =>
                {
                    b.HasOne("hacka_getnet.Entidades.Incentivador", "Incentivador")
                        .WithMany("Pagamentos")
                        .HasForeignKey("IncentivadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("hacka_getnet.Entidades.PagamentoSolicitacaoCreditoPIX", b =>
                {
                    b.HasOne("hacka_getnet.Entidades.Incentivador", "Incentivador")
                        .WithMany("PagamentosSolicitacao")
                        .HasForeignKey("SolicitacaoCreditoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("hacka_getnet.Entidades.SolicitacaoCredito", "SolicitacaoCredito")
                        .WithMany("Pagamentos")
                        .HasForeignKey("SolicitacaoCreditoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("hacka_getnet.Entidades.SolicitacaoCredito", b =>
                {
                    b.HasOne("hacka_getnet.Entidades.Empreendedor", "Empreendedor")
                        .WithMany("SolicitacoesCredito")
                        .HasForeignKey("EmpreendedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
