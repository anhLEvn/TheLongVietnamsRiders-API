using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_API.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_TourPackages_TourPackageId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_TourPackageId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "TourPackageId",
                table: "Images");

            migrationBuilder.CreateTable(
                name: "Tours",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameTour = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionTour = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItineraryFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PriceTour = table.Column<float>(type: "real", nullable: false),
                    LengthTour = table.Column<int>(type: "int", nullable: false),
                    MinParticipant = table.Column<int>(type: "int", nullable: false),
                    MaxParticipant = table.Column<int>(type: "int", nullable: false),
                    ImageFileName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tours", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tours");

            migrationBuilder.AddColumn<Guid>(
                name: "TourPackageId",
                table: "Images",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_TourPackageId",
                table: "Images",
                column: "TourPackageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_TourPackages_TourPackageId",
                table: "Images",
                column: "TourPackageId",
                principalTable: "TourPackages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
