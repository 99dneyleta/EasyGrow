using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EasyGrow.Migrations
{
    public partial class ForeignKeyFromACToPlant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    ClassId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.ClassId);
                });

            migrationBuilder.CreateTable(
                name: "Geolocations",
                columns: table => new
                {
                    GeolocationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Latitude = table.Column<string>(nullable: true),
                    Longitude = table.Column<string>(nullable: true),
                    SeaLevel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Geolocations", x => x.GeolocationId);
                });

            migrationBuilder.CreateTable(
                name: "GroundwaterLevels",
                columns: table => new
                {
                    GroundwaterLevelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroundwaterLevels", x => x.GroundwaterLevelId);
                });

            migrationBuilder.CreateTable(
                name: "Phases",
                columns: table => new
                {
                    PhaseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Duration = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phases", x => x.PhaseId);
                });

            migrationBuilder.CreateTable(
                name: "AdditinalCriteries",
                columns: table => new
                {
                    AdditinalCriteriesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AreaSawn = table.Column<float>(nullable: false),
                    GeolocationId = table.Column<int>(nullable: false),
                    GroundwaterLevelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditinalCriteries", x => x.AdditinalCriteriesId);
                    table.ForeignKey(
                        name: "FK_AdditinalCriteries_Geolocations_GeolocationId",
                        column: x => x.GeolocationId,
                        principalTable: "Geolocations",
                        principalColumn: "GeolocationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdditinalCriteries_GroundwaterLevels_GroundwaterLevelId",
                        column: x => x.GroundwaterLevelId,
                        principalTable: "GroundwaterLevels",
                        principalColumn: "GroundwaterLevelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Plants",
                columns: table => new
                {
                    PlantId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AdditinalCriteriesId = table.Column<int>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    AmountOfFertilizingDays = table.Column<int>(nullable: false),
                    AmountOfWater = table.Column<int>(nullable: false),
                    ClassId = table.Column<int>(nullable: false),
                    FrequencyOfWateringDays = table.Column<int>(nullable: false),
                    Info = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    PhaseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants", x => x.PlantId);
                    table.ForeignKey(
                        name: "FK_Plants_AdditinalCriteries_AdditinalCriteriesId",
                        column: x => x.AdditinalCriteriesId,
                        principalTable: "AdditinalCriteries",
                        principalColumn: "AdditinalCriteriesId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Plants_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Plants_Phases_PhaseId",
                        column: x => x.PhaseId,
                        principalTable: "Phases",
                        principalColumn: "PhaseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhasePlant",
                columns: table => new
                {
                    PlantId = table.Column<int>(nullable: false),
                    PhaseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhasePlant", x => new { x.PlantId, x.PhaseId });
                    table.ForeignKey(
                        name: "FK_PhasePlant_Phases_PhaseId",
                        column: x => x.PhaseId,
                        principalTable: "Phases",
                        principalColumn: "PhaseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhasePlant_Plants_PlantId",
                        column: x => x.PlantId,
                        principalTable: "Plants",
                        principalColumn: "PlantId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdditinalCriteries_GeolocationId",
                table: "AdditinalCriteries",
                column: "GeolocationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdditinalCriteries_GroundwaterLevelId",
                table: "AdditinalCriteries",
                column: "GroundwaterLevelId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhasePlant_PhaseId",
                table: "PhasePlant",
                column: "PhaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_AdditinalCriteriesId",
                table: "Plants",
                column: "AdditinalCriteriesId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Plants_ClassId",
                table: "Plants",
                column: "ClassId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Plants_PhaseId",
                table: "Plants",
                column: "PhaseId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhasePlant");

            migrationBuilder.DropTable(
                name: "Plants");

            migrationBuilder.DropTable(
                name: "AdditinalCriteries");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Phases");

            migrationBuilder.DropTable(
                name: "Geolocations");

            migrationBuilder.DropTable(
                name: "GroundwaterLevels");
        }
    }
}
