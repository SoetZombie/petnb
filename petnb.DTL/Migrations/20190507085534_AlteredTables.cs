using Microsoft.EntityFrameworkCore.Migrations;

namespace petnb.DTL.Migrations
{
    public partial class AlteredTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Breed",
                table: "Pets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "AspNetUsers",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPetSitter",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "AspNetUsers",
                nullable: true,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Breed",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "Adress",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsPetSitter",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "AspNetUsers");
        }
    }
}
