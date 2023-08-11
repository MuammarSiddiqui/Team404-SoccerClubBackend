using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Team404_SoccerClubBackend.Migrations
{
    /// <inheritdoc />
    public partial class cart2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBL_MatchStats_TBL_Product_ProductId",
                table: "TBL_MatchStats");

            migrationBuilder.DropIndex(
                name: "IX_TBL_MatchStats_ProductId",
                table: "TBL_MatchStats");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "TBL_MatchStats");

            migrationBuilder.CreateTable(
                name: "TBL_Cart",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_Cart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBL_Cart_TBL_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "TBL_Product",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TBL_Cart_TBL_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "TBL_Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBL_Cart_ProductId",
                table: "TBL_Cart",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_Cart_UsersId",
                table: "TBL_Cart",
                column: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_Cart");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "TBL_MatchStats",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TBL_MatchStats_ProductId",
                table: "TBL_MatchStats",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_TBL_MatchStats_TBL_Product_ProductId",
                table: "TBL_MatchStats",
                column: "ProductId",
                principalTable: "TBL_Product",
                principalColumn: "Id");
        }
    }
}
