using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DBController.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedersAndRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TeamRoles",
                columns: new[] { "Role_Id", "Role_Level", "Role_Name" },
                values: new object[,]
                {
                    { 1, 1, "Leader" },
                    { 2, 2, "SubLeader" },
                    { 3, 3, "Member" }
                });

            migrationBuilder.InsertData(
                table: "UtilizRoles",
                columns: new[] { "Role_Id", "Role_Level", "Role_Name" },
                values: new object[,]
                {
                    { 1, 1, "Admin" },
                    { 2, 2, "Advanced User" },
                    { 3, 3, "User" },
                    { 4, 4, "Restricted Group" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TeamRoles",
                keyColumn: "Role_Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TeamRoles",
                keyColumn: "Role_Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TeamRoles",
                keyColumn: "Role_Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UtilizRoles",
                keyColumn: "Role_Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UtilizRoles",
                keyColumn: "Role_Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UtilizRoles",
                keyColumn: "Role_Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UtilizRoles",
                keyColumn: "Role_Id",
                keyValue: 4);
        }
    }
}
