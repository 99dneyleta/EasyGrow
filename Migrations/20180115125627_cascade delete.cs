using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EasyGrow.Migrations
{
    public partial class cascadedelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhasePlant_Plants_PlantId",
                table: "PhasePlant");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPlants_Plants_PlantId",
                table: "UserPlants");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPlants_AspNetUsers_UserId",
                table: "UserPlants");

            migrationBuilder.AddForeignKey(
                name: "FK_PhasePlant_Plants_PlantId",
                table: "PhasePlant",
                column: "PlantId",
                principalTable: "Plants",
                principalColumn: "PlantId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPlants_Plants_PlantId",
                table: "UserPlants",
                column: "PlantId",
                principalTable: "Plants",
                principalColumn: "PlantId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPlants_AspNetUsers_UserId",
                table: "UserPlants",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhasePlant_Plants_PlantId",
                table: "PhasePlant");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPlants_Plants_PlantId",
                table: "UserPlants");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPlants_AspNetUsers_UserId",
                table: "UserPlants");

            migrationBuilder.AddForeignKey(
                name: "FK_PhasePlant_Plants_PlantId",
                table: "PhasePlant",
                column: "PlantId",
                principalTable: "Plants",
                principalColumn: "PlantId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPlants_Plants_PlantId",
                table: "UserPlants",
                column: "PlantId",
                principalTable: "Plants",
                principalColumn: "PlantId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPlants_AspNetUsers_UserId",
                table: "UserPlants",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
