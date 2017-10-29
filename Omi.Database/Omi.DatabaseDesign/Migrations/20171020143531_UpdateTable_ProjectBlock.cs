using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Omi.DatabaseDesign.Migrations
{
    public partial class UpdateTable_ProjectBlock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Package_EntityType_EntityTypeId",
                table: "Package");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_EntityType_EntityTypeId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectBlock_EntityType_EntityTypeId",
                table: "ProjectBlock");

            migrationBuilder.DropIndex(
                name: "IX_Project_EntityTypeId",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "EntityTypeId",
                table: "Project");

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "ProjectBlockDetail",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "EntityTypeId",
                table: "ProjectBlock",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "EntityTypeId",
                table: "Package",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Package_EntityType_EntityTypeId",
                table: "Package",
                column: "EntityTypeId",
                principalTable: "EntityType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectBlock_EntityType_EntityTypeId",
                table: "ProjectBlock",
                column: "EntityTypeId",
                principalTable: "EntityType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Package_EntityType_EntityTypeId",
                table: "Package");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectBlock_EntityType_EntityTypeId",
                table: "ProjectBlock");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "ProjectBlockDetail");

            migrationBuilder.AlterColumn<long>(
                name: "EntityTypeId",
                table: "ProjectBlock",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "EntityTypeId",
                table: "Project",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "EntityTypeId",
                table: "Package",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateIndex(
                name: "IX_Project_EntityTypeId",
                table: "Project",
                column: "EntityTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Package_EntityType_EntityTypeId",
                table: "Package",
                column: "EntityTypeId",
                principalTable: "EntityType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_EntityType_EntityTypeId",
                table: "Project",
                column: "EntityTypeId",
                principalTable: "EntityType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectBlock_EntityType_EntityTypeId",
                table: "ProjectBlock",
                column: "EntityTypeId",
                principalTable: "EntityType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
