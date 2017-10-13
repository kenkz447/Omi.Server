using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Omi.DatabaseDesign.Migrations
{
    public partial class Update_ForeignKey_For_EntityType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Package_EntityType_EntityTypeId",
                table: "Package");

            migrationBuilder.AlterColumn<long>(
                name: "EntityTypeId",
                table: "Package",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_Package_EntityType_EntityTypeId",
                table: "Package",
                column: "EntityTypeId",
                principalTable: "EntityType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Package_EntityType_EntityTypeId",
                table: "Package");

            migrationBuilder.AlterColumn<long>(
                name: "EntityTypeId",
                table: "Package",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

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
