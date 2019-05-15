using Microsoft.EntityFrameworkCore.Migrations;

namespace petnb.DTL.Migrations
{
    public partial class splitUsersToTwoTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PetSitterOffers_PetSitters_PetSitterId",
                table: "PetSitterOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_PetSitterOffers_AspNetUsers_UserId",
                table: "PetSitterOffers");

            migrationBuilder.DropIndex(
                name: "IX_PetSitterOffers_UserId",
                table: "PetSitterOffers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PetSitterOffers");

            migrationBuilder.AlterColumn<int>(
                name: "PetSitterId",
                table: "PetSitterOffers",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PetSitterOffers_PetSitters_PetSitterId",
                table: "PetSitterOffers",
                column: "PetSitterId",
                principalTable: "PetSitters",
                principalColumn: "PetSitterId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PetSitterOffers_PetSitters_PetSitterId",
                table: "PetSitterOffers");

            migrationBuilder.AlterColumn<int>(
                name: "PetSitterId",
                table: "PetSitterOffers",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "PetSitterOffers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PetSitterOffers_UserId",
                table: "PetSitterOffers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PetSitterOffers_PetSitters_PetSitterId",
                table: "PetSitterOffers",
                column: "PetSitterId",
                principalTable: "PetSitters",
                principalColumn: "PetSitterId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PetSitterOffers_AspNetUsers_UserId",
                table: "PetSitterOffers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
