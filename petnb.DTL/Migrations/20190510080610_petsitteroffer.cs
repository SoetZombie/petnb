using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace petnb.DTL.Migrations
{
    public partial class petsitteroffer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Breed",
                table: "Pets",
                newName: "PetBreed");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "AspNetUsers",
                newName: "Address");

            migrationBuilder.AlterColumn<decimal>(
                name: "Reward",
                table: "PetOffers",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AddColumn<string>(
                name: "PetLocation",
                table: "PetOffers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PetNeeds",
                table: "PetOffers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "PetOffers",
                nullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Rating",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateTable(
                name: "PetSitterOffer",
                columns: table => new
                {
                    PetSitterOfferId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Heading = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    StartOfSit = table.Column<DateTime>(nullable: false),
                    EndOfSit = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    ExpectedSalary = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetSitterOffer", x => x.PetSitterOfferId);
                    table.ForeignKey(
                        name: "FK_PetSitterOffer_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    ReviewId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ReviewedApplicationUserId = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    ReviewingApplicationUserId = table.Column<int>(nullable: false),
                    Heading = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    Rating = table.Column<double>(nullable: false),
                    DateGiven = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_Review_AspNetUsers_ReviewedApplicationUserId",
                        column: x => x.ReviewedApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PetOffers_UserId",
                table: "PetOffers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PetSitterOffer_UserId",
                table: "PetSitterOffer",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_ReviewedApplicationUserId",
                table: "Review",
                column: "ReviewedApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PetOffers_AspNetUsers_UserId",
                table: "PetOffers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PetOffers_AspNetUsers_UserId",
                table: "PetOffers");

            migrationBuilder.DropTable(
                name: "PetSitterOffer");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropIndex(
                name: "IX_PetOffers_UserId",
                table: "PetOffers");

            migrationBuilder.DropColumn(
                name: "PetLocation",
                table: "PetOffers");

            migrationBuilder.DropColumn(
                name: "PetNeeds",
                table: "PetOffers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PetOffers");

            migrationBuilder.RenameColumn(
                name: "PetBreed",
                table: "Pets",
                newName: "Breed");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "AspNetUsers",
                newName: "Adress");

            migrationBuilder.AlterColumn<decimal>(
                name: "Reward",
                table: "PetOffers",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Rating",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
