using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreGame_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class initial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commande_Compte_User",
                table: "Commande");

            migrationBuilder.DropForeignKey(
                name: "FK_CommandeJeu_Commande_CommandesIdCommande",
                table: "CommandeJeu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Commande",
                table: "Commande");

            migrationBuilder.RenameTable(
                name: "Commande",
                newName: "Commande2");

            migrationBuilder.RenameIndex(
                name: "IX_Commande_User",
                table: "Commande2",
                newName: "IX_Commande2_User");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Commande2",
                table: "Commande2",
                column: "idCommande");

            migrationBuilder.AddForeignKey(
                name: "FK_Commande2_Compte_User",
                table: "Commande2",
                column: "User",
                principalTable: "Compte",
                principalColumn: "User",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommandeJeu_Commande2_CommandesIdCommande",
                table: "CommandeJeu",
                column: "CommandesIdCommande",
                principalTable: "Commande2",
                principalColumn: "idCommande",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commande2_Compte_User",
                table: "Commande2");

            migrationBuilder.DropForeignKey(
                name: "FK_CommandeJeu_Commande2_CommandesIdCommande",
                table: "CommandeJeu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Commande2",
                table: "Commande2");

            migrationBuilder.RenameTable(
                name: "Commande2",
                newName: "Commande");

            migrationBuilder.RenameIndex(
                name: "IX_Commande2_User",
                table: "Commande",
                newName: "IX_Commande_User");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Commande",
                table: "Commande",
                column: "idCommande");

            migrationBuilder.AddForeignKey(
                name: "FK_Commande_Compte_User",
                table: "Commande",
                column: "User",
                principalTable: "Compte",
                principalColumn: "User",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommandeJeu_Commande_CommandesIdCommande",
                table: "CommandeJeu",
                column: "CommandesIdCommande",
                principalTable: "Commande",
                principalColumn: "idCommande",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
