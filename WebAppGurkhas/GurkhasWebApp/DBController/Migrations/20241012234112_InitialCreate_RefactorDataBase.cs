using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DBController.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate_RefactorDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TeamRoles",
                columns: table => new
                {
                    TeamRole_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamRole_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeamRole_Level = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamRoles", x => x.TeamRole_Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Team_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Team_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Team_Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Team_Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Team_Logo = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Team_Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserRole_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserRole_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserRole_Level = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.UserRole_Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    User_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    User_PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User_TeamId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.User_Id);
                    table.ForeignKey(
                        name: "FK_Users_Teams_User_TeamId",
                        column: x => x.User_TeamId,
                        principalTable: "Teams",
                        principalColumn: "Team_Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "User_UserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    UserRole_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_UserRoles_UserRoles_UserRole_Id",
                        column: x => x.UserRole_Id,
                        principalTable: "UserRoles",
                        principalColumn: "UserRole_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_UserRoles_Users_User_Id",
                        column: x => x.User_Id,
                        principalTable: "Users",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTeamRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    Team_Id = table.Column<int>(type: "int", nullable: false),
                    TeamRole_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTeamRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTeamRole_TeamRoles_TeamRole_Id",
                        column: x => x.TeamRole_Id,
                        principalTable: "TeamRoles",
                        principalColumn: "TeamRole_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTeamRole_Teams_Team_Id",
                        column: x => x.Team_Id,
                        principalTable: "Teams",
                        principalColumn: "Team_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTeamRole_Users_User_Id",
                        column: x => x.User_Id,
                        principalTable: "Users",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TeamRoles",
                columns: new[] { "TeamRole_Id", "TeamRole_Level", "TeamRole_Name" },
                values: new object[,]
                {
                    { 1, 1, "Leader" },
                    { 2, 2, "SubLeader" },
                    { 3, 3, "Member" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "UserRole_Id", "UserRole_Level", "UserRole_Name" },
                values: new object[,]
                {
                    { 1, 1, "Admin" },
                    { 2, 2, "Advanced User" },
                    { 3, 3, "User" },
                    { 4, 4, "Restricted Group" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_UserRoles_User_Id",
                table: "User_UserRoles",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserRoles_UserRole_Id",
                table: "User_UserRoles",
                column: "UserRole_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_User_TeamId",
                table: "Users",
                column: "User_TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTeamRole_Team_Id",
                table: "UserTeamRole",
                column: "Team_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserTeamRole_TeamRole_Id",
                table: "UserTeamRole",
                column: "TeamRole_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserTeamRole_User_Id",
                table: "UserTeamRole",
                column: "User_Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User_UserRoles");

            migrationBuilder.DropTable(
                name: "UserTeamRole");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "TeamRoles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
