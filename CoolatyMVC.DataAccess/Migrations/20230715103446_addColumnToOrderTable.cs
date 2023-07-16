using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoolatyMVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class addColumnToOrderTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppliedCoupon",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "discountAmount",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppliedCoupon",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "discountAmount",
                table: "Orders");
        }
    }
}
