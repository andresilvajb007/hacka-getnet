using Microsoft.EntityFrameworkCore.Migrations;

namespace hacka_getnet.Migrations
{
    public partial class Alteracoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NomeNegocio",
                table: "SolicitacaoCredito",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Valor",
                table: "ComprovanteIncentivo",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomeNegocio",
                table: "SolicitacaoCredito");

            migrationBuilder.DropColumn(
                name: "Valor",
                table: "ComprovanteIncentivo");
        }
    }
}
