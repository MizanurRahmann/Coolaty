using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoolatyMVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class addColumnToShopingCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "discountAmount",
                table: "Orders",
                newName: "DiscountAmount");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "ShopingCarts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "ShopingCarts");

            migrationBuilder.RenameColumn(
                name: "DiscountAmount",
                table: "Orders",
                newName: "discountAmount");
        }
    }
}
