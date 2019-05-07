using Microsoft.EntityFrameworkCore.Migrations;

namespace petnb.DTL.Migrations
{
    public partial class PetsRefference : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PetId",
                table: "PetOffers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PetOffers_PetId",
                table: "PetOffers",
                column: "PetId");

            migrationBuilder.AddForeignKey(
                name: "FK_PetOffers_Pets_PetId",
                table: "PetOffers",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "PetId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PetOffers_Pets_PetId",
                table: "PetOffers");

            migrationBuilder.DropIndex(
                name: "IX_PetOffers_PetId",
                table: "PetOffers");

            migrationBuilder.DropColumn(
                name: "PetId",
                table: "PetOffers");
        }
    }
}
