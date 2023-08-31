using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StoreGame_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class CompteData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Compte",
                columns: new[] { "User", "Password", "ProfileName" },
                values: new object[,]
                {
                    { "admin", "123", "Orignal" },
                    { "Grimworld", "123", "Grimworld" },
                    { "THEFRIEND", "123", "ami" },
                    { "Tyzral", "123", "Tyzral" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Compte",
                keyColumn: "User",
                keyValue: "admin");

            migrationBuilder.DeleteData(
                table: "Compte",
                keyColumn: "User",
                keyValue: "Grimworld");

            migrationBuilder.DeleteData(
                table: "Compte",
                keyColumn: "User",
                keyValue: "THEFRIEND");

            migrationBuilder.DeleteData(
                table: "Compte",
                keyColumn: "User",
                keyValue: "Tyzral");
        }
    }
}
