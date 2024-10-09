using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignalR.API_Food_DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class cart_discountcode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DiscountCode",
                table: "Carts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountCode",
                table: "Carts");
        }
    }
}
