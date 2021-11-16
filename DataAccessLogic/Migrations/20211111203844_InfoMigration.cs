using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLogic.Migrations
{
    public partial class InfoMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    customer_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    address = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    email = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    phone_number = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer", x => x.customer_id);
                });

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    product_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    price = table.Column<decimal>(type: "decimal(7,2)", nullable: false),
                    description = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    brand = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    category = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.product_id);
                });

            migrationBuilder.CreateTable(
                name: "storefront",
                columns: table => new
                {
                    storeFront_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    address = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_storefront", x => x.storeFront_id);
                });

            migrationBuilder.CreateTable(
                name: "lineitem",
                columns: table => new
                {
                    lineitem_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    storefront_id = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    StorefrontId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lineitem", x => x.lineitem_id);
                    table.ForeignKey(
                        name: "FK__lineitem__produc__72C60C4A",
                        column: x => x.product_id,
                        principalTable: "product",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__lineitem__storef__73BA3083",
                        column: x => x.storefront_id,
                        principalTable: "storefront",
                        principalColumn: "storeFront_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_lineitem_storefront_StorefrontId",
                        column: x => x.StorefrontId,
                        principalTable: "storefront",
                        principalColumn: "storeFront_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "order_",
                columns: table => new
                {
                    order_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    storefront_id = table.Column<int>(type: "int", nullable: false),
                    customer_id = table.Column<int>(type: "int", nullable: false),
                    address = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    total_price = table.Column<decimal>(type: "decimal(8,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_", x => x.order_id);
                    table.ForeignKey(
                        name: "FK__order___customer__7A672E12",
                        column: x => x.customer_id,
                        principalTable: "customer",
                        principalColumn: "customer_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__order___storefro__7B5B524B",
                        column: x => x.storefront_id,
                        principalTable: "storefront",
                        principalColumn: "storeFront_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LineItemsOrders",
                columns: table => new
                {
                    LineItemsId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineItemsOrders", x => new { x.LineItemsId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_LineItemsOrders_lineitem_LineItemsId",
                        column: x => x.LineItemsId,
                        principalTable: "lineitem",
                        principalColumn: "lineitem_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LineItemsOrders_order__OrderId",
                        column: x => x.OrderId,
                        principalTable: "order_",
                        principalColumn: "order_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_lineitem_product_id",
                table: "lineitem",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_lineitem_storefront_id",
                table: "lineitem",
                column: "storefront_id");

            migrationBuilder.CreateIndex(
                name: "IX_lineitem_StorefrontId",
                table: "lineitem",
                column: "StorefrontId");

            migrationBuilder.CreateIndex(
                name: "IX_LineItemsOrders_OrderId",
                table: "LineItemsOrders",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_order__customer_id",
                table: "order_",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_order__storefront_id",
                table: "order_",
                column: "storefront_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LineItemsOrders");

            migrationBuilder.DropTable(
                name: "lineitem");

            migrationBuilder.DropTable(
                name: "order_");

            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "customer");

            migrationBuilder.DropTable(
                name: "storefront");
        }
    }
}
