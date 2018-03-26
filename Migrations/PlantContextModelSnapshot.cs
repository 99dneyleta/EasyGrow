﻿// <auto-generated />
using EasyGrow.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;

namespace EasyGrow.Migrations
{
    [DbContext(typeof(PlantContext))]
    partial class PlantContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011");

            modelBuilder.Entity("EasyGrow.Models.AdditinalCriteries", b =>
                {
                    b.Property<int>("AdditinalCriteriesId")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("AreaSawn");

                    b.Property<int>("GroundwaterLevelId");

                    b.HasKey("AdditinalCriteriesId");

                    b.HasIndex("GroundwaterLevelId");

                    b.ToTable("AdditinalCriteries");
                });

            modelBuilder.Entity("EasyGrow.Models.Class", b =>
                {
                    b.Property<int>("ClassId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ClassId");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("EasyGrow.Models.Geolocation", b =>
                {
                    b.Property<int>("GeolocationId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Latitude");

                    b.Property<string>("Longitude");

                    b.Property<string>("SeaLevel");

                    b.HasKey("GeolocationId");

                    b.ToTable("Geolocations");
                });

            modelBuilder.Entity("EasyGrow.Models.GroundwaterLevel", b =>
                {
                    b.Property<int>("GroundwaterLevelId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("GroundwaterLevelId");

                    b.ToTable("GroundwaterLevels");
                });

            modelBuilder.Entity("EasyGrow.Models.Phase", b =>
                {
                    b.Property<int>("PhaseId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Duration");

                    b.Property<string>("Name");

                    b.HasKey("PhaseId");

                    b.ToTable("Phases");
                });

            modelBuilder.Entity("EasyGrow.Models.PhasePlant", b =>
                {
                    b.Property<int>("PlantId");

                    b.Property<int>("PhaseId");

                    b.HasKey("PlantId", "PhaseId");

                    b.HasIndex("PhaseId");

                    b.ToTable("PhasePlant");
                });

            modelBuilder.Entity("EasyGrow.Models.Plant", b =>
                {
                    b.Property<int?>("PlantId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AdditinalCriteriesId");

                    b.Property<int?>("Age");

                    b.Property<int?>("AmountOfFertilizingDays");

                    b.Property<int?>("AmountOfWater");

                    b.Property<int?>("ClassId");

                    b.Property<int?>("FrequencyOfWateringDays");

                    b.Property<string>("Info");

                    b.Property<string>("Name");

                    b.HasKey("PlantId");

                    b.HasIndex("AdditinalCriteriesId");

                    b.HasIndex("ClassId");

                    b.ToTable("Plants");
                });

            modelBuilder.Entity("EasyGrow.Models.TestModel", b =>
                {
                    b.Property<int?>("TestModelId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Info");

                    b.HasKey("TestModelId");

                    b.ToTable("TestModel");
                });

            modelBuilder.Entity("EasyGrow.Models.UserPlantPhaseGeo", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<int>("PlantId");

                    b.Property<int>("PhaseId");

                    b.Property<int>("GeolocationId");

                    b.Property<byte[]>("Planted")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("UserId", "PlantId", "PhaseId", "GeolocationId");

                    b.HasIndex("GeolocationId");

                    b.HasIndex("PhaseId");

                    b.HasIndex("PlantId");

                    b.ToTable("UserPlantPhaseGeo");
                });

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
                        .HasName("RoleNameIndex");

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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Discriminator")
                        .IsRequired();

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
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
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

            modelBuilder.Entity("EasyGrow.Models.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");


                    b.ToTable("ApplicationUser");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("EasyGrow.Models.AdditinalCriteries", b =>
                {
                    b.HasOne("EasyGrow.Models.GroundwaterLevel", "GroundwaterLevel")
                        .WithMany("AdditinalCriteries")
                        .HasForeignKey("GroundwaterLevelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EasyGrow.Models.PhasePlant", b =>
                {
                    b.HasOne("EasyGrow.Models.Phase", "Phase")
                        .WithMany("PhasePlants")
                        .HasForeignKey("PhaseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EasyGrow.Models.Plant", "Plant")
                        .WithMany("PhasePlants")
                        .HasForeignKey("PlantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EasyGrow.Models.Plant", b =>
                {
                    b.HasOne("EasyGrow.Models.AdditinalCriteries", "AdditinalCriteries")
                        .WithMany("Plants")
                        .HasForeignKey("AdditinalCriteriesId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EasyGrow.Models.Class", "Class")
                        .WithMany("Plants")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EasyGrow.Models.UserPlantPhaseGeo", b =>
                {
                    b.HasOne("EasyGrow.Models.Geolocation", "Geolocation")
                        .WithMany("UserPlantPhaseGeo")
                        .HasForeignKey("GeolocationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EasyGrow.Models.Phase", "Phase")
                        .WithMany("UserPlantPhaseGeo")
                        .HasForeignKey("PhaseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EasyGrow.Models.Plant", "Plant")
                        .WithMany("UserPlantPhaseGeo")
                        .HasForeignKey("PlantId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EasyGrow.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("UserPlantPhaseGeo")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
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
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
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

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
