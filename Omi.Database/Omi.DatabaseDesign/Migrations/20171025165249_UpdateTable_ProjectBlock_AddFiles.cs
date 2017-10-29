using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Omi.DatabaseDesign.Migrations
{
    public partial class UpdateTable_ProjectBlock_AddFiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectBlock_FileEntity_LayoutImageId",
                table: "ProjectBlock");

            migrationBuilder.DropIndex(
                name: "IX_ProjectBlock_LayoutImageId",
                table: "ProjectBlock");

            migrationBuilder.DropColumn(
                name: "LayoutImageId",
                table: "ProjectBlock");

            migrationBuilder.CreateTable(
                name: "ProjectBlockFile",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false),
                    FileEntityId = table.Column<long>(type: "bigint", nullable: false),
                    JsonData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsingType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectBlockFile", x => new { x.EntityId, x.FileEntityId });
                    table.ForeignKey(
                        name: "FK_ProjectBlockFile_ProjectBlock_EntityId",
                        column: x => x.EntityId,
                        principalTable: "ProjectBlock",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectBlockFile_FileEntity_FileEntityId",
                        column: x => x.FileEntityId,
                        principalTable: "FileEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectBlockFile_FileEntityId",
                table: "ProjectBlockFile",
                column: "FileEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectBlockFile");

            migrationBuilder.AddColumn<long>(
                name: "LayoutImageId",
                table: "ProjectBlock",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectBlock_LayoutImageId",
                table: "ProjectBlock",
                column: "LayoutImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectBlock_FileEntity_LayoutImageId",
                table: "ProjectBlock",
                column: "LayoutImageId",
                principalTable: "FileEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
