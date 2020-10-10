using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace hacka_getnet.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empreendedor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(nullable: true),
                    ChavePix = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empreendedor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Incentivador",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(nullable: true),
                    ChavePix = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incentivador", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SolicitacaoCredito",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EmpreendedorId = table.Column<int>(nullable: false),
                    Motivo = table.Column<string>(nullable: true),
                    Valor = table.Column<decimal>(nullable: false),
                    DataSolicitacao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolicitacaoCredito", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SolicitacaoCredito_Empreendedor_EmpreendedorId",
                        column: x => x.EmpreendedorId,
                        principalTable: "Empreendedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SolicitacaoCredito_EmpreendedorId",
                table: "SolicitacaoCredito",
                column: "EmpreendedorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Incentivador");

            migrationBuilder.DropTable(
                name: "SolicitacaoCredito");

            migrationBuilder.DropTable(
                name: "Empreendedor");
        }
    }
}
