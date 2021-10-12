using Microsoft.EntityFrameworkCore.Migrations;

namespace iStore.Migrations.ProductDb
{
    public partial class CorrectedVendorStock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into vendorStocks values(1,1,20,'10/10/2021')");

            migrationBuilder.Sql("insert into vendorStocks values(2,1,20,'10/10/2021')");
            migrationBuilder.Sql("insert into vendorStocks values(3,1,20,'11/10/2021')");
            migrationBuilder.Sql("insert into vendorStocks values(4,1,20,'11/10/2021')");
            migrationBuilder.Sql("insert into vendorStocks values(5,1,20,'09/10/2021')");
            migrationBuilder.Sql("insert into vendorStocks values(6,1,20,'08/10/2021')");
            migrationBuilder.Sql("insert into vendorStocks values(7,2,20,'12/10/2021')");
            migrationBuilder.Sql("insert into vendorStocks values(8,2,20,'2021-10-21')");
            migrationBuilder.Sql("insert into vendorStocks values(9,2,20,'12/10/2021')");
            migrationBuilder.Sql("insert into vendorStocks values(10,2,20,'10/10/2021')");
            migrationBuilder.Sql("insert into vendorStocks values(11,2,20,'09/10/2021')");
            migrationBuilder.Sql("insert into vendorStocks values(12,2,20,'08/10/2021')");
            migrationBuilder.Sql("insert into vendorStocks values(13,3,20,'09/10/2021')");
            migrationBuilder.Sql("insert into vendorStocks values(14,3,20,'06/10/2021')");
            migrationBuilder.Sql("insert into vendorStocks values(15,2,20,'05/10/2021')");
            migrationBuilder.Sql("insert into vendorStocks values(16,2,5,'10/10/2021')");
            migrationBuilder.Sql("insert into vendorStocks values(17,3,20,'09/10/2021')");
            migrationBuilder.Sql("insert into vendorStocks values(18,3,20,'08/10/2021')");
            migrationBuilder.Sql("insert into vendorStocks values(19,4,20,'2021-10-21')");
            migrationBuilder.Sql("insert into vendorStocks values(20,4,20,'09/10/2021')");
            migrationBuilder.Sql("insert into vendorStocks values(21,4,20,'10/10/2021')");
            migrationBuilder.Sql("insert into vendorStocks values(22,4,20,'11/10/2021')");
            migrationBuilder.Sql("insert into vendorStocks values(23,4,20,'12/10/2021')");
            migrationBuilder.Sql("insert into vendorStocks values(24,4,20,'09/10/2021')");
            migrationBuilder.Sql("insert into vendorStocks values(1,5,20,'11/10/2021')");
            migrationBuilder.Sql("insert into vendorStocks values(2,5,20,'10/10/2021')");
            migrationBuilder.Sql("insert into vendorStocks values(3,5,20,'09/10/2021')");
            migrationBuilder.Sql("insert into vendorStocks values(4,5,20,'11/10/2021')");
            migrationBuilder.Sql("insert into vendorStocks values(5,5,20,'12/10/2021')");
            migrationBuilder.Sql("insert into vendorStocks values(6,5,20,'09/10/2021')");
            migrationBuilder.Sql("insert into vendorStocks values(7,6,20,'09/10/2021')");
            migrationBuilder.Sql("insert into vendorStocks values(8,6,20,'10/10/2021')");
            migrationBuilder.Sql("insert into vendorStocks values(9,6,20,'11/10/2021')");
            migrationBuilder.Sql("insert into vendorStocks values(10,6,20,'12/10/2021')");
            migrationBuilder.Sql("insert into vendorStocks values(11,6,20,'2021-10-21')");
            migrationBuilder.Sql("insert into vendorStocks values(12,6,20,'2012-10-21')");
            migrationBuilder.Sql("insert into vendorStocks values(13,7,20,'11/10/2021')");
            migrationBuilder.Sql("insert into vendorStocks values(14,7,20,'09/10/2021')");
            migrationBuilder.Sql("insert into vendorStocks values(15,7,20,'10/10/2021')");
            migrationBuilder.Sql("insert into vendorStocks values(16,7,20,'11/10/2021')");
            migrationBuilder.Sql("insert into vendorStocks values(17,7,20,'09/10/2021')");
            migrationBuilder.Sql("insert into vendorStocks values(18,7,20,'11/10/2021')");
            migrationBuilder.Sql("insert into vendorStocks values(19,8,20,'12/10/2021')");
            migrationBuilder.Sql("insert into vendorStocks values(20,8,20,'11/10/2021')");
            migrationBuilder.Sql("insert into vendorStocks values(21,8,20,'09/10/2021')");
            migrationBuilder.Sql("insert into vendorStocks values(22,8,20,'08/10/2021')");
            migrationBuilder.Sql("insert into vendorStocks values(23,8,20,'12/10/2021')");
            migrationBuilder.Sql("insert into vendorStocks values(24,8,20,'2012-02-21')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("truncate table vendorStocks");
        }
    }
}
