using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBController.Migrations
{
    /// <inheritdoc />
    public partial class AddedMoreTablesForUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Teams_User_TeamId",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "User_Email",
                table: "Users",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Team_Email",
                table: "Teams",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "TeamRoles",
                columns: table => new
                {
                    Role_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role_Level = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamRoles", x => x.Role_Id);
                });

            migrationBuilder.CreateTable(
                name: "UtilizRoles",
                columns: table => new
                {
                    Role_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role_Level = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UtilizRoles", x => x.Role_Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
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
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_TeamRoles_TeamRole_Id",
                        column: x => x.TeamRole_Id,
                        principalTable: "TeamRoles",
                        principalColumn: "Role_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Teams_Team_Id",
                        column: x => x.Team_Id,
                        principalTable: "Teams",
                        principalColumn: "Team_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_User_Id",
                        column: x => x.User_Id,
                        principalTable: "Users",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Utiliz_UtilizRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    UserRole_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utiliz_UtilizRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Utiliz_UtilizRoles_Users_User_Id",
                        column: x => x.User_Id,
                        principalTable: "Users",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Utiliz_UtilizRoles_UtilizRoles_UserRole_Id",
                        column: x => x.UserRole_Id,
                        principalTable: "UtilizRoles",
                        principalColumn: "Role_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_Team_Id",
                table: "UserRoles",
                column: "Team_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_TeamRole_Id",
                table: "UserRoles",
                column: "TeamRole_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_User_Id",
                table: "UserRoles",
                column: "User_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Utiliz_UtilizRoles_User_Id",
                table: "Utiliz_UtilizRoles",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Utiliz_UtilizRoles_UserRole_Id",
                table: "Utiliz_UtilizRoles",
                column: "UserRole_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Teams_User_TeamId",
                table: "Users",
                column: "User_TeamId",
                principalTable: "Teams",
                principalColumn: "Team_Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Teams_User_TeamId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Utiliz_UtilizRoles");

            migrationBuilder.DropTable(
                name: "TeamRoles");

            migrationBuilder.DropTable(
                name: "UtilizRoles");

            migrationBuilder.AlterColumn<string>(
                name: "User_Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Team_Email",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Teams_User_TeamId",
                table: "Users",
                column: "User_TeamId",
                principalTable: "Teams",
                principalColumn: "Team_Id");
        }
    }
}
