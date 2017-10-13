using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Omi.DatabaseDesign.Migrations
{
    public partial class Recreate_database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomFieldGroup",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomFieldGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomFieldGroup_AspNetUsers_CreateByUserId",
                        column: x => x.CreateByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomFieldGroup_AspNetUsers_DeleteByUserId",
                        column: x => x.DeleteByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EntityType",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityType", x => x.Id);
                    table.UniqueConstraint("AK_EntityType_Name", x => x.Name);
                    table.ForeignKey(
                        name: "FK_EntityType_AspNetUsers_CreateByUserId",
                        column: x => x.CreateByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntityType_AspNetUsers_DeleteByUserId",
                        column: x => x.DeleteByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FileEntity",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FileType = table.Column<int>(type: "int", nullable: false),
                    MetaJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<long>(type: "bigint", nullable: false),
                    Src = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileEntity", x => x.Id);
                    table.UniqueConstraint("AK_FileEntity_Src", x => x.Src);
                    table.ForeignKey(
                        name: "FK_FileEntity_AspNetUsers_CreateByUserId",
                        column: x => x.CreateByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FileEntity_AspNetUsers_DeleteByUserId",
                        column: x => x.DeleteByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomField",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AllowHtml = table.Column<bool>(type: "bit", nullable: false),
                    CreateByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomFieldDetailId = table.Column<long>(type: "bigint", nullable: false),
                    CustomFieldGroupId = table.Column<long>(type: "bigint", nullable: false),
                    DeleteByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: true),
                    Required = table.Column<bool>(type: "bit", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomField", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomField_AspNetUsers_CreateByUserId",
                        column: x => x.CreateByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomField_CustomFieldGroup_CustomFieldGroupId",
                        column: x => x.CustomFieldGroupId,
                        principalTable: "CustomFieldGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomField_AspNetUsers_DeleteByUserId",
                        column: x => x.DeleteByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Package",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EntityTypeId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Package", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Package_AspNetUsers_CreateByUserId",
                        column: x => x.CreateByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Package_AspNetUsers_DeleteByUserId",
                        column: x => x.DeleteByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Package_EntityType_EntityTypeId",
                        column: x => x.EntityTypeId,
                        principalTable: "EntityType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaxonomyType",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EntityTypeId = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxonomyType", x => x.Id);
                    table.UniqueConstraint("AK_TaxonomyType_Name", x => x.Name);
                    table.ForeignKey(
                        name: "FK_TaxonomyType_AspNetUsers_CreateByUserId",
                        column: x => x.CreateByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TaxonomyType_AspNetUsers_DeleteByUserId",
                        column: x => x.DeleteByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TaxonomyType_EntityType_EntityTypeId",
                        column: x => x.EntityTypeId,
                        principalTable: "EntityType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomFieldDetail",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Append = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CharacterLimit = table.Column<int>(type: "int", nullable: false),
                    CreateByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomFieldId = table.Column<long>(type: "bigint", nullable: false),
                    DefaultValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlaceholderText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prepend = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomFieldDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomFieldDetail_AspNetUsers_CreateByUserId",
                        column: x => x.CreateByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomFieldDetail_CustomField_CustomFieldId",
                        column: x => x.CustomFieldId,
                        principalTable: "CustomField",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PackageDetail",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Area = table.Column<int>(type: "int", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PackageId = table.Column<long>(type: "bigint", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    SortText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PackageDetail_Package_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Package",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Taxonomy",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TaxonomyTypeId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxonomy", x => x.Id);
                    table.UniqueConstraint("AK_Taxonomy_Name", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Taxonomy_AspNetUsers_CreateByUserId",
                        column: x => x.CreateByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Taxonomy_AspNetUsers_DeleteByUserId",
                        column: x => x.DeleteByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Taxonomy_TaxonomyType_TaxonomyTypeId",
                        column: x => x.TaxonomyTypeId,
                        principalTable: "TaxonomyType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PackageTaxonomy",
                columns: table => new
                {
                    PackageId = table.Column<long>(type: "bigint", nullable: false),
                    TaxonomyId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageTaxonomy", x => new { x.PackageId, x.TaxonomyId });
                    table.ForeignKey(
                        name: "FK_PackageTaxonomy_Package_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Package",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PackageTaxonomy_Taxonomy_TaxonomyId",
                        column: x => x.TaxonomyId,
                        principalTable: "Taxonomy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaxonomyDetail",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxonomyId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxonomyDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaxonomyDetail_AspNetUsers_CreateByUserId",
                        column: x => x.CreateByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TaxonomyDetail_Taxonomy_TaxonomyId",
                        column: x => x.TaxonomyId,
                        principalTable: "Taxonomy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CustomField_CreateByUserId",
                table: "CustomField",
                column: "CreateByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomField_CustomFieldGroupId",
                table: "CustomField",
                column: "CustomFieldGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomField_DeleteByUserId",
                table: "CustomField",
                column: "DeleteByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomFieldDetail_CreateByUserId",
                table: "CustomFieldDetail",
                column: "CreateByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomFieldDetail_CustomFieldId",
                table: "CustomFieldDetail",
                column: "CustomFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomFieldGroup_CreateByUserId",
                table: "CustomFieldGroup",
                column: "CreateByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomFieldGroup_DeleteByUserId",
                table: "CustomFieldGroup",
                column: "DeleteByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityType_CreateByUserId",
                table: "EntityType",
                column: "CreateByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityType_DeleteByUserId",
                table: "EntityType",
                column: "DeleteByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FileEntity_CreateByUserId",
                table: "FileEntity",
                column: "CreateByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FileEntity_DeleteByUserId",
                table: "FileEntity",
                column: "DeleteByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Package_CreateByUserId",
                table: "Package",
                column: "CreateByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Package_DeleteByUserId",
                table: "Package",
                column: "DeleteByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Package_EntityTypeId",
                table: "Package",
                column: "EntityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageDetail_PackageId",
                table: "PackageDetail",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageTaxonomy_TaxonomyId",
                table: "PackageTaxonomy",
                column: "TaxonomyId");

            migrationBuilder.CreateIndex(
                name: "IX_Taxonomy_CreateByUserId",
                table: "Taxonomy",
                column: "CreateByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Taxonomy_DeleteByUserId",
                table: "Taxonomy",
                column: "DeleteByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Taxonomy_TaxonomyTypeId",
                table: "Taxonomy",
                column: "TaxonomyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxonomyDetail_CreateByUserId",
                table: "TaxonomyDetail",
                column: "CreateByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxonomyDetail_TaxonomyId",
                table: "TaxonomyDetail",
                column: "TaxonomyId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxonomyType_CreateByUserId",
                table: "TaxonomyType",
                column: "CreateByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxonomyType_DeleteByUserId",
                table: "TaxonomyType",
                column: "DeleteByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxonomyType_EntityTypeId",
                table: "TaxonomyType",
                column: "EntityTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CustomFieldDetail");

            migrationBuilder.DropTable(
                name: "FileEntity");

            migrationBuilder.DropTable(
                name: "PackageDetail");

            migrationBuilder.DropTable(
                name: "PackageTaxonomy");

            migrationBuilder.DropTable(
                name: "TaxonomyDetail");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "CustomField");

            migrationBuilder.DropTable(
                name: "Package");

            migrationBuilder.DropTable(
                name: "Taxonomy");

            migrationBuilder.DropTable(
                name: "CustomFieldGroup");

            migrationBuilder.DropTable(
                name: "TaxonomyType");

            migrationBuilder.DropTable(
                name: "EntityType");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
