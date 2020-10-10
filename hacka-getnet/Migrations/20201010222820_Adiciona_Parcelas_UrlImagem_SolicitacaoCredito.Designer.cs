﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using hacka_getnet;

namespace hacka_getnet.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20201010222820_Adiciona_Parcelas_UrlImagem_SolicitacaoCredito")]
    partial class Adiciona_Parcelas_UrlImagem_SolicitacaoCredito
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

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

                    b.HasKey("Id");

                    b.HasIndex("IncentivadorId");

                    b.HasIndex("SolicitacaoCreditoId");

                    b.ToTable("ComprovanteIncentivo");
                });

            modelBuilder.Entity("hacka_getnet.Entidades.Empreendedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ChavePix")
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Empreendedor");
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

                    b.HasKey("Id");

                    b.ToTable("Incentivador");
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

                    b.Property<int>("QuantidadeParcelasReembolso")
                        .HasColumnType("integer");

                    b.Property<string>("UrlImagem")
                        .HasColumnType("text");

                    b.Property<decimal>("Valor")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("EmpreendedorId");

                    b.ToTable("SolicitacaoCredito");
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
