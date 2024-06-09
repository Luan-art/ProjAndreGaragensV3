using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjAndreVeiculosV3_Venda.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vendas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarroPlaca = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DataVenda = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorVenda = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ClienteDocumento = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FuncionarioDocumento = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PagamentoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vendas_Carro_CarroPlaca",
                        column: x => x.CarroPlaca,
                        principalTable: "Carro",
                        principalColumn: "Placa");
                    table.ForeignKey(
                        name: "FK_Vendas_Pagamento_PagamentoId",
                        column: x => x.PagamentoId,
                        principalTable: "Pagamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vendas_Pessoas_ClienteDocumento",
                        column: x => x.ClienteDocumento,
                        principalTable: "Pessoas",
                        principalColumn: "Documento");
                    table.ForeignKey(
                        name: "FK_Vendas_Pessoas_FuncionarioDocumento",
                        column: x => x.FuncionarioDocumento,
                        principalTable: "Pessoas",
                        principalColumn: "Documento");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_CarroPlaca",
                table: "Vendas",
                column: "CarroPlaca");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_ClienteDocumento",
                table: "Vendas",
                column: "ClienteDocumento");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_FuncionarioDocumento",
                table: "Vendas",
                column: "FuncionarioDocumento");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_PagamentoId",
                table: "Vendas",
                column: "PagamentoId");
        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vendas");

        }
    }
}
