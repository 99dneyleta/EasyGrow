using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EasyGrow.Migrations
{
    public partial class OTMACGL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AdditinalCriteries_GroundwaterLevelId",
                table: "AdditinalCriteries");

            migrationBuilder.CreateIndex(
                name: "IX_AdditinalCriteries_GroundwaterLevelId",
                table: "AdditinalCriteries",
                column: "GroundwaterLevelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AdditinalCriteries_GroundwaterLevelId",
                table: "AdditinalCriteries");

            migrationBuilder.CreateIndex(
                name: "IX_AdditinalCriteries_GroundwaterLevelId",
                table: "AdditinalCriteries",
                column: "GroundwaterLevelId",
                unique: true);
        }
    }
}
