using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreGame_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Compte",
                columns: table => new
                {
                    IdCompte = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfileName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compte", x => x.IdCompte);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    idGenre = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.idGenre);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    idClient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdressePhysique = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdresseCourriel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompteIdCompte = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.idClient);
                    table.ForeignKey(
                        name: "FK_Client_Compte_CompteIdCompte",
                        column: x => x.CompteIdCompte,
                        principalTable: "Compte",
                        principalColumn: "IdCompte",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Commande",
                columns: table => new
                {
                    idCommande = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCompte = table.Column<int>(type: "int", nullable: false),
                    Panier = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commande", x => x.idCommande);
                    table.ForeignKey(
                        name: "FK_Commande_Compte_IdCompte",
                        column: x => x.IdCompte,
                        principalTable: "Compte",
                        principalColumn: "IdCompte",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Jeu",
                columns: table => new
                {
                    idJeu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomJeu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prix = table.Column<double>(type: "float", nullable: false),
                    IdGenre = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jeu", x => x.idJeu);
                    table.ForeignKey(
                        name: "FK_Jeu_Genre_IdGenre",
                        column: x => x.IdGenre,
                        principalTable: "Genre",
                        principalColumn: "idGenre",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommandeJeu",
                columns: table => new
                {
                    CommandesIdCommande = table.Column<int>(type: "int", nullable: false),
                    JeuxIdJeu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommandeJeu", x => new { x.CommandesIdCommande, x.JeuxIdJeu });
                    table.ForeignKey(
                        name: "FK_CommandeJeu_Commande_CommandesIdCommande",
                        column: x => x.CommandesIdCommande,
                        principalTable: "Commande",
                        principalColumn: "idCommande",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommandeJeu_Jeu_JeuxIdJeu",
                        column: x => x.JeuxIdJeu,
                        principalTable: "Jeu",
                        principalColumn: "idJeu",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Client_CompteIdCompte",
                table: "Client",
                column: "CompteIdCompte");

            migrationBuilder.CreateIndex(
                name: "IX_Commande_IdCompte",
                table: "Commande",
                column: "IdCompte");

            migrationBuilder.CreateIndex(
                name: "IX_CommandeJeu_JeuxIdJeu",
                table: "CommandeJeu",
                column: "JeuxIdJeu");

            migrationBuilder.CreateIndex(
                name: "IX_Jeu_IdGenre",
                table: "Jeu",
                column: "IdGenre");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "CommandeJeu");

            migrationBuilder.DropTable(
                name: "Commande");

            migrationBuilder.DropTable(
                name: "Jeu");

            migrationBuilder.DropTable(
                name: "Compte");

            migrationBuilder.DropTable(
                name: "Genre");
        }
    }
}
