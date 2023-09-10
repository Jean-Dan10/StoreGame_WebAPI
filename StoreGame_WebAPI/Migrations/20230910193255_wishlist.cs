using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreGame_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class wishlist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JeuWishlist");

            migrationBuilder.AddColumn<int>(
                name: "JeuIdJeu",
                table: "Wishlist",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wishlist_JeuIdJeu",
                table: "Wishlist",
                column: "JeuIdJeu");

            migrationBuilder.AddForeignKey(
                name: "FK_Wishlist_Jeu_JeuIdJeu",
                table: "Wishlist",
                column: "JeuIdJeu",
                principalTable: "Jeu",
                principalColumn: "idJeu");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wishlist_Jeu_JeuIdJeu",
                table: "Wishlist");

            migrationBuilder.DropIndex(
                name: "IX_Wishlist_JeuIdJeu",
                table: "Wishlist");

            migrationBuilder.DropColumn(
                name: "JeuIdJeu",
                table: "Wishlist");

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
    }
}
