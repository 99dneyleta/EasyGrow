using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EasyGrow.Migrations
{
    public partial class FromGroundWaterLevelSetNameAsUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_GroundwaterLevels_Name",
                table: "GroundwaterLevels",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_GroundwaterLevels_Name",
                table: "GroundwaterLevels");
        }
    }
}
