using Microsoft.EntityFrameworkCore.Migrations;

namespace iStore.Migrations.ProductDb
{
    public partial class AddSeedingInVendor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into Vendors values('Mumbai',100,9.7)");
            migrationBuilder.Sql("insert into Vendors values('Chennai',90,9.5)");
            migrationBuilder.Sql("insert into Vendors values('Kolkata',150,9.3)");
            migrationBuilder.Sql("insert into Vendors values('Hyderabad',100,8.8)");
            migrationBuilder.Sql("insert into Vendors values('Jaipur',80,8.2)");
            migrationBuilder.Sql("insert into Vendors values('Delhi',120,8.0)");
            migrationBuilder.Sql("insert into Vendors values('Amirtsar',50,7.6)");
            migrationBuilder.Sql("insert into Vendors values('Bangalore',100,7.2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("truncate table Vendor");
        }
    }
}
