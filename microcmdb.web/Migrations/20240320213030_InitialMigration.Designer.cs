﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using microcmdb.Web.Data;

#nullable disable

namespace microcmdb.Web.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240320213030_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.17");

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

            modelBuilder.Entity("microcmdb.Web.Models.CINodeMapping", b =>
                {
                    b.Property<int>("ConfigItemID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NodeID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ConfigItemID", "NodeID");

                    b.HasIndex("NodeID");

                    b.ToTable("CINodeMappings");
                });

            modelBuilder.Entity("microcmdb.Web.Models.ConfigItem", b =>
                {
                    b.Property<int>("ConfigItemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DeployLoc")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LastUpdated")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Notes")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("PurchaseDate")
                        .HasColumnType("TEXT");

                    b.HasKey("ConfigItemID");

                    b.ToTable("ConfigItems");
                });

            modelBuilder.Entity("microcmdb.Web.Models.Host", b =>
                {
                    b.Property<int>("HostID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("NodeId")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.HasKey("HostID");

                    b.HasIndex("NodeId")
                        .IsUnique();

                    b.ToTable("Hosts");
                });

            modelBuilder.Entity("microcmdb.Web.Models.HostServiceMapping", b =>
                {
                    b.Property<int>("HostID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ServiceID")
                        .HasColumnType("INTEGER");

                    b.HasKey("HostID", "ServiceID");

                    b.HasIndex("ServiceID");

                    b.ToTable("HostServiceMappings");
                });

            modelBuilder.Entity("microcmdb.Web.Models.NetworkUser", b =>
                {
                    b.Property<int>("NetworkUserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Firstname")
                        .HasColumnType("TEXT");

                    b.Property<string>("Lastname")
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("NetworkUserID");

                    b.ToTable("NetworkUsers");
                });

            modelBuilder.Entity("microcmdb.Web.Models.NetworkUserMapping", b =>
                {
                    b.Property<int>("NodeID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NetworkUserID")
                        .HasColumnType("INTEGER");

                    b.HasKey("NodeID", "NetworkUserID");

                    b.HasIndex("NetworkUserID");

                    b.ToTable("UserMappings");
                });

            modelBuilder.Entity("microcmdb.Web.Models.Node", b =>
                {
                    b.Property<int>("NodeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CPU_Arch")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("ConfigItemID")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("HostId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("IPaddr")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("OS_Version")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double?>("RAM")
                        .HasColumnType("REAL");

                    b.Property<double?>("Storage")
                        .HasColumnType("REAL");

                    b.HasKey("NodeID");

                    b.HasIndex("ConfigItemID")
                        .IsUnique();

                    b.ToTable("Nodes");
                });

            modelBuilder.Entity("microcmdb.Web.Models.NodeHostMapping", b =>
                {
                    b.Property<int>("NodeID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HostID")
                        .HasColumnType("INTEGER");

                    b.HasKey("NodeID", "HostID");

                    b.HasIndex("HostID");

                    b.ToTable("NodeHostMappings");
                });

            modelBuilder.Entity("microcmdb.Web.Models.Service", b =>
                {
                    b.Property<int>("ServiceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("HostId")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.Property<int>("PortNum")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Protocol")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ServiceID");

                    b.HasIndex("HostId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("microcmdb.Web.Models.Software", b =>
                {
                    b.Property<int>("SoftwareID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Developer")
                        .HasColumnType("TEXT");

                    b.Property<string>("LicenseType")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("SoftwareID");

                    b.ToTable("Software");
                });

            modelBuilder.Entity("microcmdb.Web.Models.SoftwareInstallation", b =>
                {
                    b.Property<int>("NodeID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SoftwareID")
                        .HasColumnType("INTEGER");

                    b.HasKey("NodeID", "SoftwareID");

                    b.HasIndex("SoftwareID");

                    b.ToTable("SoftwareInstallations");
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

            modelBuilder.Entity("microcmdb.Web.Models.CINodeMapping", b =>
                {
                    b.HasOne("microcmdb.Web.Models.ConfigItem", "ConfigItem")
                        .WithMany()
                        .HasForeignKey("ConfigItemID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("microcmdb.Web.Models.Node", "Node")
                        .WithMany()
                        .HasForeignKey("NodeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ConfigItem");

                    b.Navigation("Node");
                });

            modelBuilder.Entity("microcmdb.Web.Models.Host", b =>
                {
                    b.HasOne("microcmdb.Web.Models.Node", "Node")
                        .WithOne("Host")
                        .HasForeignKey("microcmdb.Web.Models.Host", "NodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Node");
                });

            modelBuilder.Entity("microcmdb.Web.Models.HostServiceMapping", b =>
                {
                    b.HasOne("microcmdb.Web.Models.Host", "Host")
                        .WithMany()
                        .HasForeignKey("HostID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("microcmdb.Web.Models.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Host");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("microcmdb.Web.Models.NetworkUserMapping", b =>
                {
                    b.HasOne("microcmdb.Web.Models.NetworkUser", "NetworkUser")
                        .WithMany("AllowedNodes")
                        .HasForeignKey("NetworkUserID")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.HasOne("microcmdb.Web.Models.Node", "Node")
                        .WithMany("NetworkUsers")
                        .HasForeignKey("NodeID")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("NetworkUser");

                    b.Navigation("Node");
                });

            modelBuilder.Entity("microcmdb.Web.Models.Node", b =>
                {
                    b.HasOne("microcmdb.Web.Models.ConfigItem", "ConfigItem")
                        .WithOne("Node")
                        .HasForeignKey("microcmdb.Web.Models.Node", "ConfigItemID")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("ConfigItem");
                });

            modelBuilder.Entity("microcmdb.Web.Models.NodeHostMapping", b =>
                {
                    b.HasOne("microcmdb.Web.Models.Host", "Host")
                        .WithMany()
                        .HasForeignKey("HostID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("microcmdb.Web.Models.Node", "Node")
                        .WithMany()
                        .HasForeignKey("NodeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Host");

                    b.Navigation("Node");
                });

            modelBuilder.Entity("microcmdb.Web.Models.Service", b =>
                {
                    b.HasOne("microcmdb.Web.Models.Host", "Host")
                        .WithMany("Services")
                        .HasForeignKey("HostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Host");
                });

            modelBuilder.Entity("microcmdb.Web.Models.SoftwareInstallation", b =>
                {
                    b.HasOne("microcmdb.Web.Models.Node", "Node")
                        .WithMany("InstalledSoftware")
                        .HasForeignKey("NodeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("microcmdb.Web.Models.Software", "Software")
                        .WithMany("Installations")
                        .HasForeignKey("SoftwareID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Node");

                    b.Navigation("Software");
                });

            modelBuilder.Entity("microcmdb.Web.Models.ConfigItem", b =>
                {
                    b.Navigation("Node");
                });

            modelBuilder.Entity("microcmdb.Web.Models.Host", b =>
                {
                    b.Navigation("Services");
                });

            modelBuilder.Entity("microcmdb.Web.Models.NetworkUser", b =>
                {
                    b.Navigation("AllowedNodes");
                });

            modelBuilder.Entity("microcmdb.Web.Models.Node", b =>
                {
                    b.Navigation("Host")
                        .IsRequired();

                    b.Navigation("InstalledSoftware");

                    b.Navigation("NetworkUsers");
                });

            modelBuilder.Entity("microcmdb.Web.Models.Software", b =>
                {
                    b.Navigation("Installations");
                });
#pragma warning restore 612, 618
        }
    }
}
