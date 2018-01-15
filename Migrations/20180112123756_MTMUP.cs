using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EasyGrow.Migrations
{
    public partial class MTMUP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Geolocations_GeolocationID",
                table: "AspNetUsers");

           // migrationBuilder.DropTable(
             //   name: "Users");

            migrationBuilder.RenameColumn(
                name: "GeolocationID",
                table: "AspNetUsers",
                newName: "GeolocationId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_GeolocationID",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_GeolocationId");

            migrationBuilder.CreateTable(
                name: "UserPlants",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    PlantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPlants", x => new { x.UserId, x.PlantId });
                    table.ForeignKey(
                        name: "FK_UserPlants_Plants_PlantId",
                        column: x => x.PlantId,
                        principalTable: "Plants",
                        principalColumn: "PlantId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserPlants_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserPlants_PlantId",
                table: "UserPlants",
                column: "PlantId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Geolocations_GeolocationId",
                table: "AspNetUsers",
                column: "GeolocationId",
                principalTable: "Geolocations",
                principalColumn: "GeolocationId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Geolocations_GeolocationId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "UserPlants");

            migrationBuilder.RenameColumn(
                name: "GeolocationId",
                table: "AspNetUsers",
                newName: "GeolocationID");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_GeolocationId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_GeolocationID");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Login = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Geolocations_GeolocationID",
                table: "AspNetUsers",
                column: "GeolocationID",
                principalTable: "Geolocations",
                principalColumn: "GeolocationId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
