using Microsoft.EntityFrameworkCore.Migrations;

namespace petnb.DTL.Migrations
{
    public partial class petTypeAlterationMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PetSitterOfferPetTypeModel_PetType_PetTypeId",
                table: "PetSitterOfferPetTypeModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PetType",
                table: "PetType");

            migrationBuilder.RenameTable(
                name: "PetType",
                newName: "PetTypes");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "PetSitterOffers",
                newName: "SalaryExplanation");

            migrationBuilder.AddColumn<int>(
                name: "AvailableToDrive",
                table: "PetSitterOffers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ZipCode",
                table: "PetSitterOffers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PetTypes",
                table: "PetTypes",
                column: "PetTypeId");

            migrationBuilder.InsertData(
                table: "PetTypes",
                columns: new[] { "PetTypeId", "PetTypeEnum" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 },
                    { 6, 6 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_PetSitterOfferPetTypeModel_PetTypes_PetTypeId",
                table: "PetSitterOfferPetTypeModel",
                column: "PetTypeId",
                principalTable: "PetTypes",
                principalColumn: "PetTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PetSitterOfferPetTypeModel_PetTypes_PetTypeId",
                table: "PetSitterOfferPetTypeModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PetTypes",
                table: "PetTypes");

            migrationBuilder.DeleteData(
                table: "PetTypes",
                keyColumn: "PetTypeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PetTypes",
                keyColumn: "PetTypeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PetTypes",
                keyColumn: "PetTypeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PetTypes",
                keyColumn: "PetTypeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PetTypes",
                keyColumn: "PetTypeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PetTypes",
                keyColumn: "PetTypeId",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "AvailableToDrive",
                table: "PetSitterOffers");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "PetSitterOffers");

            migrationBuilder.RenameTable(
                name: "PetTypes",
                newName: "PetType");

            migrationBuilder.RenameColumn(
                name: "SalaryExplanation",
                table: "PetSitterOffers",
                newName: "Location");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PetType",
                table: "PetType",
                column: "PetTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_PetSitterOfferPetTypeModel_PetType_PetTypeId",
                table: "PetSitterOfferPetTypeModel",
                column: "PetTypeId",
                principalTable: "PetType",
                principalColumn: "PetTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
