using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutomotiveProducts.Migrations
{
    /// <inheritdoc />
    public partial class addsupplierreftype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SupplierRefType",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SupplierRefType",
                table: "Product");
        }
    }
}
