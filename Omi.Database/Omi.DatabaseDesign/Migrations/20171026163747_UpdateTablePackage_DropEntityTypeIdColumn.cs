using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Omi.DatabaseDesign.Migrations
{
    public partial class UpdateTablePackage_DropEntityTypeIdColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Package_EntityType_EntityTypeId",
                table: "Package");

            migrationBuilder.DropIndex(
                name: "IX_Package_EntityTypeId",
                table: "Package");

            migrationBuilder.DropColumn(
                name: "EntityTypeId",
                table: "Package");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "EntityTypeId",
                table: "Package",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Package_EntityTypeId",
                table: "Package",
                column: "EntityTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Package_EntityType_EntityTypeId",
                table: "Package",
                column: "EntityTypeId",
                principalTable: "EntityType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
