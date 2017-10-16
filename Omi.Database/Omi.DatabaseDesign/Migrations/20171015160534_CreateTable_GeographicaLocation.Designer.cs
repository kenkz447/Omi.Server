﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Omi.DatabaseDesign;
using System;

namespace Omi.DatabaseDesign.Migrations
{
    [DbContext(typeof(OmiDbContext))]
    [Migration("20171015160534_CreateTable_GeographicaLocation")]
    partial class CreateTable_GeographicaLocation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Omi.Data.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Omi.Modules.FileAndMedia.Entities.FileEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreateByUserId");

                    b.Property<DateTime?>("CreateDate");

                    b.Property<string>("DeleteByUserId");

                    b.Property<DateTime?>("DeleteDate");

                    b.Property<int>("FileType");

                    b.Property<string>("MetaJson");

                    b.Property<long>("Size");

                    b.Property<string>("Src")
                        .IsRequired();

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasAlternateKey("Src");

                    b.HasIndex("CreateByUserId");

                    b.HasIndex("DeleteByUserId");

                    b.ToTable("FileEntity");
                });

            modelBuilder.Entity("Omi.Modules.HomeBuilder.Entities.Package", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreateByUserId");

                    b.Property<DateTime?>("CreateDate");

                    b.Property<string>("DeleteByUserId");

                    b.Property<DateTime?>("DeleteDate");

                    b.Property<long?>("EntityTypeId");

                    b.Property<string>("Name");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("CreateByUserId");

                    b.HasIndex("DeleteByUserId");

                    b.HasIndex("EntityTypeId");

                    b.ToTable("Package");
                });

            modelBuilder.Entity("Omi.Modules.HomeBuilder.Entities.PackageDetail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Area");

                    b.Property<string>("Language");

                    b.Property<long>("PackageId");

                    b.Property<int>("Price");

                    b.Property<string>("SortText");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("PackageId");

                    b.ToTable("PackageDetail");
                });

            modelBuilder.Entity("Omi.Modules.HomeBuilder.Entities.PackageFile", b =>
                {
                    b.Property<long>("EntityId");

                    b.Property<long>("FileEntityId");

                    b.Property<int>("UsingType");

                    b.HasKey("EntityId", "FileEntityId");

                    b.HasIndex("FileEntityId");

                    b.ToTable("PackageFile");
                });

            modelBuilder.Entity("Omi.Modules.HomeBuilder.Entities.PackageTaxonomy", b =>
                {
                    b.Property<long>("PackageId");

                    b.Property<long>("TaxonomyId");

                    b.HasKey("PackageId", "TaxonomyId");

                    b.HasIndex("TaxonomyId");

                    b.ToTable("PackageTaxonomy");
                });

            modelBuilder.Entity("Omi.Modules.HomeBuilder.Entities.Project", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreateByUserId");

                    b.Property<DateTime?>("CreateDate");

                    b.Property<string>("DeleteByUserId");

                    b.Property<DateTime?>("DeleteDate");

                    b.Property<long?>("EntityTypeId");

                    b.Property<int>("LocationId");

                    b.Property<string>("Name");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("CreateByUserId");

                    b.HasIndex("DeleteByUserId");

                    b.HasIndex("EntityTypeId");

                    b.HasIndex("LocationId");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("Omi.Modules.HomeBuilder.Entities.ProjectDetail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Area");

                    b.Property<string>("Investor");

                    b.Property<string>("Language");

                    b.Property<long>("ProjectId");

                    b.Property<int>("StartedYear");

                    b.Property<string>("Street");

                    b.Property<int>("TotalApartment");

                    b.Property<string>("Website");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectDetail");
                });

            modelBuilder.Entity("Omi.Modules.HomeBuilder.Entities.ProjectFile", b =>
                {
                    b.Property<long>("EntityId");

                    b.Property<long>("FileEntityId");

                    b.Property<int>("UsingType");

                    b.HasKey("EntityId", "FileEntityId");

                    b.HasIndex("FileEntityId");

                    b.ToTable("ProjectFile");
                });

            modelBuilder.Entity("Omi.Modules.HomeBuilder.Entities.ProjectTaxonomy", b =>
                {
                    b.Property<long>("ProjectId");

                    b.Property<long>("TaxonomyId");

                    b.HasKey("ProjectId", "TaxonomyId");

                    b.HasIndex("TaxonomyId");

                    b.ToTable("ProjectTaxonomy");
                });

            modelBuilder.Entity("Omi.Modules.Location.Entities.GeographicaLocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("JsonOptions");

                    b.Property<string>("Label")
                        .IsRequired();

                    b.Property<int>("LocationType");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int?>("ParentId");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("GeographicaLocation");
                });

            modelBuilder.Entity("Omi.Modules.ModuleBase.Entities.CustomField", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("AllowHtml");

                    b.Property<string>("CreateByUserId");

                    b.Property<DateTime?>("CreateDate");

                    b.Property<long>("CustomFieldDetailId");

                    b.Property<long>("CustomFieldGroupId");

                    b.Property<string>("DeleteByUserId");

                    b.Property<DateTime?>("DeleteDate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int?>("Order");

                    b.Property<bool?>("Required");

                    b.Property<int>("Status");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.HasIndex("CreateByUserId");

                    b.HasIndex("CustomFieldGroupId");

                    b.HasIndex("DeleteByUserId");

                    b.ToTable("CustomField");
                });

            modelBuilder.Entity("Omi.Modules.ModuleBase.Entities.CustomFieldDetail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Append");

                    b.Property<int>("CharacterLimit");

                    b.Property<string>("CreateByUserId");

                    b.Property<DateTime?>("CreateDate");

                    b.Property<long>("CustomFieldId");

                    b.Property<string>("DefaultValue");

                    b.Property<string>("Description");

                    b.Property<string>("Label");

                    b.Property<string>("Language");

                    b.Property<string>("PlaceholderText");

                    b.Property<string>("Prepend");

                    b.HasKey("Id");

                    b.HasIndex("CreateByUserId");

                    b.HasIndex("CustomFieldId");

                    b.ToTable("CustomFieldDetail");
                });

            modelBuilder.Entity("Omi.Modules.ModuleBase.Entities.CustomFieldGroup", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreateByUserId");

                    b.Property<DateTime?>("CreateDate");

                    b.Property<string>("DeleteByUserId");

                    b.Property<DateTime?>("DeleteDate");

                    b.Property<string>("Name");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("CreateByUserId");

                    b.HasIndex("DeleteByUserId");

                    b.ToTable("CustomFieldGroup");
                });

            modelBuilder.Entity("Omi.Modules.ModuleBase.Entities.EntityType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreateByUserId");

                    b.Property<DateTime?>("CreateDate");

                    b.Property<string>("DeleteByUserId");

                    b.Property<DateTime?>("DeleteDate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.HasIndex("CreateByUserId");

                    b.HasIndex("DeleteByUserId");

                    b.ToTable("EntityType");
                });

            modelBuilder.Entity("Omi.Modules.ModuleBase.Entities.Taxonomy", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreateByUserId");

                    b.Property<DateTime?>("CreateDate");

                    b.Property<string>("DeleteByUserId");

                    b.Property<DateTime?>("DeleteDate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("Status");

                    b.Property<long>("TaxonomyTypeId");

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.HasIndex("CreateByUserId");

                    b.HasIndex("DeleteByUserId");

                    b.HasIndex("TaxonomyTypeId");

                    b.ToTable("Taxonomy");
                });

            modelBuilder.Entity("Omi.Modules.ModuleBase.Entities.TaxonomyDetail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreateByUserId");

                    b.Property<DateTime?>("CreateDate");

                    b.Property<string>("Icon");

                    b.Property<string>("Label");

                    b.Property<string>("Language");

                    b.Property<long>("TaxonomyId");

                    b.HasKey("Id");

                    b.HasIndex("CreateByUserId");

                    b.HasIndex("TaxonomyId");

                    b.ToTable("TaxonomyDetail");
                });

            modelBuilder.Entity("Omi.Modules.ModuleBase.Entities.TaxonomyType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreateByUserId");

                    b.Property<DateTime?>("CreateDate");

                    b.Property<string>("DeleteByUserId");

                    b.Property<DateTime?>("DeleteDate");

                    b.Property<long?>("EntityTypeId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.HasIndex("CreateByUserId");

                    b.HasIndex("DeleteByUserId");

                    b.HasIndex("EntityTypeId");

                    b.ToTable("TaxonomyType");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Omi.Data.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Omi.Data.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Omi.Data.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Omi.Data.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Omi.Modules.FileAndMedia.Entities.FileEntity", b =>
                {
                    b.HasOne("Omi.Data.ApplicationUser", "CreateByUser")
                        .WithMany()
                        .HasForeignKey("CreateByUserId");

                    b.HasOne("Omi.Data.ApplicationUser", "DeleteByUser")
                        .WithMany()
                        .HasForeignKey("DeleteByUserId");
                });

            modelBuilder.Entity("Omi.Modules.HomeBuilder.Entities.Package", b =>
                {
                    b.HasOne("Omi.Data.ApplicationUser", "CreateByUser")
                        .WithMany()
                        .HasForeignKey("CreateByUserId");

                    b.HasOne("Omi.Data.ApplicationUser", "DeleteByUser")
                        .WithMany()
                        .HasForeignKey("DeleteByUserId");

                    b.HasOne("Omi.Modules.ModuleBase.Entities.EntityType", "EntityType")
                        .WithMany()
                        .HasForeignKey("EntityTypeId");
                });

            modelBuilder.Entity("Omi.Modules.HomeBuilder.Entities.PackageDetail", b =>
                {
                    b.HasOne("Omi.Modules.HomeBuilder.Entities.Package", "Package")
                        .WithMany("PackageDetails")
                        .HasForeignKey("PackageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Omi.Modules.HomeBuilder.Entities.PackageFile", b =>
                {
                    b.HasOne("Omi.Modules.HomeBuilder.Entities.Package", "Entity")
                        .WithMany("EnitityFiles")
                        .HasForeignKey("EntityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Omi.Modules.FileAndMedia.Entities.FileEntity", "FileEntity")
                        .WithMany()
                        .HasForeignKey("FileEntityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Omi.Modules.HomeBuilder.Entities.PackageTaxonomy", b =>
                {
                    b.HasOne("Omi.Modules.HomeBuilder.Entities.Package", "Entity")
                        .WithMany("EntityTaxonomies")
                        .HasForeignKey("PackageId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Omi.Modules.ModuleBase.Entities.Taxonomy", "Taxonomy")
                        .WithMany()
                        .HasForeignKey("TaxonomyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Omi.Modules.HomeBuilder.Entities.Project", b =>
                {
                    b.HasOne("Omi.Data.ApplicationUser", "CreateByUser")
                        .WithMany()
                        .HasForeignKey("CreateByUserId");

                    b.HasOne("Omi.Data.ApplicationUser", "DeleteByUser")
                        .WithMany()
                        .HasForeignKey("DeleteByUserId");

                    b.HasOne("Omi.Modules.ModuleBase.Entities.EntityType", "EntityType")
                        .WithMany()
                        .HasForeignKey("EntityTypeId");

                    b.HasOne("Omi.Modules.Location.Entities.GeographicaLocation", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Omi.Modules.HomeBuilder.Entities.ProjectDetail", b =>
                {
                    b.HasOne("Omi.Modules.HomeBuilder.Entities.Project", "Project")
                        .WithMany("ProjectDetails")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Omi.Modules.HomeBuilder.Entities.ProjectFile", b =>
                {
                    b.HasOne("Omi.Modules.HomeBuilder.Entities.Project", "Entity")
                        .WithMany("EnitityFiles")
                        .HasForeignKey("EntityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Omi.Modules.FileAndMedia.Entities.FileEntity", "FileEntity")
                        .WithMany()
                        .HasForeignKey("FileEntityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Omi.Modules.HomeBuilder.Entities.ProjectTaxonomy", b =>
                {
                    b.HasOne("Omi.Modules.HomeBuilder.Entities.Project", "Entity")
                        .WithMany("EntityTaxonomies")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Omi.Modules.ModuleBase.Entities.Taxonomy", "Taxonomy")
                        .WithMany()
                        .HasForeignKey("TaxonomyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Omi.Modules.Location.Entities.GeographicaLocation", b =>
                {
                    b.HasOne("Omi.Modules.Location.Entities.GeographicaLocation", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("Omi.Modules.ModuleBase.Entities.CustomField", b =>
                {
                    b.HasOne("Omi.Data.ApplicationUser", "CreateByUser")
                        .WithMany()
                        .HasForeignKey("CreateByUserId");

                    b.HasOne("Omi.Modules.ModuleBase.Entities.CustomFieldGroup", "CustomFieldGroup")
                        .WithMany("ModuleBase")
                        .HasForeignKey("CustomFieldGroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Omi.Data.ApplicationUser", "DeleteByUser")
                        .WithMany()
                        .HasForeignKey("DeleteByUserId");
                });

            modelBuilder.Entity("Omi.Modules.ModuleBase.Entities.CustomFieldDetail", b =>
                {
                    b.HasOne("Omi.Data.ApplicationUser", "CreateByUser")
                        .WithMany()
                        .HasForeignKey("CreateByUserId");

                    b.HasOne("Omi.Modules.ModuleBase.Entities.CustomField", "CustomField")
                        .WithMany("CustomFieldDetail")
                        .HasForeignKey("CustomFieldId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Omi.Modules.ModuleBase.Entities.CustomFieldGroup", b =>
                {
                    b.HasOne("Omi.Data.ApplicationUser", "CreateByUser")
                        .WithMany()
                        .HasForeignKey("CreateByUserId");

                    b.HasOne("Omi.Data.ApplicationUser", "DeleteByUser")
                        .WithMany()
                        .HasForeignKey("DeleteByUserId");
                });

            modelBuilder.Entity("Omi.Modules.ModuleBase.Entities.EntityType", b =>
                {
                    b.HasOne("Omi.Data.ApplicationUser", "CreateByUser")
                        .WithMany()
                        .HasForeignKey("CreateByUserId");

                    b.HasOne("Omi.Data.ApplicationUser", "DeleteByUser")
                        .WithMany()
                        .HasForeignKey("DeleteByUserId");
                });

            modelBuilder.Entity("Omi.Modules.ModuleBase.Entities.Taxonomy", b =>
                {
                    b.HasOne("Omi.Data.ApplicationUser", "CreateByUser")
                        .WithMany()
                        .HasForeignKey("CreateByUserId");

                    b.HasOne("Omi.Data.ApplicationUser", "DeleteByUser")
                        .WithMany()
                        .HasForeignKey("DeleteByUserId");

                    b.HasOne("Omi.Modules.ModuleBase.Entities.TaxonomyType", "TaxonomyType")
                        .WithMany()
                        .HasForeignKey("TaxonomyTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Omi.Modules.ModuleBase.Entities.TaxonomyDetail", b =>
                {
                    b.HasOne("Omi.Data.ApplicationUser", "CreateByUser")
                        .WithMany()
                        .HasForeignKey("CreateByUserId");

                    b.HasOne("Omi.Modules.ModuleBase.Entities.Taxonomy", "Taxonomy")
                        .WithMany("TaxonomyDetails")
                        .HasForeignKey("TaxonomyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Omi.Modules.ModuleBase.Entities.TaxonomyType", b =>
                {
                    b.HasOne("Omi.Data.ApplicationUser", "CreateByUser")
                        .WithMany()
                        .HasForeignKey("CreateByUserId");

                    b.HasOne("Omi.Data.ApplicationUser", "DeleteByUser")
                        .WithMany()
                        .HasForeignKey("DeleteByUserId");

                    b.HasOne("Omi.Modules.ModuleBase.Entities.EntityType", "EntityType")
                        .WithMany("TaxonomyTypes")
                        .HasForeignKey("EntityTypeId");
                });
#pragma warning restore 612, 618
        }
    }
}
