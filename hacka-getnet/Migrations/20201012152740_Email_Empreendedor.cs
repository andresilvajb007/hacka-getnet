using Microsoft.EntityFrameworkCore.Migrations;

namespace hacka_getnet.Migrations
{
    public partial class Email_Empreendedor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Empreendedor",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Empreendedor");
        }
    }
}
