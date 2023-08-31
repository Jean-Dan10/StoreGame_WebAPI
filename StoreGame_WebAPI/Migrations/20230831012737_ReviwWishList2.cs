using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreGame_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class ReviwWishList2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jeu_Wishlist_WishlistId",
                table: "Jeu");

            migrationBuilder.DropIndex(
                name: "IX_Jeu_WishlistId",
                table: "Jeu");

            migrationBuilder.DropColumn(
                name: "WishlistId",
                table: "Jeu");

            migrationBuilder.CreateTable(
                name: "JeuWishlist",
                columns: table => new
                {
                    JeuxIdJeu = table.Column<int>(type: "int", nullable: false),
                    WhislistsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JeuWishlist", x => new { x.JeuxIdJeu, x.WhislistsId });
                    table.ForeignKey(
                        name: "FK_JeuWishlist_Jeu_JeuxIdJeu",
                        column: x => x.JeuxIdJeu,
                        principalTable: "Jeu",
                        principalColumn: "idJeu",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JeuWishlist_Wishlist_WhislistsId",
                        column: x => x.WhislistsId,
                        principalTable: "Wishlist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JeuWishlist_WhislistsId",
                table: "JeuWishlist",
                column: "WhislistsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JeuWishlist");

            migrationBuilder.AddColumn<int>(
                name: "WishlistId",
                table: "Jeu",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Jeu_WishlistId",
                table: "Jeu",
                column: "WishlistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jeu_Wishlist_WishlistId",
                table: "Jeu",
                column: "WishlistId",
                principalTable: "Wishlist",
                principalColumn: "Id");
        }
    }
}
