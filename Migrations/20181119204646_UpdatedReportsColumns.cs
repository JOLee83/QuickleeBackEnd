using Microsoft.EntityFrameworkCore.Migrations;

namespace QuickleeBackEnd.Migrations
{
    public partial class UpdatedReportsColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Users_UsersId",
                table: "Inventories");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Inventories_InventoriesId",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_InventoriesId",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "InventoriesId",
                table: "Reports");

            migrationBuilder.RenameColumn(
                name: "InventoriesIdEnd",
                table: "Reports",
                newName: "InventoriesEndId");

            migrationBuilder.RenameColumn(
                name: "InventoriesIdBegin",
                table: "Reports",
                newName: "InventoriesBeginId");

            migrationBuilder.AlterColumn<int>(
                name: "UsersId",
                table: "Inventories",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Reports_InventoriesBeginId",
                table: "Reports",
                column: "InventoriesBeginId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_InventoriesEndId",
                table: "Reports",
                column: "InventoriesEndId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Users_UsersId",
                table: "Inventories",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Users_UsersId",
                table: "Inventories");

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

            migrationBuilder.RenameColumn(
                name: "InventoriesEndId",
                table: "Reports",
                newName: "InventoriesIdEnd");

            migrationBuilder.RenameColumn(
                name: "InventoriesBeginId",
                table: "Reports",
                newName: "InventoriesIdBegin");

            migrationBuilder.AddColumn<int>(
                name: "InventoriesId",
                table: "Reports",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UsersId",
                table: "Inventories",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reports_InventoriesId",
                table: "Reports",
                column: "InventoriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Users_UsersId",
                table: "Inventories",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Inventories_InventoriesId",
                table: "Reports",
                column: "InventoriesId",
                principalTable: "Inventories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
