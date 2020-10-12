using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace hacka_getnet.Migrations
{
    public partial class Add_Fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SolicitacaoCreditoId",
                table: "CobrancaRecorrente",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PagamentoIncentivadorPIX",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IncentivadorId = table.Column<int>(nullable: false),
                    Valor = table.Column<decimal>(nullable: false),
                    ChavePixOrigem = table.Column<string>(nullable: true),
                    ChavePixDestino = table.Column<string>(nullable: true),
                    IdTransacaoPIX = table.Column<string>(nullable: true),
                    DataPagamento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagamentoIncentivadorPIX", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PagamentoIncentivadorPIX_Incentivador_IncentivadorId",
                        column: x => x.IncentivadorId,
                        principalTable: "Incentivador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CobrancaRecorrente_SolicitacaoCreditoId",
                table: "CobrancaRecorrente",
                column: "SolicitacaoCreditoId");

            migrationBuilder.CreateIndex(
                name: "IX_PagamentoIncentivadorPIX_IncentivadorId",
                table: "PagamentoIncentivadorPIX",
                column: "IncentivadorId");

            migrationBuilder.AddForeignKey(
                name: "FK_CobrancaRecorrente_SolicitacaoCredito_SolicitacaoCreditoId",
                table: "CobrancaRecorrente",
                column: "SolicitacaoCreditoId",
                principalTable: "SolicitacaoCredito",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CobrancaRecorrente_SolicitacaoCredito_SolicitacaoCreditoId",
                table: "CobrancaRecorrente");

            migrationBuilder.DropTable(
                name: "PagamentoIncentivadorPIX");

            migrationBuilder.DropIndex(
                name: "IX_CobrancaRecorrente_SolicitacaoCreditoId",
                table: "CobrancaRecorrente");

            migrationBuilder.DropColumn(
                name: "SolicitacaoCreditoId",
                table: "CobrancaRecorrente");
        }
    }
}
