using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreGame_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddingGameReviewAndWishList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WishlistId",
                table: "Jeu",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GameReview",
                columns: table => new
                {
                    IdReview = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdJeu = table.Column<int>(type: "int", nullable: false),
                    Commentaire = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameReview", x => x.IdReview);
                    table.ForeignKey(
                        name: "FK_GameReview_Compte_User",
                        column: x => x.User,
                        principalTable: "Compte",
                        principalColumn: "User",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameReview_Jeu_IdJeu",
                        column: x => x.IdJeu,
                        principalTable: "Jeu",
                        principalColumn: "idJeu",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wishlist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wishlist", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wishlist_Compte_User",
                        column: x => x.User,
                        principalTable: "Compte",
                        principalColumn: "User",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jeu_WishlistId",
                table: "Jeu",
                column: "WishlistId");

            migrationBuilder.CreateIndex(
                name: "IX_GameReview_IdJeu",
                table: "GameReview",
                column: "IdJeu");

            migrationBuilder.CreateIndex(
                name: "IX_GameReview_User_IdJeu",
                table: "GameReview",
                columns: new[] { "User", "IdJeu" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wishlist_User",
                table: "Wishlist",
                column: "User",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Jeu_Wishlist_WishlistId",
                table: "Jeu",
                column: "WishlistId",
                principalTable: "Wishlist",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jeu_Wishlist_WishlistId",
                table: "Jeu");

            migrationBuilder.DropTable(
                name: "GameReview");

            migrationBuilder.DropTable(
                name: "Wishlist");

            migrationBuilder.DropIndex(
                name: "IX_Jeu_WishlistId",
                table: "Jeu");

            migrationBuilder.DropColumn(
                name: "WishlistId",
                table: "Jeu");
        }
    }
}
