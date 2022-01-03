using Microsoft.EntityFrameworkCore.Migrations;

namespace EC_Repository.Migrations
{
    public partial class AddOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_AspNetUsers_AppUserId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Status_statusId",
                table: "Order");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_OrderProduct_Order_ordersId",
            //    table: "OrderProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductInOrder_Order_orderId",
                table: "ProductInOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "orders");

            migrationBuilder.RenameIndex(
                name: "IX_Order_statusId",
                table: "orders",
                newName: "IX_orders_statusId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_AppUserId",
                table: "orders",
                newName: "IX_orders_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_orders",
                table: "orders",
                column: "Id");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_OrderProduct_orders_ordersId",
            //    table: "OrderProduct",
            //    column: "ordersId",
            //    principalTable: "orders",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_AspNetUsers_AppUserId",
                table: "orders",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_Status_statusId",
                table: "orders",
                column: "statusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInOrder_orders_orderId",
                table: "ProductInOrder",
                column: "orderId",
                principalTable: "orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_OrderProduct_orders_ordersId",
            //    table: "OrderProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_AspNetUsers_AppUserId",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_Status_statusId",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductInOrder_orders_orderId",
                table: "ProductInOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_orders",
                table: "orders");

            migrationBuilder.RenameTable(
                name: "orders",
                newName: "Order");

            migrationBuilder.RenameIndex(
                name: "IX_orders_statusId",
                table: "Order",
                newName: "IX_Order_statusId");

            migrationBuilder.RenameIndex(
                name: "IX_orders_AppUserId",
                table: "Order",
                newName: "IX_Order_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_AspNetUsers_AppUserId",
                table: "Order",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Status_statusId",
                table: "Order",
                column: "statusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_OrderProduct_Order_ordersId",
            //    table: "OrderProduct",
            //    column: "ordersId",
            //    principalTable: "Order",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInOrder_Order_orderId",
                table: "ProductInOrder",
                column: "orderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
