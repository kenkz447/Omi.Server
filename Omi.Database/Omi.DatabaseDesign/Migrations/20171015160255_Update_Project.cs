using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Omi.DatabaseDesign.Migrations
{
    public partial class Update_Project : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PackageFile_Package_PackageId",
                table: "PackageFile");

            migrationBuilder.DropForeignKey(
                name: "FK_PackageFile_PackageFile_EntityPackageId_EntityFileEntityId",
                table: "PackageFile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PackageFile",
                table: "PackageFile");

            migrationBuilder.DropIndex(
                name: "IX_PackageFile_EntityPackageId_EntityFileEntityId",
                table: "PackageFile");

            migrationBuilder.DropColumn(
                name: "PackageId",
                table: "PackageFile");

            migrationBuilder.DropColumn(
                name: "EntityFileEntityId",
                table: "PackageFile");

            migrationBuilder.DropColumn(
                name: "EntityPackageId",
                table: "PackageFile");

            migrationBuilder.AddColumn<long>(
                name: "EntityId",
                table: "PackageFile",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PackageFile",
                table: "PackageFile",
                columns: new[] { "EntityId", "FileEntityId" });

            migrationBuilder.CreateTable(
                name: "GeographicaLocation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    JsonOptions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationType = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeographicaLocation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeographicaLocation_GeographicaLocation_ParentId",
                        column: x => x.ParentId,
                        principalTable: "GeographicaLocation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EntityTypeId = table.Column<long>(type: "bigint", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Project_AspNetUsers_CreateByUserId",
                        column: x => x.CreateByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Project_AspNetUsers_DeleteByUserId",
                        column: x => x.DeleteByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Project_EntityType_EntityTypeId",
                        column: x => x.EntityTypeId,
                        principalTable: "EntityType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Project_GeographicaLocation_LocationId",
                        column: x => x.LocationId,
                        principalTable: "GeographicaLocation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectDetail",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Area = table.Column<int>(type: "int", nullable: false),
                    Investor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectId = table.Column<long>(type: "bigint", nullable: false),
                    StartedYear = table.Column<int>(type: "int", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalApartment = table.Column<int>(type: "int", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectDetail_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectFile",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false),
                    FileEntityId = table.Column<long>(type: "bigint", nullable: false),
                    UsingType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectFile", x => new { x.EntityId, x.FileEntityId });
                    table.ForeignKey(
                        name: "FK_ProjectFile_Project_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectFile_FileEntity_FileEntityId",
                        column: x => x.FileEntityId,
                        principalTable: "FileEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTaxonomy",
                columns: table => new
                {
                    ProjectId = table.Column<long>(type: "bigint", nullable: false),
                    TaxonomyId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTaxonomy", x => new { x.ProjectId, x.TaxonomyId });
                    table.ForeignKey(
                        name: "FK_ProjectTaxonomy_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectTaxonomy_Taxonomy_TaxonomyId",
                        column: x => x.TaxonomyId,
                        principalTable: "Taxonomy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GeographicaLocation_ParentId",
                table: "GeographicaLocation",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_CreateByUserId",
                table: "Project",
                column: "CreateByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_DeleteByUserId",
                table: "Project",
                column: "DeleteByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_EntityTypeId",
                table: "Project",
                column: "EntityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_LocationId",
                table: "Project",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectDetail_ProjectId",
                table: "ProjectDetail",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectFile_FileEntityId",
                table: "ProjectFile",
                column: "FileEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTaxonomy_TaxonomyId",
                table: "ProjectTaxonomy",
                column: "TaxonomyId");

            migrationBuilder.AddForeignKey(
                name: "FK_PackageFile_Package_EntityId",
                table: "PackageFile",
                column: "EntityId",
                principalTable: "Package",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PackageFile_Package_EntityId",
                table: "PackageFile");

            migrationBuilder.DropTable(
                name: "ProjectDetail");

            migrationBuilder.DropTable(
                name: "ProjectFile");

            migrationBuilder.DropTable(
                name: "ProjectTaxonomy");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "GeographicaLocation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PackageFile",
                table: "PackageFile");

            migrationBuilder.DropColumn(
                name: "EntityId",
                table: "PackageFile");

            migrationBuilder.AddColumn<long>(
                name: "PackageId",
                table: "PackageFile",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "EntityFileEntityId",
                table: "PackageFile",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "EntityPackageId",
                table: "PackageFile",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PackageFile",
                table: "PackageFile",
                columns: new[] { "PackageId", "FileEntityId" });

            migrationBuilder.CreateIndex(
                name: "IX_PackageFile_EntityPackageId_EntityFileEntityId",
                table: "PackageFile",
                columns: new[] { "EntityPackageId", "EntityFileEntityId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PackageFile_Package_PackageId",
                table: "PackageFile",
                column: "PackageId",
                principalTable: "Package",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PackageFile_PackageFile_EntityPackageId_EntityFileEntityId",
                table: "PackageFile",
                columns: new[] { "EntityPackageId", "EntityFileEntityId" },
                principalTable: "PackageFile",
                principalColumns: new[] { "PackageId", "FileEntityId" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
