using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class fixEliminocamporeferencia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Usuarios_UsuariosId",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_UsuariosId",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "UsuariosId",
                table: "Productos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuariosId",
                table: "Productos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Productos_UsuariosId",
                table: "Productos",
                column: "UsuariosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Usuarios_UsuariosId",
                table: "Productos",
                column: "UsuariosId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }
    }
}
