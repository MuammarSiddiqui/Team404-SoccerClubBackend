using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Team404_SoccerClubBackend.Migrations
{
    /// <inheritdoc />
    public partial class matchstats : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Winner",
                table: "TBL_Matches");

            migrationBuilder.AddColumn<string>(
                name: "Winner",
                table: "TBL_MatchStats",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Winner",
                table: "TBL_MatchStats");

            migrationBuilder.AddColumn<string>(
                name: "Winner",
                table: "TBL_Matches",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
