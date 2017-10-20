using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Omi.DatabaseDesign.Migrations
{
    public partial class UpdateTable_Project_Add_CityId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Project",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Project_CityId",
                table: "Project",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_GeographicaLocation_CityId",
                table: "Project",
                column: "CityId",
                principalTable: "GeographicaLocation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_GeographicaLocation_CityId",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Project_CityId",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Project");
        }
    }
}
