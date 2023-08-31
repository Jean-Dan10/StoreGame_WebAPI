using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StoreGame_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class addDataClientEtCompte : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Client_Compte_CompteUser",
                table: "Client");

            migrationBuilder.RenameColumn(
                name: "CompteUser",
                table: "Client",
                newName: "User");

            migrationBuilder.RenameIndex(
                name: "IX_Client_CompteUser",
                table: "Client",
                newName: "IX_Client_User");

            migrationBuilder.InsertData(
                table: "Client",
                columns: new[] { "idClient", "AdresseCourriel", "AdressePhysique", "Nom", "Prenom", "User" },
                values: new object[,]
                {
                    { 1, "", "", "admin", "admin", "admin" },
                    { 2, "Tyzral@gmail.com", "5150 rues des ormes", "Beaudry", "Simon", "Tyzral" },
                    { 3, "Grimworld@gmail.com", "221B Baker Street", "Mercier", "Francis", "Grimworld" },
                    { 4, "ami@gmail.com", "50 rue l'Amitié", "Ami", "Ami", "THEFRIEND" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Client_Compte_User",
                table: "Client",
                column: "User",
                principalTable: "Compte",
                principalColumn: "User",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Client_Compte_User",
                table: "Client");

            migrationBuilder.DeleteData(
                table: "Client",
                keyColumn: "idClient",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Client",
                keyColumn: "idClient",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Client",
                keyColumn: "idClient",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Client",
                keyColumn: "idClient",
                keyValue: 4);

            migrationBuilder.RenameColumn(
                name: "User",
                table: "Client",
                newName: "CompteUser");

            migrationBuilder.RenameIndex(
                name: "IX_Client_User",
                table: "Client",
                newName: "IX_Client_CompteUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Client_Compte_CompteUser",
                table: "Client",
                column: "CompteUser",
                principalTable: "Compte",
                principalColumn: "User",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
