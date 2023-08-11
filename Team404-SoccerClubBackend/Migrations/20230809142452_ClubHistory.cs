using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Team404_SoccerClubBackend.Migrations
{
    /// <inheritdoc />
    public partial class ClubHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_TBL_Competition_CompetitionId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_TBL_Team_TeamId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_TBL_MatchStats_Matches_MatchesId",
                table: "TBL_MatchStats");

            migrationBuilder.DropForeignKey(
                name: "FK_TBL_PlayerAchievement_Matches_MatchesId",
                table: "TBL_PlayerAchievement");

            migrationBuilder.DropForeignKey(
                name: "FK_TBL_PlayerStats_Matches_MatchesId",
                table: "TBL_PlayerStats");

            migrationBuilder.DropForeignKey(
                name: "FK_TBL_TeamStats_Matches_MatchesId",
                table: "TBL_TeamStats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Matches",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "Matches");

            migrationBuilder.RenameTable(
                name: "Matches",
                newName: "TBL_Matches");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_TeamId",
                table: "TBL_Matches",
                newName: "IX_TBL_Matches_TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_CompetitionId",
                table: "TBL_Matches",
                newName: "IX_TBL_Matches_CompetitionId");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "TBL_Matches",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_TBL_Matches",
                table: "TBL_Matches",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TBL_Matches_TBL_Competition_CompetitionId",
                table: "TBL_Matches",
                column: "CompetitionId",
                principalTable: "TBL_Competition",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TBL_Matches_TBL_Team_TeamId",
                table: "TBL_Matches",
                column: "TeamId",
                principalTable: "TBL_Team",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TBL_MatchStats_TBL_Matches_MatchesId",
                table: "TBL_MatchStats",
                column: "MatchesId",
                principalTable: "TBL_Matches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TBL_PlayerAchievement_TBL_Matches_MatchesId",
                table: "TBL_PlayerAchievement",
                column: "MatchesId",
                principalTable: "TBL_Matches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TBL_PlayerStats_TBL_Matches_MatchesId",
                table: "TBL_PlayerStats",
                column: "MatchesId",
                principalTable: "TBL_Matches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TBL_TeamStats_TBL_Matches_MatchesId",
                table: "TBL_TeamStats",
                column: "MatchesId",
                principalTable: "TBL_Matches",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBL_Matches_TBL_Competition_CompetitionId",
                table: "TBL_Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_TBL_Matches_TBL_Team_TeamId",
                table: "TBL_Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_TBL_MatchStats_TBL_Matches_MatchesId",
                table: "TBL_MatchStats");

            migrationBuilder.DropForeignKey(
                name: "FK_TBL_PlayerAchievement_TBL_Matches_MatchesId",
                table: "TBL_PlayerAchievement");

            migrationBuilder.DropForeignKey(
                name: "FK_TBL_PlayerStats_TBL_Matches_MatchesId",
                table: "TBL_PlayerStats");

            migrationBuilder.DropForeignKey(
                name: "FK_TBL_TeamStats_TBL_Matches_MatchesId",
                table: "TBL_TeamStats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TBL_Matches",
                table: "TBL_Matches");

            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "TBL_Matches");

            migrationBuilder.RenameTable(
                name: "TBL_Matches",
                newName: "Matches");

            migrationBuilder.RenameIndex(
                name: "IX_TBL_Matches_TeamId",
                table: "Matches",
                newName: "IX_Matches_TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_TBL_Matches_CompetitionId",
                table: "Matches",
                newName: "IX_Matches_CompetitionId");

            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "Matches",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Time",
                table: "Matches",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Matches",
                table: "Matches",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_TBL_Competition_CompetitionId",
                table: "Matches",
                column: "CompetitionId",
                principalTable: "TBL_Competition",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_TBL_Team_TeamId",
                table: "Matches",
                column: "TeamId",
                principalTable: "TBL_Team",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TBL_MatchStats_Matches_MatchesId",
                table: "TBL_MatchStats",
                column: "MatchesId",
                principalTable: "Matches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TBL_PlayerAchievement_Matches_MatchesId",
                table: "TBL_PlayerAchievement",
                column: "MatchesId",
                principalTable: "Matches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TBL_PlayerStats_Matches_MatchesId",
                table: "TBL_PlayerStats",
                column: "MatchesId",
                principalTable: "Matches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TBL_TeamStats_Matches_MatchesId",
                table: "TBL_TeamStats",
                column: "MatchesId",
                principalTable: "Matches",
                principalColumn: "Id");
        }
    }
}
