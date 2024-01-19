﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using uCMDB.API.Data;

#nullable disable

namespace uCMDB.API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240119001029_uCMDB_Migration")]
    partial class uCMDB_Migration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.1");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("uCMDB.API.Models.Service", b =>
                {
                    b.Property<int>("Service_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Service_HostHost_ID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Service_Port")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Service_Protocol")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Service_URL")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Service_Id");

                    b.HasIndex("Service_HostHost_ID");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("uCMDB.API.Models.Service_Host", b =>
                {
                    b.Property<int>("Host_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Host_IP")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Host_Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Host_ID");

                    b.ToTable("Hosts");
                });

            modelBuilder.Entity("uCMDB.API.Models.Service_Node", b =>
                {
                    b.Property<int>("Node_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Node_CPU_Arch")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Node_Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Node_OS_Ver")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Node_RAM")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Node_Storage")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Service_HostHost_ID")
                        .HasColumnType("INTEGER");

                    b.HasKey("Node_Id");

                    b.HasIndex("Service_HostHost_ID");

                    b.ToTable("NetworkNodes");
                });

            modelBuilder.Entity("uCMDB.API.Models.Software", b =>
                {
                    b.Property<int>("Software_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Developer")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("InstallExecPath")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LicenceType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("Service_HostHost_ID")
                        .HasColumnType("INTEGER");

                    b.HasKey("Software_ID");

                    b.HasIndex("Service_HostHost_ID");

                    b.ToTable("Software");
                });

            modelBuilder.Entity("uCMDB.API.Models.User", b =>
                {
                    b.Property<int>("User_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Service_HostHost_ID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("User_Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("User_passwd")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("User_ID");

                    b.HasIndex("Service_HostHost_ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("uCMDB.API.Models.Service", b =>
                {
                    b.HasOne("uCMDB.API.Models.Service_Host", null)
                        .WithMany("Services")
                        .HasForeignKey("Service_HostHost_ID");
                });

            modelBuilder.Entity("uCMDB.API.Models.Service_Node", b =>
                {
                    b.HasOne("uCMDB.API.Models.Service_Host", null)
                        .WithMany("NetworkNodes")
                        .HasForeignKey("Service_HostHost_ID");
                });

            modelBuilder.Entity("uCMDB.API.Models.Software", b =>
                {
                    b.HasOne("uCMDB.API.Models.Service_Host", null)
                        .WithMany("Software")
                        .HasForeignKey("Service_HostHost_ID");
                });

            modelBuilder.Entity("uCMDB.API.Models.User", b =>
                {
                    b.HasOne("uCMDB.API.Models.Service_Host", null)
                        .WithMany("Users")
                        .HasForeignKey("Service_HostHost_ID");
                });

            modelBuilder.Entity("uCMDB.API.Models.Service_Host", b =>
                {
                    b.Navigation("NetworkNodes");

                    b.Navigation("Services");

                    b.Navigation("Software");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
