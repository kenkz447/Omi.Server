using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Omi.DatabaseDesign.Migrations
{
    public partial class CreateTable_ProjectBlock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectBlock",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EntityTypeId = table.Column<long>(type: "bigint", nullable: true),
                    LayoutImageId = table.Column<long>(type: "bigint", nullable: true),
                    PackageId = table.Column<long>(type: "bigint", nullable: true),
                    ParentId = table.Column<long>(type: "bigint", nullable: true),
                    ProjectId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectBlock", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectBlock_EntityType_EntityTypeId",
                        column: x => x.EntityTypeId,
                        principalTable: "EntityType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectBlock_FileEntity_LayoutImageId",
                        column: x => x.LayoutImageId,
                        principalTable: "FileEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectBlock_Package_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Package",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectBlock_ProjectBlock_ParentId",
                        column: x => x.ParentId,
                        principalTable: "ProjectBlock",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectBlock_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectBlockDetail",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectBlockId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectBlockDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectBlockDetail_ProjectBlock_ProjectBlockId",
                        column: x => x.ProjectBlockId,
                        principalTable: "ProjectBlock",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectBlock_EntityTypeId",
                table: "ProjectBlock",
                column: "EntityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectBlock_LayoutImageId",
                table: "ProjectBlock",
                column: "LayoutImageId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectBlock_PackageId",
                table: "ProjectBlock",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectBlock_ParentId",
                table: "ProjectBlock",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectBlock_ProjectId",
                table: "ProjectBlock",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectBlockDetail_ProjectBlockId",
                table: "ProjectBlockDetail",
                column: "ProjectBlockId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectBlockDetail");

            migrationBuilder.DropTable(
                name: "ProjectBlock");
        }
    }
}
