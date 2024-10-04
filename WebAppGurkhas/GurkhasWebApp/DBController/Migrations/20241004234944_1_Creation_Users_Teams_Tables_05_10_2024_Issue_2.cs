using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBController.Migrations
{
    /// <inheritdoc />
    public partial class _1_Creation_Users_Teams_Tables_05_10_2024_Issue_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Team_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Team_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Team_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Team_Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Team_Logo = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Team_Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    User_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                        principalColumn: "Team_Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_User_TeamId",
                table: "Users",
                column: "User_TeamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
