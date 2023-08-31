using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreGame_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Client_Compte_CompteIdCompte",
                table: "Client");

            migrationBuilder.DropForeignKey(
                name: "FK_Commande_Compte_IdCompte",
                table: "Commande");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Compte",
                table: "Compte");

            migrationBuilder.DropIndex(
                name: "IX_Commande_IdCompte",
                table: "Commande");

            migrationBuilder.DropIndex(
                name: "IX_Client_CompteIdCompte",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "IdCompte",
                table: "Compte");

            migrationBuilder.DropColumn(
                name: "IdCompte",
                table: "Commande");

            migrationBuilder.DropColumn(
                name: "CompteIdCompte",
                table: "Client");

            migrationBuilder.AlterColumn<string>(
                name: "User",
                table: "Compte",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "Commande",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CompteUser",
                table: "Client",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Compte",
                table: "Compte",
                column: "User");

            migrationBuilder.CreateIndex(
                name: "IX_Commande_User",
                table: "Commande",
                column: "User");

            migrationBuilder.CreateIndex(
                name: "IX_Client_CompteUser",
                table: "Client",
                column: "CompteUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Client_Compte_CompteUser",
                table: "Client",
                column: "CompteUser",
                principalTable: "Compte",
                principalColumn: "User",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Commande_Compte_User",
                table: "Commande",
                column: "User",
                principalTable: "Compte",
                principalColumn: "User",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Client_Compte_CompteUser",
                table: "Client");

            migrationBuilder.DropForeignKey(
                name: "FK_Commande_Compte_User",
                table: "Commande");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Compte",
                table: "Compte");

            migrationBuilder.DropIndex(
                name: "IX_Commande_User",
                table: "Commande");

            migrationBuilder.DropIndex(
                name: "IX_Client_CompteUser",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "User",
                table: "Commande");

            migrationBuilder.DropColumn(
                name: "CompteUser",
                table: "Client");

            migrationBuilder.AlterColumn<string>(
                name: "User",
                table: "Compte",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "IdCompte",
                table: "Compte",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "IdCompte",
                table: "Commande",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompteIdCompte",
                table: "Client",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Compte",
                table: "Compte",
                column: "IdCompte");

            migrationBuilder.CreateIndex(
                name: "IX_Commande_IdCompte",
                table: "Commande",
                column: "IdCompte");

            migrationBuilder.CreateIndex(
                name: "IX_Client_CompteIdCompte",
                table: "Client",
                column: "CompteIdCompte");

            migrationBuilder.AddForeignKey(
                name: "FK_Client_Compte_CompteIdCompte",
                table: "Client",
                column: "CompteIdCompte",
                principalTable: "Compte",
                principalColumn: "IdCompte",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Commande_Compte_IdCompte",
                table: "Commande",
                column: "IdCompte",
                principalTable: "Compte",
                principalColumn: "IdCompte",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
