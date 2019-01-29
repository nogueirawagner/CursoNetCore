using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.Migrations
{
    public partial class AlterRelacionamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriaId1",
                table: "Evento",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Evento_CategoriaId1",
                table: "Evento",
                column: "CategoriaId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Evento_Categoria_CategoriaId1",
                table: "Evento",
                column: "CategoriaId1",
                principalTable: "Categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
