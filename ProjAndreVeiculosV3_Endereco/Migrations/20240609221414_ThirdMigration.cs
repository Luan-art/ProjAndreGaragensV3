using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjAndreVeiculosV3_Endereco.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cidade",
                table: "Endereco",
                newName: "Localicade");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Localicade",
                table: "Endereco",
                newName: "Cidade");
        }
    }
}
