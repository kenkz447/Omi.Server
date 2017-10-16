using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Omi.DatabaseDesign.Migrations
{
    public partial class UpdateTable_Project : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_GeographicaLocation_LocationId",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Project_LocationId",
                table: "Project");

            migrationBuilder.AlterColumn<long>(
                name: "LocationId",
                table: "Project",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "LocationId1",
                table: "Project",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Project_LocationId1",
                table: "Project",
                column: "LocationId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_GeographicaLocation_LocationId1",
                table: "Project",
                column: "LocationId1",
                principalTable: "GeographicaLocation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_GeographicaLocation_LocationId1",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Project_LocationId1",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "LocationId1",
                table: "Project");

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "Project",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateIndex(
                name: "IX_Project_LocationId",
                table: "Project",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_GeographicaLocation_LocationId",
                table: "Project",
                column: "LocationId",
                principalTable: "GeographicaLocation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
