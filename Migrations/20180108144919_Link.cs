using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EasyGrow.Migrations
{
    public partial class Link : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdditinalCriteries_Geolocations_GeolocationId",
                table: "AdditinalCriteries");

            migrationBuilder.DropForeignKey(
                name: "FK_Plants_AdditinalCriteries_AdditinalCriteriesId",
                table: "Plants");

            migrationBuilder.DropForeignKey(
                name: "FK_Plants_Classes_ClassId",
                table: "Plants");

            migrationBuilder.DropForeignKey(
                name: "FK_Plants_Phases_PhaseId",
                table: "Plants");

            migrationBuilder.DropIndex(
                name: "IX_Plants_AdditinalCriteriesId",
                table: "Plants");

            migrationBuilder.DropIndex(
                name: "IX_Plants_ClassId",
                table: "Plants");

            migrationBuilder.DropIndex(
                name: "IX_Plants_PhaseId",
                table: "Plants");

            migrationBuilder.DropIndex(
                name: "IX_AdditinalCriteries_GeolocationId",
                table: "AdditinalCriteries");

            migrationBuilder.DropColumn(
                name: "GeolocationId",
                table: "AdditinalCriteries");

            migrationBuilder.AlterColumn<int>(
                name: "PhaseId",
                table: "Plants",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "FrequencyOfWateringDays",
                table: "Plants",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ClassId",
                table: "Plants",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "AmountOfWater",
                table: "Plants",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "AmountOfFertilizingDays",
                table: "Plants",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "Plants",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "AdditinalCriteriesId",
                table: "Plants",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "GeolocationID",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_AdditinalCriteriesId",
                table: "Plants",
                column: "AdditinalCriteriesId");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_ClassId",
                table: "Plants",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_PhaseId",
                table: "Plants",
                column: "PhaseId",
                unique: true,
                filter: "[PhaseId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_GeolocationID",
                table: "AspNetUsers",
                column: "GeolocationID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Geolocations_GeolocationID",
                table: "AspNetUsers",
                column: "GeolocationID",
                principalTable: "Geolocations",
                principalColumn: "GeolocationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_AdditinalCriteries_AdditinalCriteriesId",
                table: "Plants",
                column: "AdditinalCriteriesId",
                principalTable: "AdditinalCriteries",
                principalColumn: "AdditinalCriteriesId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_Classes_ClassId",
                table: "Plants",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "ClassId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_Phases_PhaseId",
                table: "Plants",
                column: "PhaseId",
                principalTable: "Phases",
                principalColumn: "PhaseId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Geolocations_GeolocationID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Plants_AdditinalCriteries_AdditinalCriteriesId",
                table: "Plants");

            migrationBuilder.DropForeignKey(
                name: "FK_Plants_Classes_ClassId",
                table: "Plants");

            migrationBuilder.DropForeignKey(
                name: "FK_Plants_Phases_PhaseId",
                table: "Plants");

            migrationBuilder.DropIndex(
                name: "IX_Plants_AdditinalCriteriesId",
                table: "Plants");

            migrationBuilder.DropIndex(
                name: "IX_Plants_ClassId",
                table: "Plants");

            migrationBuilder.DropIndex(
                name: "IX_Plants_PhaseId",
                table: "Plants");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_GeolocationID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "GeolocationID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "PhaseId",
                table: "Plants",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FrequencyOfWateringDays",
                table: "Plants",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClassId",
                table: "Plants",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AmountOfWater",
                table: "Plants",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AmountOfFertilizingDays",
                table: "Plants",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "Plants",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AdditinalCriteriesId",
                table: "Plants",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GeolocationId",
                table: "AdditinalCriteries",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_AdditinalCriteries_GeolocationId",
                table: "AdditinalCriteries",
                column: "GeolocationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AdditinalCriteries_Geolocations_GeolocationId",
                table: "AdditinalCriteries",
                column: "GeolocationId",
                principalTable: "Geolocations",
                principalColumn: "GeolocationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_AdditinalCriteries_AdditinalCriteriesId",
                table: "Plants",
                column: "AdditinalCriteriesId",
                principalTable: "AdditinalCriteries",
                principalColumn: "AdditinalCriteriesId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_Classes_ClassId",
                table: "Plants",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "ClassId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_Phases_PhaseId",
                table: "Plants",
                column: "PhaseId",
                principalTable: "Phases",
                principalColumn: "PhaseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
