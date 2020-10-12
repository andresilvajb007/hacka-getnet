using Microsoft.EntityFrameworkCore.Migrations;

namespace hacka_getnet.Migrations
{
    public partial class Adiciona_Bairro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "EnderecoEmpreendedor",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "EnderecoEmpreendedor");
        }
    }
}
