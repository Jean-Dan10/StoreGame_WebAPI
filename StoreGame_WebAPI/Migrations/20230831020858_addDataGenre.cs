using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StoreGame_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class addDataGenre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "idGenre", "Name" },
                values: new object[,]
                {
                    { 1, "Action-aventure" },
                    { 2, "Plateforme" },
                    { 3, "RPG" },
                    { 4, "Sandbox" },
                    { 5, "FPS" },
                    { 6, "Strategy" },
                    { 7, "Sports" },
                    { 8, "Simulation" },
                    { 9, "Puzzle" },
                    { 10, "Horror" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "idGenre",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "idGenre",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "idGenre",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "idGenre",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "idGenre",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "idGenre",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "idGenre",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "idGenre",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "idGenre",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "idGenre",
                keyValue: 10);
        }
    }
}
