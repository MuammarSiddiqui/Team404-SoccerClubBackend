using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Team404_SoccerClubBackend.Migrations
{
    /// <inheritdoc />
    public partial class cart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnitPrice",
                table: "TBL_OrderItem");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "UnitPrice",
                table: "TBL_OrderItem",
                type: "decimal(18,2)",
                nullable: true);
        }
    }
}
