using Microsoft.EntityFrameworkCore.Migrations;

namespace hacka_getnet.Migrations
{
    public partial class Adiciona_Parcelas_UrlImagem_SolicitacaoCredito : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuantidadeParcelasReembolso",
                table: "SolicitacaoCredito",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UrlImagem",
                table: "SolicitacaoCredito",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuantidadeParcelasReembolso",
                table: "SolicitacaoCredito");

            migrationBuilder.DropColumn(
                name: "UrlImagem",
                table: "SolicitacaoCredito");
        }
    }
}
