﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using QuickleeBackEnd;

namespace QuickleeBackEnd.Migrations
{
    [DbContext(typeof(QuickleeDatabaseContext))]
    [Migration("20181120203437_madeMoreControllers")]
    partial class madeMoreControllers
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("QuickleeBackEnd.Models.Inventories", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("InventoryDate");

                    b.Property<float>("InventoryTotal");

                    b.Property<int?>("UsersId");

                    b.HasKey("Id");

                    b.HasIndex("UsersId");

                    b.ToTable("Inventories");

                    b.HasData(
                        new { Id = -1, InventoryDate = new DateTime(2018, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), InventoryTotal = 26.91f, UsersId = -1 },
                        new { Id = -2, InventoryDate = new DateTime(2018, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), InventoryTotal = 26.91f, UsersId = -1 }
                    );
                });

            modelBuilder.Entity("QuickleeBackEnd.Models.InventoryDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("InventoriesId");

                    b.Property<float>("ItemOnHandCount");

                    b.Property<int>("ItemsId");

                    b.HasKey("Id");

                    b.HasIndex("InventoriesId");

                    b.HasIndex("ItemsId");

                    b.ToTable("InventoryDetails");

                    b.HasData(
                        new { Id = -1, InventoriesId = -1, ItemOnHandCount = 3f, ItemsId = -1 },
                        new { Id = -2, InventoriesId = -1, ItemOnHandCount = 3f, ItemsId = -2 },
                        new { Id = -3, InventoriesId = -1, ItemOnHandCount = 3f, ItemsId = -3 },
                        new { Id = -4, InventoriesId = -2, ItemOnHandCount = 3f, ItemsId = -1 },
                        new { Id = -5, InventoriesId = -2, ItemOnHandCount = 3f, ItemsId = -2 },
                        new { Id = -6, InventoriesId = -2, ItemOnHandCount = 3f, ItemsId = -3 }
                    );
                });

            modelBuilder.Entity("QuickleeBackEnd.Models.Items", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ItemName");

                    b.Property<float>("ItemPrice");

                    b.Property<int?>("UsersId");

                    b.HasKey("Id");

                    b.HasIndex("UsersId");

                    b.ToTable("Items");

                    b.HasData(
                        new { Id = -1, ItemName = "Item A", ItemPrice = 1.99f, UsersId = -1 },
                        new { Id = -2, ItemName = "Item B", ItemPrice = 2.99f, UsersId = -1 },
                        new { Id = -3, ItemName = "Item C", ItemPrice = 3.99f, UsersId = -1 }
                    );
                });

            modelBuilder.Entity("QuickleeBackEnd.Models.Reports", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("InventoriesBegin");

                    b.Property<float>("InventoriesEnd");

                    b.Property<float>("Purchases");

                    b.Property<DateTime>("ReportDate");

                    b.Property<float>("Sales");

                    b.Property<int?>("UsersId");

                    b.HasKey("Id");

                    b.HasIndex("UsersId");

                    b.ToTable("Reports");

                    b.HasData(
                        new { Id = -1, InventoriesBegin = 26.61f, InventoriesEnd = 26.61f, Purchases = 100.01f, ReportDate = new DateTime(2018, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Sales = 500.01f, UsersId = -1 }
                    );
                });

            modelBuilder.Entity("QuickleeBackEnd.Models.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompanyName");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new { Id = -1, CompanyName = "ABC Inc" }
                    );
                });

            modelBuilder.Entity("QuickleeBackEnd.Models.Inventories", b =>
                {
                    b.HasOne("QuickleeBackEnd.Models.Users", "Users")
                        .WithMany()
                        .HasForeignKey("UsersId");
                });

            modelBuilder.Entity("QuickleeBackEnd.Models.InventoryDetails", b =>
                {
                    b.HasOne("QuickleeBackEnd.Models.Inventories", "Inventories")
                        .WithMany()
                        .HasForeignKey("InventoriesId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("QuickleeBackEnd.Models.Items", "Items")
                        .WithMany()
                        .HasForeignKey("ItemsId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("QuickleeBackEnd.Models.Items", b =>
                {
                    b.HasOne("QuickleeBackEnd.Models.Users", "Users")
                        .WithMany()
                        .HasForeignKey("UsersId");
                });

            modelBuilder.Entity("QuickleeBackEnd.Models.Reports", b =>
                {
                    b.HasOne("QuickleeBackEnd.Models.Users", "Users")
                        .WithMany()
                        .HasForeignKey("UsersId");
                });
#pragma warning restore 612, 618
        }
    }
}
