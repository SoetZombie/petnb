using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace petnb.DTL.Migrations
{
    public partial class petsitteradd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPetSitter",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "PetSitterId",
                table: "PetSitterOffers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PetSitters",
                columns: table => new
                {
                    PetSitterId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Rating = table.Column<double>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetSitters", x => x.PetSitterId);
                    table.ForeignKey(
                        name: "FK_PetSitters_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PetSitterOffers_PetSitterId",
                table: "PetSitterOffers",
                column: "PetSitterId");

            migrationBuilder.CreateIndex(
                name: "IX_PetSitters_UserId",
                table: "PetSitters",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_PetSitterOffers_PetSitters_PetSitterId",
                table: "PetSitterOffers",
                column: "PetSitterId",
                principalTable: "PetSitters",
                principalColumn: "PetSitterId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PetSitterOffers_PetSitters_PetSitterId",
                table: "PetSitterOffers");

            migrationBuilder.DropTable(
                name: "PetSitters");

            migrationBuilder.DropIndex(
                name: "IX_PetSitterOffers_PetSitterId",
                table: "PetSitterOffers");

            migrationBuilder.DropColumn(
                name: "PetSitterId",
                table: "PetSitterOffers");

            migrationBuilder.AddColumn<bool>(
                name: "IsPetSitter",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);
        }
    }
}
