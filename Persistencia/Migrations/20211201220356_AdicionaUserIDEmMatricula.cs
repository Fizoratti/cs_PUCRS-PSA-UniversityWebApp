using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistencia.Migrations
{
    public partial class AdicionaUserIDEmMatricula : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matricula_AspNetUsers_ApplicationUserId",
                table: "Matricula");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Matricula",
                newName: "ApplicationUserID");

            migrationBuilder.RenameIndex(
                name: "IX_Matricula_ApplicationUserId",
                table: "Matricula",
                newName: "IX_Matricula_ApplicationUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Matricula_AspNetUsers_ApplicationUserID",
                table: "Matricula",
                column: "ApplicationUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matricula_AspNetUsers_ApplicationUserID",
                table: "Matricula");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserID",
                table: "Matricula",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Matricula_ApplicationUserID",
                table: "Matricula",
                newName: "IX_Matricula_ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matricula_AspNetUsers_ApplicationUserId",
                table: "Matricula",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
