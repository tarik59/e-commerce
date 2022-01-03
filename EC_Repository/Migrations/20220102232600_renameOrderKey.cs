using Microsoft.EntityFrameworkCore.Migrations;

namespace EC_Repository.Migrations
{
    public partial class renameOrderKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_AspNetUsers_AppUserId",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orders_AppUserId",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "orders");

            migrationBuilder.CreateIndex(
                name: "IX_orders_userId",
                table: "orders",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_AspNetUsers_userId",
                table: "orders",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_AspNetUsers_userId",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orders_userId",
                table: "orders");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "orders",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_orders_AppUserId",
                table: "orders",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_AspNetUsers_AppUserId",
                table: "orders",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
