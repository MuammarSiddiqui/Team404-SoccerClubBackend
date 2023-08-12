using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Team404_SoccerClubBackend.Migrations
{
    /// <inheritdoc />
    public partial class useraddressid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserAddressesId",
                table: "TBL_Order",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TBL_Order_UserAddressesId",
                table: "TBL_Order",
                column: "UserAddressesId");

            migrationBuilder.AddForeignKey(
                name: "FK_TBL_Order_TBL_UserAddresses_UserAddressesId",
                table: "TBL_Order",
                column: "UserAddressesId",
                principalTable: "TBL_UserAddresses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBL_Order_TBL_UserAddresses_UserAddressesId",
                table: "TBL_Order");

            migrationBuilder.DropIndex(
                name: "IX_TBL_Order_UserAddressesId",
                table: "TBL_Order");

            migrationBuilder.DropColumn(
                name: "UserAddressesId",
                table: "TBL_Order");
        }
    }
}
