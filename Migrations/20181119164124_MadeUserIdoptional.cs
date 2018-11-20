using Microsoft.EntityFrameworkCore.Migrations;

namespace QuickleeBackEnd.Migrations
{
    public partial class MadeUserIdoptional : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Users_UsersId",
                table: "Items");

            migrationBuilder.AlterColumn<int>(
                name: "UsersId",
                table: "Items",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Users_UsersId",
                table: "Items",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Users_UsersId",
                table: "Items");

            migrationBuilder.AlterColumn<int>(
                name: "UsersId",
                table: "Items",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Users_UsersId",
                table: "Items",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
