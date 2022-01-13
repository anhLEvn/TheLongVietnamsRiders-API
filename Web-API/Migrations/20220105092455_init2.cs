using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_API.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TourPackages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameTour = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionTour = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItineraryUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriceTour = table.Column<float>(type: "real", nullable: false),
                    TimeTour = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourPackages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UlrImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TourPackageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_TourPackages_TourPackageId",
                        column: x => x.TourPackageId,
                        principalTable: "TourPackages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Images_TourPackageId",
                table: "Images",
                column: "TourPackageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "TourPackages");
        }
    }
}
