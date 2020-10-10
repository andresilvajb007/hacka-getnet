using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace hacka_getnet.Migrations
{
    public partial class Adiciona_ComprovanteIncentivo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ComprovanteIncentivo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UrlImagem = table.Column<string>(nullable: true),
                    IncentivadorId = table.Column<int>(nullable: false),
                    SolicitacaoCreditoId = table.Column<int>(nullable: false),
                    DataUpload = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComprovanteIncentivo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComprovanteIncentivo_Incentivador_IncentivadorId",
                        column: x => x.IncentivadorId,
                        principalTable: "Incentivador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComprovanteIncentivo_SolicitacaoCredito_SolicitacaoCreditoId",
                        column: x => x.SolicitacaoCreditoId,
                        principalTable: "SolicitacaoCredito",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComprovanteIncentivo_IncentivadorId",
                table: "ComprovanteIncentivo",
                column: "IncentivadorId");

            migrationBuilder.CreateIndex(
                name: "IX_ComprovanteIncentivo_SolicitacaoCreditoId",
                table: "ComprovanteIncentivo",
                column: "SolicitacaoCreditoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComprovanteIncentivo");
        }
    }
}
