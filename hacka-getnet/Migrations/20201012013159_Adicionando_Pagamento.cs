using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace hacka_getnet.Migrations
{
    public partial class Adicionando_Pagamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusSolicitacaoCredito",
                table: "SolicitacaoCredito",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CobrancaRecorrente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EmpreendedorId = table.Column<int>(nullable: false),
                    Valor = table.Column<decimal>(nullable: false),
                    StatusCobrancaRecorrente = table.Column<int>(nullable: false),
                    DataCobranca = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CobrancaRecorrente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CobrancaRecorrente_Empreendedor_EmpreendedorId",
                        column: x => x.EmpreendedorId,
                        principalTable: "Empreendedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConfiguracaoApp",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ChavePixApp = table.Column<string>(nullable: true),
                    TaxaJurosACobrarDoEmpreendedor = table.Column<double>(nullable: false),
                    TaxaJurosAPagarAoIncentivador = table.Column<double>(nullable: false),
                    DataConfiguracao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfiguracaoApp", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PagamentoEmpreendedorPIX",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EmpreendedorId = table.Column<int>(nullable: false),
                    Valor = table.Column<decimal>(nullable: false),
                    ChavePixOrigem = table.Column<string>(nullable: true),
                    ChavePixDestino = table.Column<string>(nullable: true),
                    IdTransacaoPIX = table.Column<string>(nullable: true),
                    DataPagamento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagamentoEmpreendedorPIX", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PagamentoEmpreendedorPIX_Empreendedor_EmpreendedorId",
                        column: x => x.EmpreendedorId,
                        principalTable: "Empreendedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PagamentoSolicitacaoCreditoPIX",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SolicitacaoCreditoId = table.Column<int>(nullable: false),
                    Valor = table.Column<decimal>(nullable: false),
                    ChavePixOrigem = table.Column<string>(nullable: true),
                    ChavePixDestino = table.Column<string>(nullable: true),
                    IdTransacaoPIX = table.Column<string>(nullable: true),
                    StatusPagamento = table.Column<int>(nullable: false),
                    DataPagamento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagamentoSolicitacaoCreditoPIX", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PagamentoSolicitacaoCreditoPIX_SolicitacaoCredito_Solicitac~",
                        column: x => x.SolicitacaoCreditoId,
                        principalTable: "SolicitacaoCredito",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CobrancaRecorrente_EmpreendedorId",
                table: "CobrancaRecorrente",
                column: "EmpreendedorId");

            migrationBuilder.CreateIndex(
                name: "IX_PagamentoEmpreendedorPIX_EmpreendedorId",
                table: "PagamentoEmpreendedorPIX",
                column: "EmpreendedorId");

            migrationBuilder.CreateIndex(
                name: "IX_PagamentoSolicitacaoCreditoPIX_SolicitacaoCreditoId",
                table: "PagamentoSolicitacaoCreditoPIX",
                column: "SolicitacaoCreditoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CobrancaRecorrente");

            migrationBuilder.DropTable(
                name: "ConfiguracaoApp");

            migrationBuilder.DropTable(
                name: "PagamentoEmpreendedorPIX");

            migrationBuilder.DropTable(
                name: "PagamentoSolicitacaoCreditoPIX");

            migrationBuilder.DropColumn(
                name: "StatusSolicitacaoCredito",
                table: "SolicitacaoCredito");
        }
    }
}
