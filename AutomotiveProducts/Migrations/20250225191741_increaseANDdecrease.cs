using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutomotiveProducts.Migrations
{
    /// <inheritdoc />
    public partial class increaseANDdecrease : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StockId",
                table: "Stocks",
                newName: "QuantitySent");

            migrationBuilder.AddColumn<long>(
                name: "ProductId",
                table: "Stocks",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "QuantityReceived",
                table: "Stocks",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "QuantityReceived",
                table: "Stocks");

            migrationBuilder.RenameColumn(
                name: "QuantitySent",
                table: "Stocks",
                newName: "StockId");
        }
    }
}
