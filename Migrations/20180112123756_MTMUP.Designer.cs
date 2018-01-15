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
    [Migration("20180112123756_MTMUP")]
    partial class MTMUP
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EasyGrow.Models.AdditinalCriteries", b =>
                {
                    b.Property<int>("AdditinalCriteriesId")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("AreaSawn");

                    b.Property<int>("GroundwaterLevelId");

                    b.HasKey("AdditinalCriteriesId");

                    b.HasIndex("GroundwaterLevelId")
                        .IsUnique();

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

                    b.Property<int?>("PhaseId");

                    b.HasKey("PlantId");

                    b.HasIndex("AdditinalCriteriesId");

                    b.HasIndex("ClassId");

                    b.HasIndex("PhaseId")
                        .IsUnique()
                        .HasFilter("[PhaseId] IS NOT NULL");

                    b.ToTable("Plants");
                });

            modelBuilder.Entity("EasyGrow.Models.UserPlants", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<int>("PlantId");

                    b.HasKey("UserId", "PlantId");

                    b.HasIndex("PlantId");

                    b.ToTable("UserPlants");
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
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

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

                    b.Property<int?>("GeolocationId");

                    b.Property<int?>("PlantId");

                    b.HasIndex("GeolocationId");

                    b.HasIndex("PlantId");

                    b.ToTable("ApplicationUser");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("EasyGrow.Models.AdditinalCriteries", b =>
                {
                    b.HasOne("EasyGrow.Models.GroundwaterLevel")
                        .WithOne("AdditinalCriteries")
                        .HasForeignKey("EasyGrow.Models.AdditinalCriteries", "GroundwaterLevelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EasyGrow.Models.PhasePlant", b =>
                {
                    b.HasOne("EasyGrow.Models.Phase", "Phase")
                        .WithMany("PhasePlants")
                        .HasForeignKey("PhaseId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("EasyGrow.Models.Plant", "Plant")
                        .WithMany("PhasePlants")
                        .HasForeignKey("PlantId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("EasyGrow.Models.Plant", b =>
                {
                    b.HasOne("EasyGrow.Models.AdditinalCriteries", "AdditinalCriteries")
                        .WithMany("Plants")
                        .HasForeignKey("AdditinalCriteriesId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("EasyGrow.Models.Class", "Class")
                        .WithMany("Plants")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("EasyGrow.Models.Phase")
                        .WithOne("Plant")
                        .HasForeignKey("EasyGrow.Models.Plant", "PhaseId");
                });

            modelBuilder.Entity("EasyGrow.Models.UserPlants", b =>
                {
                    b.HasOne("EasyGrow.Models.Plant", "Plant")
                        .WithMany("UserPlants")
                        .HasForeignKey("PlantId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("EasyGrow.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("UserPlants")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
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

            modelBuilder.Entity("EasyGrow.Models.ApplicationUser", b =>
                {
                    b.HasOne("EasyGrow.Models.Geolocation", "Geolocation")
                        .WithMany("ApplicationUsers")
                        .HasForeignKey("GeolocationId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("EasyGrow.Models.Plant", "Plant")
                        .WithMany("ApplicationUsers")
                        .HasForeignKey("PlantId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
