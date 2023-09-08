using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreGame_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class nouvelleEntiterCompteEtClients : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Client",
                keyColumn: "idClient",
                keyValue: 5);

            migrationBuilder.InsertData(
                table: "Client",
                columns: new[] { "idClient", "AdresseCourriel", "AdressePhysique", "Nom", "Prenom", "User" },
                values: new object[] { 7, "ami2@gmail.com", "44 rue l'Amitié", "Le", "Test1", "Test1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Client",
                keyColumn: "idClient",
                keyValue: 7);

            migrationBuilder.InsertData(
                table: "Client",
                columns: new[] { "idClient", "AdresseCourriel", "AdressePhysique", "Nom", "Prenom", "User" },
                values: new object[] { 5, "ami2@gmail.com", "44 rue l'Amitié", "Le", "Test1", "Test1" });
        }
    }
}
