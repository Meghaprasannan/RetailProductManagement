using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace iStore.Migrations.ProductDb
{
    public partial class AddedVendortables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "vendors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendorName = table.Column<string>(nullable: true),
                    DeliveryCharge = table.Column<int>(nullable: false),
                    Rating = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vendors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "vendorStocks",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false),
                    VendorID = table.Column<int>(nullable: false),
                    StockInHand = table.Column<int>(nullable: false),
                    ExpectedStockReplinshmentDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 23,
                column: "Price",
                value: 46900);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "vendors");

            migrationBuilder.DropTable(
                name: "vendorStocks");

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 23,
                column: "Price",
                value: 36900);
        }
    }
}
