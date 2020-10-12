using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace hacka_getnet.Migrations
{
    public partial class Adiciona_dados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CNPJ",
                table: "Empreendedor",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Celular",
                table: "Empreendedor",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrimeiroNome",
                table: "Empreendedor",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UltimoNome",
                table: "Empreendedor",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CartaoEmpreendedor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EmpreendedorId = table.Column<int>(nullable: false),
                    NomePortador = table.Column<string>(nullable: true),
                    NumeroCartao = table.Column<string>(nullable: true),
                    MesVencimento = table.Column<string>(nullable: true),
                    AnoVencimento = table.Column<string>(nullable: true),
                    CVV = table.Column<string>(nullable: true),
                    Bandeira = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartaoEmpreendedor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartaoEmpreendedor_Empreendedor_EmpreendedorId",
                        column: x => x.EmpreendedorId,
                        principalTable: "Empreendedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnderecoEmpreendedor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EmpreendedorId = table.Column<int>(nullable: false),
                    Logradouro = table.Column<string>(nullable: true),
                    Numero = table.Column<string>(nullable: true),
                    Complemento = table.Column<string>(nullable: true),
                    SiglaEstado = table.Column<string>(nullable: true),
                    Cidade = table.Column<string>(nullable: true),
                    Pais = table.Column<string>(nullable: true),
                    CEP = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnderecoEmpreendedor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnderecoEmpreendedor_Empreendedor_EmpreendedorId",
                        column: x => x.EmpreendedorId,
                        principalTable: "Empreendedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartaoEmpreendedor_EmpreendedorId",
                table: "CartaoEmpreendedor",
                column: "EmpreendedorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EnderecoEmpreendedor_EmpreendedorId",
                table: "EnderecoEmpreendedor",
                column: "EmpreendedorId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartaoEmpreendedor");

            migrationBuilder.DropTable(
                name: "EnderecoEmpreendedor");

            migrationBuilder.DropColumn(
                name: "CNPJ",
                table: "Empreendedor");

            migrationBuilder.DropColumn(
                name: "Celular",
                table: "Empreendedor");

            migrationBuilder.DropColumn(
                name: "PrimeiroNome",
                table: "Empreendedor");

            migrationBuilder.DropColumn(
                name: "UltimoNome",
                table: "Empreendedor");
        }
    }
}
