using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VendasWebMvc.Migrations
{
    public partial class OutrasEntidades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vendedor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    DataDeNascimento = table.Column<DateTime>(nullable: false),
                    SalarioBase = table.Column<double>(nullable: false),
                    departamentoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendedor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vendedor_Departamento_departamentoId",
                        column: x => x.departamentoId,
                        principalTable: "Departamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "registroDeVendas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<DateTime>(nullable: false),
                    Quantidade = table.Column<double>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    vendedorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_registroDeVendas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_registroDeVendas_Vendedor_vendedorId",
                        column: x => x.vendedorId,
                        principalTable: "Vendedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_registroDeVendas_vendedorId",
                table: "registroDeVendas",
                column: "vendedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendedor_departamentoId",
                table: "Vendedor",
                column: "departamentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "registroDeVendas");

            migrationBuilder.DropTable(
                name: "Vendedor");
        }
    }
}
