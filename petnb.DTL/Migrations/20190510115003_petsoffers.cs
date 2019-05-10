using Microsoft.EntityFrameworkCore.Migrations;

namespace petnb.DTL.Migrations
{
    public partial class petsoffers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PetSitterOffer_AspNetUsers_UserId",
                table: "PetSitterOffer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PetSitterOffer",
                table: "PetSitterOffer");

            migrationBuilder.RenameTable(
                name: "PetSitterOffer",
                newName: "PetSitterOffers");

            migrationBuilder.RenameIndex(
                name: "IX_PetSitterOffer_UserId",
                table: "PetSitterOffers",
                newName: "IX_PetSitterOffers_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PetSitterOffers",
                table: "PetSitterOffers",
                column: "PetSitterOfferId");

            migrationBuilder.AddForeignKey(
                name: "FK_PetSitterOffers_AspNetUsers_UserId",
                table: "PetSitterOffers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PetSitterOffers_AspNetUsers_UserId",
                table: "PetSitterOffers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PetSitterOffers",
                table: "PetSitterOffers");

            migrationBuilder.RenameTable(
                name: "PetSitterOffers",
                newName: "PetSitterOffer");

            migrationBuilder.RenameIndex(
                name: "IX_PetSitterOffers_UserId",
                table: "PetSitterOffer",
                newName: "IX_PetSitterOffer_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PetSitterOffer",
                table: "PetSitterOffer",
                column: "PetSitterOfferId");

            migrationBuilder.AddForeignKey(
                name: "FK_PetSitterOffer_AspNetUsers_UserId",
                table: "PetSitterOffer",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
