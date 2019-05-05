using Microsoft.EntityFrameworkCore.Migrations;

namespace petnb.DTL.Migrations
{
    public partial class petList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Pets",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pets_ApplicationUserId",
                table: "Pets",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_AspNetUsers_ApplicationUserId",
                table: "Pets",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_AspNetUsers_ApplicationUserId",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_ApplicationUserId",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Pets");
        }
    }
}
