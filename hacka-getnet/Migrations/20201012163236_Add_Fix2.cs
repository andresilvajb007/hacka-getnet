using Microsoft.EntityFrameworkCore.Migrations;

namespace hacka_getnet.Migrations
{
    public partial class Add_Fix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IncentivadorId",
                table: "PagamentoSolicitacaoCreditoPIX",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_PagamentoSolicitacaoCreditoPIX_Incentivador_SolicitacaoCred~",
                table: "PagamentoSolicitacaoCreditoPIX",
                column: "SolicitacaoCreditoId",
                principalTable: "Incentivador",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PagamentoSolicitacaoCreditoPIX_Incentivador_SolicitacaoCred~",
                table: "PagamentoSolicitacaoCreditoPIX");

            migrationBuilder.DropColumn(
                name: "IncentivadorId",
                table: "PagamentoSolicitacaoCreditoPIX");
        }
    }
}
