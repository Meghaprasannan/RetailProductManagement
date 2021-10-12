using Microsoft.EntityFrameworkCore.Migrations;

namespace iStore.Migrations.ProductDb
{
    public partial class AddingSeedMethodsInProductDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 250, nullable: false),
                    Rating = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "Id", "Description", "Name", "Price", "Rating" },
                values: new object[,]
                {
                    { 1, "It has a 8GB Ram/512GB ROM and a processor of A15 bionic chip with a display of 6.7 inches", "iPhone13ProMax", 139900, 9.8m },
                    { 22, "It has a 6GB Ram/64GB ROM and a processor of A14 bionic chip with a display of 10.9 inches", "iPadAir", 54900, 9.1m },
                    { 21, "It has a 8GB Ram/128GB ROM and a processor of M1 chip with a display of 11 inches", "iPadPro", 71900, 9.5m },
                    { 20, "It has a 4GB Ram/64GB ROM and a processor of A10 bionic chip with a display of 4.7 inches", "iPhone7", 33900, 7.2m },
                    { 19, "It has a 4GB Ram/128GB ROM and a processor of A10 bionic chip with a display of 5.4 inches", "iPhone7Plus", 35900, 7.6m },
                    { 18, "It has a 4GB Ram/64GB ROM and a processor of A11 bionic chip with a display of 4.7 inches", "iPhone8", 38900, 7.5m },
                    { 17, "It has a 6GB Ram/128GB ROM and a processor of A11 bionic chip with a display of 5.5 inches", "iPhone8Plus", 40900, 7.9m },
                    { 16, "It has a 8GB Ram/64GB ROM and a processor of A12 bionic chip with a display of 6.1 inches", "iPhoneXR", 45900, 8.1m },
                    { 15, "It has a 6GB Ram/128GB ROM and a processor of A12 bionic chip with a display of 5.8 inches", "iPhoneXS", 49900, 8.3m },
                    { 14, "It has a 8GB Ram/512GB ROM and a processor of A12 bionic chip with a display of 6.5 inches", "iPhoneXSMAX", 55900, 8.8m },
                    { 13, "It has a 6GB Ram/256GB ROM and a processor of A13 bionic chip with a display of 5.8 inches", "iPhoneX", 52900, 8.5m },
                    { 12, "It has a 6GB Ram/128GB ROM and a processor of A13 bionic chip with a display of 6.1 inches", "iPhone11", 49900, 8.5m },
                    { 11, "It has a 8GB Ram/256GB ROM and a processor of A12 bionic chip with a display of 5.8 inches", "iPhone11Pro", 55900, 8.9m },
                    { 10, "It has a 8GB Ram/512GB ROM and a processor of A13 bionic chip with a display of 6.5 inches", "iPhone11ProMax", 65900, 9.1m },
                    { 9, "It has a 4GB Ram/64GB ROM and a processor of A14 bionic chip with a display of 6.7 inches", "iPhoneSE", 39900, 8.3m },
                    { 8, "It has a 6GB Ram/64GB ROM and a processor of A14 bionic chip with a display of 4.7 inches", "iPhone12Mini", 56900, 8.5m },
                    { 7, "It has a 6GB Ram/128GB ROM and a processor of A14 bionic chip with a display of 5.4 inches", "iPhone12", 59900, 9.1m },
                    { 6, "It has a 8GB Ram/256GB ROM and a processor of A14 bionic chip with a display of 6.1 inches", "iPhone12Pro", 90900, 9.3m },
                    { 5, "It has a 8GB Ram/512GB ROM and a processor of A14 bionic chip with a display of 6.7 inches", "iPhone12ProMax", 100900, 9.5m },
                    { 4, "It has a 4GB Ram/128GB ROM and a processor of A13 bionic chip with a display of 5.4 inches", "iPhone13Mini", 65900, 9.2m },
                    { 3, "It has a 8GB Ram/256GB ROM and a processor of A15 bionic chip with a display of 6.1 inches", "iPhone13", 69900, 9.4m },
                    { 2, "It has a 8GB Ram/256GB ROM and a processor of A15 bionic chip with a display of 6.1 inches", "iPhone13Pro", 119900, 9.6m },
                    { 23, "It has a 6GB Ram/128GB ROM and a processor of A13 bionic chip with a display of 10.2 inches", "iPad", 46900, 8.7m },
                    { 24, "It has a 4 GB Ram,64 GB of ROM and a processor of A15 bionic chip with a display of 8.3 inches", "iPadMini", 35900, 8.5m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "products");
        }
    }
}
