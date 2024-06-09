using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjAndreVeiculosV3_Endereco.Migrations
{
    public partial class FourMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Localicade",
                table: "Endereco",
                newName: "Localidade");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Localidade",
                table: "Endereco",
                newName: "Localicade");
        }
    }
}
