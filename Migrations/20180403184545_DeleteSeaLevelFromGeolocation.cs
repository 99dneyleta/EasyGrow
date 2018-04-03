using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EasyGrow.Migrations
{
    public partial class DeleteSeaLevelFromGeolocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SeaLevel",
                table: "Geolocations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SeaLevel",
                table: "Geolocations",
                nullable: true);
        }
    }
}
