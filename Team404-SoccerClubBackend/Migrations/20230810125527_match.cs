using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Team404_SoccerClubBackend.Migrations
{
    /// <inheritdoc />
    public partial class match : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "TBL_MatchStats");

            migrationBuilder.RenameColumn(
                name: "Stadium",
                table: "TBL_MatchStats",
                newName: "Weather");

            migrationBuilder.AddColumn<bool>(
                name: "Club",
                table: "TBL_Team",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Details",
                table: "TBL_MatchStats",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Goals",
                table: "TBL_MatchStats",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Stadium",
                table: "TBL_Matches",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Winner",
                table: "TBL_Matches",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Club",
                table: "TBL_Team");

            migrationBuilder.DropColumn(
                name: "Details",
                table: "TBL_MatchStats");

            migrationBuilder.DropColumn(
                name: "Goals",
                table: "TBL_MatchStats");

            migrationBuilder.DropColumn(
                name: "Stadium",
                table: "TBL_Matches");

            migrationBuilder.DropColumn(
                name: "Winner",
                table: "TBL_Matches");

            migrationBuilder.RenameColumn(
                name: "Weather",
                table: "TBL_MatchStats",
                newName: "Stadium");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "TBL_MatchStats",
                type: "datetime2",
                nullable: true);
        }
    }
}
