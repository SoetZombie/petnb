using Microsoft.EntityFrameworkCore.Migrations;

namespace petnb.DTL.Migrations
{
    public partial class petListIniti12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_AspNetUsers_ApplicationUserId",
                table: "Pets");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Pets",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Pets_ApplicationUserId",
                table: "Pets",
                newName: "IX_Pets_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_AspNetUsers_UserId",
                table: "Pets",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_AspNetUsers_UserId",
                table: "Pets");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Pets",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Pets_UserId",
                table: "Pets",
                newName: "IX_Pets_ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_AspNetUsers_ApplicationUserId",
                table: "Pets",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
