using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StoreGame_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class nouvelleEntiterCompteEtClient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FavoriteGameStats",
                columns: table => new
                {
                    IdJeu = table.Column<int>(type: "int", nullable: false),
                    GameName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalWishlists = table.Column<int>(type: "int", nullable: false),
                    PercentInWishlists = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.InsertData(
                table: "Compte",
                columns: new[] { "User", "Password", "ProfileName" },
                values: new object[,]
                {
                    { "Test1", "123", "LeTest1" },
                    { "Test2", "123", "LeTest2" }
                });

            migrationBuilder.InsertData(
                table: "Client",
                columns: new[] { "idClient", "AdresseCourriel", "AdressePhysique", "Nom", "Prenom", "User" },
                values: new object[,]
                {
                    { 5, "ami2@gmail.com", "44 rue l'Amitié", "Le", "Test1", "Test1" },
                    { 6, "ami3@gmail.com", "45 rue l'Amitié", "Le", "Test2", "Test2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoriteGameStats");

            migrationBuilder.DeleteData(
                table: "Client",
                keyColumn: "idClient",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Client",
                keyColumn: "idClient",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Compte",
                keyColumn: "User",
                keyValue: "Test1");

            migrationBuilder.DeleteData(
                table: "Compte",
                keyColumn: "User",
                keyValue: "Test2");
        }
    }
}
