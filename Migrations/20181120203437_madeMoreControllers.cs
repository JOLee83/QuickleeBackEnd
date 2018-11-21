using Microsoft.EntityFrameworkCore.Migrations;

namespace QuickleeBackEnd.Migrations
{
    public partial class madeMoreControllers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Inventories_InventoriesBeginId",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Inventories_InventoriesEndId",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_InventoriesBeginId",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_InventoriesEndId",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "InventoriesBeginId",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "InventoriesEndId",
                table: "Reports");

            migrationBuilder.AddColumn<float>(
                name: "InventoriesBegin",
                table: "Reports",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "InventoriesEnd",
                table: "Reports",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "UsersId",
                table: "Reports",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "InventoriesBegin", "InventoriesEnd", "UsersId" },
                values: new object[] { 26.61f, 26.61f, -1 });

            migrationBuilder.CreateIndex(
                name: "IX_Reports_UsersId",
                table: "Reports",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Users_UsersId",
                table: "Reports",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Users_UsersId",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_UsersId",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "InventoriesBegin",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "InventoriesEnd",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "Reports");

            migrationBuilder.AddColumn<int>(
                name: "InventoriesBeginId",
                table: "Reports",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InventoriesEndId",
                table: "Reports",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "InventoriesBeginId", "InventoriesEndId" },
                values: new object[] { -1, -2 });

            migrationBuilder.CreateIndex(
                name: "IX_Reports_InventoriesBeginId",
                table: "Reports",
                column: "InventoriesBeginId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_InventoriesEndId",
                table: "Reports",
                column: "InventoriesEndId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Inventories_InventoriesBeginId",
                table: "Reports",
                column: "InventoriesBeginId",
                principalTable: "Inventories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Inventories_InventoriesEndId",
                table: "Reports",
                column: "InventoriesEndId",
                principalTable: "Inventories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
