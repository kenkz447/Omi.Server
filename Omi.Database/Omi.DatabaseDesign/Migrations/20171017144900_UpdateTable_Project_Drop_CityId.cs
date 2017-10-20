﻿using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Omi.DatabaseDesign.Migrations
{
    public partial class UpdateTable_Project_Drop_CityId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_GeographicaLocation_CityId1",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Project_CityId1",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "CityId1",
                table: "Project");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CityId",
                table: "Project",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "CityId1",
                table: "Project",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Project_CityId1",
                table: "Project",
                column: "CityId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_GeographicaLocation_CityId1",
                table: "Project",
                column: "CityId1",
                principalTable: "GeographicaLocation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
