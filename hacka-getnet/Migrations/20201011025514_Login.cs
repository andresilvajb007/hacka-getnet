using Microsoft.EntityFrameworkCore.Migrations;

namespace hacka_getnet.Migrations
{
    public partial class Login : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Incentivador",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Senha",
                table: "Incentivador",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Usuario",
                table: "Incentivador",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Empreendedor",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Senha",
                table: "Empreendedor",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Usuario",
                table: "Empreendedor",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Incentivador");

            migrationBuilder.DropColumn(
                name: "Senha",
                table: "Incentivador");

            migrationBuilder.DropColumn(
                name: "Usuario",
                table: "Incentivador");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Empreendedor");

            migrationBuilder.DropColumn(
                name: "Senha",
                table: "Empreendedor");

            migrationBuilder.DropColumn(
                name: "Usuario",
                table: "Empreendedor");
        }
    }
}
