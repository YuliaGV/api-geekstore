using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_geekstore.Data.Migrations
{
    public partial class newmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    first_name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    last_name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    birth_date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    phone_number = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    address = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    order_number = table.Column<int>(type: "INTEGER", nullable: false),
                    client_id = table.Column<int>(type: "INTEGER", nullable: false),
                    order_date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    delivery_date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "product_categories",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    category_name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    price = table.Column<decimal>(type: "TEXT", nullable: false),
                    category_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.id);
                    table.ForeignKey(
                        name: "FK_products_product_categories_category_id",
                        column: x => x.category_id,
                        principalTable: "product_categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "order-details",
                columns: table => new
                {
                    order_id = table.Column<int>(type: "INTEGER", nullable: false),
                    product_id = table.Column<int>(type: "INTEGER", nullable: false),
                    quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order-details", x => new { x.order_id, x.product_id });
                    table.ForeignKey(
                        name: "FK_order-details_orders_order_id",
                        column: x => x.order_id,
                        principalTable: "orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_order-details_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_order-details_product_id",
                table: "order-details",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_products_category_id",
                table: "products",
                column: "category_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "clients");

            migrationBuilder.DropTable(
                name: "order-details");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "product_categories");
        }
    }
}
