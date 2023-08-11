using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Team404_SoccerClubBackend.Migrations
{
    /// <inheritdoc />
    public partial class useraddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBL_PlayerStats_TBL_Matches_MatchesId",
                table: "TBL_PlayerStats");

            migrationBuilder.DropIndex(
                name: "IX_TBL_PlayerStats_MatchesId",
                table: "TBL_PlayerStats");

            migrationBuilder.DropColumn(
                name: "MatchesId",
                table: "TBL_PlayerStats");

            migrationBuilder.AddColumn<string>(
                name: "Height",
                table: "TBL_Player",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShirtNumber",
                table: "TBL_Player",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Weight",
                table: "TBL_Player",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Height",
                table: "TBL_Player");

            migrationBuilder.DropColumn(
                name: "ShirtNumber",
                table: "TBL_Player");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "TBL_Player");

            migrationBuilder.AddColumn<Guid>(
                name: "MatchesId",
                table: "TBL_PlayerStats",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TBL_PlayerStats_MatchesId",
                table: "TBL_PlayerStats",
                column: "MatchesId");

            migrationBuilder.AddForeignKey(
                name: "FK_TBL_PlayerStats_TBL_Matches_MatchesId",
                table: "TBL_PlayerStats",
                column: "MatchesId",
                principalTable: "TBL_Matches",
                principalColumn: "Id");
        }
    }
}
