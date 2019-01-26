using Microsoft.EntityFrameworkCore.Migrations;

namespace VendasWebMvc.Migrations
{
    public partial class DepartmentForeignkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendedor_Departamento_departamentoId",
                table: "Vendedor");

            migrationBuilder.RenameColumn(
                name: "departamentoId",
                table: "Vendedor",
                newName: "DepartamentoId");

            migrationBuilder.RenameIndex(
                name: "IX_Vendedor_departamentoId",
                table: "Vendedor",
                newName: "IX_Vendedor_DepartamentoId");

            migrationBuilder.AlterColumn<int>(
                name: "DepartamentoId",
                table: "Vendedor",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendedor_Departamento_DepartamentoId",
                table: "Vendedor",
                column: "DepartamentoId",
                principalTable: "Departamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendedor_Departamento_DepartamentoId",
                table: "Vendedor");

            migrationBuilder.RenameColumn(
                name: "DepartamentoId",
                table: "Vendedor",
                newName: "departamentoId");

            migrationBuilder.RenameIndex(
                name: "IX_Vendedor_DepartamentoId",
                table: "Vendedor",
                newName: "IX_Vendedor_departamentoId");

            migrationBuilder.AlterColumn<int>(
                name: "departamentoId",
                table: "Vendedor",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Vendedor_Departamento_departamentoId",
                table: "Vendedor",
                column: "departamentoId",
                principalTable: "Departamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
