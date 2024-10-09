using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignalR.API_Food_DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class add_mig_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DiscountRate",
                table: "Carts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountRate",
                table: "Carts");
        }
    }
}
