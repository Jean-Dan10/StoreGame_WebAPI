using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StoreGame_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class addData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Wishlist",
                columns: new[] { "Id", "JeuIdJeu", "User" },
                values: new object[,]
                {
                    { 2, null, "test1" },
                    { 3, null, "test2" }
                });

            migrationBuilder.InsertData(
                table: "jeuWishlists",
                columns: new[] { "JeuxIdJeu", "WishlistsId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 2 },
                    { 2, 3 },
                    { 3, 3 },
                    { 4, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "jeuWishlists",
                keyColumns: new[] { "JeuxIdJeu", "WishlistsId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "jeuWishlists",
                keyColumns: new[] { "JeuxIdJeu", "WishlistsId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "jeuWishlists",
                keyColumns: new[] { "JeuxIdJeu", "WishlistsId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "jeuWishlists",
                keyColumns: new[] { "JeuxIdJeu", "WishlistsId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "jeuWishlists",
                keyColumns: new[] { "JeuxIdJeu", "WishlistsId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "jeuWishlists",
                keyColumns: new[] { "JeuxIdJeu", "WishlistsId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "Wishlist",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Wishlist",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
