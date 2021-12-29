using Microsoft.EntityFrameworkCore.Migrations;

namespace EC_Repository.Migrations
{
    public partial class CreateDbTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "UserName",
            //    table: "AspNetUsers");

            //migrationBuilder.RenameColumn(
            //    name: "Username",
            //    table: "AspNetUsers",
            //    newName: "UserName");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "shoppingCarts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    AppUserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shoppingCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_shoppingCarts_AspNetUsers_AppUserId1",
                        column: x => x.AppUserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "typeOfProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_typeOfProducts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    brandId = table.Column<int>(type: "int", nullable: false),
                    genderId = table.Column<int>(type: "int", nullable: false),
                    typeOfProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_brands_brandId",
                        column: x => x.brandId,
                        principalTable: "brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Genders_genderId",
                        column: x => x.genderId,
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_typeOfProducts_typeOfProductId",
                        column: x => x.typeOfProductId,
                        principalTable: "typeOfProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productInShoppingCarts",
                columns: table => new
                {
                    productId = table.Column<int>(type: "int", nullable: false),
                    shoppingCartId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productInShoppingCarts", x => new { x.shoppingCartId, x.productId });
                    table.ForeignKey(
                        name: "FK_productInShoppingCarts_Products_productId",
                        column: x => x.productId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_productInShoppingCarts_shoppingCarts_shoppingCartId",
                        column: x => x.shoppingCartId,
                        principalTable: "shoppingCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            //migrationBuilder.CreateTable(
            //    name: "ProductShoppingCart",
            //    columns: table => new
            //    {
            //        productsId = table.Column<int>(type: "int", nullable: false),
            //        shoppingCartsId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ProductShoppingCart", x => new { x.productsId, x.shoppingCartsId });
            //        table.ForeignKey(
            //            name: "FK_ProductShoppingCart_Products_productsId",
            //            column: x => x.productsId,
            //            principalTable: "Products",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_ProductShoppingCart_shoppingCarts_shoppingCartsId",
            //            column: x => x.shoppingCartsId,
            //            principalTable: "shoppingCarts",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            migrationBuilder.CreateIndex(
                name: "IX_productInShoppingCarts_productId",
                table: "productInShoppingCarts",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_brandId",
                table: "Products",
                column: "brandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_genderId",
                table: "Products",
                column: "genderId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_typeOfProductId",
                table: "Products",
                column: "typeOfProductId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ProductShoppingCart_shoppingCartsId",
            //    table: "ProductShoppingCart",
            //    column: "shoppingCartsId");

            migrationBuilder.CreateIndex(
                name: "IX_shoppingCarts_AppUserId1",
                table: "shoppingCarts",
                column: "AppUserId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "productInShoppingCarts");

            //migrationBuilder.DropTable(
            //    name: "ProductShoppingCart");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "shoppingCarts");

            migrationBuilder.DropTable(
                name: "brands");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "typeOfProducts");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "AspNetUsers",
                newName: "Username");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "UserName",
            //    table: "AspNetUsers",
            //    type: "nvarchar(256)",
            //    maxLength: 256,
            //    nullable: true);
        }
    }
}
