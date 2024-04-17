using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loyalty_Points_Exchange_System.Migrations
{
    /// <inheritdoc />
    public partial class addItemColumnOnEarnPointTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "earnPoints",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "earnPoints");
        }
    }
}
