using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace QuickleeBackEnd.Migrations
{
    public partial class AddedDummyData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CompanyName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    InventoryTotal = table.Column<float>(nullable: false),
                    InventoryDate = table.Column<DateTime>(nullable: false),
                    UsersId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventories_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ItemName = table.Column<string>(nullable: true),
                    ItemPrice = table.Column<float>(nullable: false),
                    UsersId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Sales = table.Column<float>(nullable: false),
                    Purchases = table.Column<float>(nullable: false),
                    ReportDate = table.Column<DateTime>(nullable: false),
                    InventoriesIdBegin = table.Column<int>(nullable: false),
                    InventoriesIdEnd = table.Column<int>(nullable: false),
                    InventoriesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reports_Inventories_InventoriesId",
                        column: x => x.InventoriesId,
                        principalTable: "Inventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InventoryDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ItemsId = table.Column<int>(nullable: false),
                    ItemOnHandCount = table.Column<float>(nullable: false),
                    InventoriesId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryDetails_Inventories_InventoriesId",
                        column: x => x.InventoriesId,
                        principalTable: "Inventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryDetails_Items_ItemsId",
                        column: x => x.ItemsId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "Id", "InventoriesId", "InventoriesIdBegin", "InventoriesIdEnd", "Purchases", "ReportDate", "Sales" },
                values: new object[] { -1, null, -1, -2, 100.01f, new DateTime(2018, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 500.01f });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CompanyName" },
                values: new object[] { -1, "ABC Inc" });

            migrationBuilder.InsertData(
                table: "Inventories",
                columns: new[] { "Id", "InventoryDate", "InventoryTotal", "UsersId" },
                values: new object[,]
                {
                    { -1, new DateTime(2018, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 26.91f, -1 },
                    { -2, new DateTime(2018, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 26.91f, -1 }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "ItemName", "ItemPrice", "UsersId" },
                values: new object[,]
                {
                    { -1, "Item A", 1.99f, -1 },
                    { -2, "Item B", 2.99f, -1 },
                    { -3, "Item C", 3.99f, -1 }
                });

            migrationBuilder.InsertData(
                table: "InventoryDetails",
                columns: new[] { "Id", "InventoriesId", "ItemOnHandCount", "ItemsId" },
                values: new object[,]
                {
                    { -1, -1, 3f, -1 },
                    { -4, -2, 3f, -1 },
                    { -2, -1, 3f, -2 },
                    { -5, -2, 3f, -2 },
                    { -3, -1, 3f, -3 },
                    { -6, -2, 3f, -3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_UsersId",
                table: "Inventories",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryDetails_InventoriesId",
                table: "InventoryDetails",
                column: "InventoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryDetails_ItemsId",
                table: "InventoryDetails",
                column: "ItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_UsersId",
                table: "Items",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_InventoriesId",
                table: "Reports",
                column: "InventoriesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryDetails");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
