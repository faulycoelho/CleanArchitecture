using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clean.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedProdutcs001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Products(Name,Description,Price,Stock,Image,CategoryId) " +
            "VALUES('Keyboard','Mecanic Keyboard',130.45,50,'keyboard_mecanic.jpg',1)");

            migrationBuilder.Sql("INSERT INTO Products(Name,Description,Price,Stock,Image,CategoryId) " +
            "VALUES('Mouse','Mouse',15.65,70,'mouse_new.jpg',1)");

            migrationBuilder.Sql("INSERT INTO Products(Name,Description,Price,Stock,Image,CategoryId) " +
            "VALUES('Office','Software MS Office',123.25,80,'msoffice.jpg',1)");

            migrationBuilder.Sql("INSERT INTO Products(Name,Description,Price,Stock,Image,CategoryId) " +
            "VALUES('ball','Simple ball',15.39,20,'ball1.jpg',2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Products");
        }
    }
}
