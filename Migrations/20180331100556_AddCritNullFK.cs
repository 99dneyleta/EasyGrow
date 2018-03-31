using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EasyGrow.Migrations
{
    public partial class AddCritNullFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdditionalCriteries_GroundwaterLevels_GroundwaterLevelId",
                table: "AdditionalCriteries");

            migrationBuilder.DropTable(
                name: "TestModel");

            migrationBuilder.AlterColumn<int>(
                name: "GroundwaterLevelId",
                table: "AdditionalCriteries",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_AdditionalCriteries_GroundwaterLevels_GroundwaterLevelId",
                table: "AdditionalCriteries",
                column: "GroundwaterLevelId",
                principalTable: "GroundwaterLevels",
                principalColumn: "GroundwaterLevelId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdditionalCriteries_GroundwaterLevels_GroundwaterLevelId",
                table: "AdditionalCriteries");

            migrationBuilder.AlterColumn<int>(
                name: "GroundwaterLevelId",
                table: "AdditionalCriteries",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "TestModel",
                columns: table => new
                {
                    TestModelId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Info = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestModel", x => x.TestModelId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AdditionalCriteries_GroundwaterLevels_GroundwaterLevelId",
                table: "AdditionalCriteries",
                column: "GroundwaterLevelId",
                principalTable: "GroundwaterLevels",
                principalColumn: "GroundwaterLevelId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
