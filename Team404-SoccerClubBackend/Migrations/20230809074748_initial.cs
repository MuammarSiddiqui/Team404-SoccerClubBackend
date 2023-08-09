using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Team404_SoccerClubBackend.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBL_Competition",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_Competition", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBL_ProductCategory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_ProductCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBL_Role",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBL_SoccerInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_SoccerInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBL_Team",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_Team", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBL_Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBL_Product_TBL_ProductCategory_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "TBL_ProductCategory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TBL_Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfilePic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBL_Users_TBL_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "TBL_Role",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CompetitionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matches_TBL_Competition_CompetitionId",
                        column: x => x.CompetitionId,
                        principalTable: "TBL_Competition",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Matches_TBL_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "TBL_Team",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TBL_Player",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nationatilty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_Player", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBL_Player_TBL_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "TBL_Team",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TBL_Order",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBL_Order_TBL_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "TBL_Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TBL_MatchStats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Stadium = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Attendance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MatchesId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_MatchStats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBL_MatchStats_Matches_MatchesId",
                        column: x => x.MatchesId,
                        principalTable: "Matches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TBL_MatchStats_TBL_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "TBL_Product",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TBL_TeamStats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GoalsScored = table.Column<int>(type: "int", nullable: false),
                    GoalsConceded = table.Column<int>(type: "int", nullable: false),
                    Shots = table.Column<int>(type: "int", nullable: false),
                    Fouls = table.Column<int>(type: "int", nullable: false),
                    Possession = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MatchesId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_TeamStats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBL_TeamStats_Matches_MatchesId",
                        column: x => x.MatchesId,
                        principalTable: "Matches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TBL_TeamStats_TBL_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "TBL_Team",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TBL_PlayerAchievement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateRecieved = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MatchesId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_PlayerAchievement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBL_PlayerAchievement_Matches_MatchesId",
                        column: x => x.MatchesId,
                        principalTable: "Matches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TBL_PlayerAchievement_TBL_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "TBL_Player",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TBL_PlayerImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Caption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_PlayerImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBL_PlayerImages_TBL_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "TBL_Player",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TBL_PlayerStats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Goals = table.Column<int>(type: "int", nullable: true),
                    Assists = table.Column<int>(type: "int", nullable: true),
                    YellowCards = table.Column<int>(type: "int", nullable: true),
                    RedCards = table.Column<int>(type: "int", nullable: true),
                    MinutesPlayed = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MatchesId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_PlayerStats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBL_PlayerStats_Matches_MatchesId",
                        column: x => x.MatchesId,
                        principalTable: "Matches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TBL_PlayerStats_TBL_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "TBL_Player",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TBL_OrderItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_OrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBL_OrderItem_TBL_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "TBL_Order",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TBL_OrderItem_TBL_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "TBL_Product",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matches_CompetitionId",
                table: "Matches",
                column: "CompetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_TeamId",
                table: "Matches",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_MatchStats_MatchesId",
                table: "TBL_MatchStats",
                column: "MatchesId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_MatchStats_ProductId",
                table: "TBL_MatchStats",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_Order_UsersId",
                table: "TBL_Order",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_OrderItem_OrderId",
                table: "TBL_OrderItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_OrderItem_ProductId",
                table: "TBL_OrderItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_Player_TeamId",
                table: "TBL_Player",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_PlayerAchievement_MatchesId",
                table: "TBL_PlayerAchievement",
                column: "MatchesId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_PlayerAchievement_PlayerId",
                table: "TBL_PlayerAchievement",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_PlayerImages_PlayerId",
                table: "TBL_PlayerImages",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_PlayerStats_MatchesId",
                table: "TBL_PlayerStats",
                column: "MatchesId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_PlayerStats_PlayerId",
                table: "TBL_PlayerStats",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_Product_ProductCategoryId",
                table: "TBL_Product",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_TeamStats_MatchesId",
                table: "TBL_TeamStats",
                column: "MatchesId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_TeamStats_TeamId",
                table: "TBL_TeamStats",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_Users_RoleId",
                table: "TBL_Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_MatchStats");

            migrationBuilder.DropTable(
                name: "TBL_OrderItem");

            migrationBuilder.DropTable(
                name: "TBL_PlayerAchievement");

            migrationBuilder.DropTable(
                name: "TBL_PlayerImages");

            migrationBuilder.DropTable(
                name: "TBL_PlayerStats");

            migrationBuilder.DropTable(
                name: "TBL_SoccerInfo");

            migrationBuilder.DropTable(
                name: "TBL_TeamStats");

            migrationBuilder.DropTable(
                name: "TBL_Order");

            migrationBuilder.DropTable(
                name: "TBL_Product");

            migrationBuilder.DropTable(
                name: "TBL_Player");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "TBL_Users");

            migrationBuilder.DropTable(
                name: "TBL_ProductCategory");

            migrationBuilder.DropTable(
                name: "TBL_Competition");

            migrationBuilder.DropTable(
                name: "TBL_Team");

            migrationBuilder.DropTable(
                name: "TBL_Role");
        }
    }
}
