using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoolatyMVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddShippingRelatedTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shipping",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipping", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShippingServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Feature = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingServices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShippingServiceJunctions",
                columns: table => new
                {
                    ShippingId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingServiceJunctions", x => new { x.ShippingId, x.ServiceId });
                    table.ForeignKey(
                        name: "FK_ShippingServiceJunctions_ShippingServices_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "ShippingServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShippingServiceJunctions_Shipping_ShippingId",
                        column: x => x.ShippingId,
                        principalTable: "Shipping",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShippingServiceJunctions_ServiceId",
                table: "ShippingServiceJunctions",
                column: "ServiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShippingServiceJunctions");

            migrationBuilder.DropTable(
                name: "ShippingServices");

            migrationBuilder.DropTable(
                name: "Shipping");
        }
    }
}
