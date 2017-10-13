using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Omi.DatabaseDesign.Migrations
{
    public partial class CreateTable_PackageFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PackageFile",
                columns: table => new
                {
                    PackageId = table.Column<long>(type: "bigint", nullable: false),
                    FileEntityId = table.Column<long>(type: "bigint", nullable: false),
                    EntityFileEntityId = table.Column<long>(type: "bigint", nullable: true),
                    EntityPackageId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageFile", x => new { x.PackageId, x.FileEntityId });
                    table.ForeignKey(
                        name: "FK_PackageFile_FileEntity_FileEntityId",
                        column: x => x.FileEntityId,
                        principalTable: "FileEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PackageFile_Package_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Package",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PackageFile_PackageFile_EntityPackageId_EntityFileEntityId",
                        columns: x => new { x.EntityPackageId, x.EntityFileEntityId },
                        principalTable: "PackageFile",
                        principalColumns: new[] { "PackageId", "FileEntityId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PackageFile_FileEntityId",
                table: "PackageFile",
                column: "FileEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageFile_EntityPackageId_EntityFileEntityId",
                table: "PackageFile",
                columns: new[] { "EntityPackageId", "EntityFileEntityId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PackageFile");
        }
    }
}
