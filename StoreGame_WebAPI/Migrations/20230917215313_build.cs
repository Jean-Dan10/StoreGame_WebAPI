﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StoreGame_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class build : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AverageReviewForEachGame",
                columns: table => new
                {
                    IdJeu = table.Column<int>(type: "int", nullable: false),
                    MoyenneNote = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "AverageScoreResult",
                columns: table => new
                {
                    MoyenneNote = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Compte",
                columns: table => new
                {
                    User = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfileName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compte", x => x.User);
                });

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
                    User = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.idClient);
                    table.ForeignKey(
                        name: "FK_Client_Compte_User",
                        column: x => x.User,
                        principalTable: "Compte",
                        principalColumn: "User",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Commande",
                columns: table => new
                {
                    idCommande = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Panier = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commande", x => x.idCommande);
                    table.ForeignKey(
                        name: "FK_Commande_Compte_User",
                        column: x => x.User,
                        principalTable: "Compte",
                        principalColumn: "User",
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
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    User = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    JeuIdJeu = table.Column<int>(type: "int", nullable: true)
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
                    table.ForeignKey(
                        name: "FK_Wishlist_Jeu_JeuIdJeu",
                        column: x => x.JeuIdJeu,
                        principalTable: "Jeu",
                        principalColumn: "idJeu");
                });

            migrationBuilder.CreateTable(
                name: "jeuWishlists",
                columns: table => new
                {
                    JeuxIdJeu = table.Column<int>(type: "int", nullable: false),
                    WishlistsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jeuWishlists", x => new { x.JeuxIdJeu, x.WishlistsId });
                    table.ForeignKey(
                        name: "FK_jeuWishlists_Jeu_JeuxIdJeu",
                        column: x => x.JeuxIdJeu,
                        principalTable: "Jeu",
                        principalColumn: "idJeu",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_jeuWishlists_Wishlist_WishlistsId",
                        column: x => x.WishlistsId,
                        principalTable: "Wishlist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Compte",
                columns: new[] { "User", "Password", "ProfileName" },
                values: new object[,]
                {
                    { "admin", "123", "Orignal" },
                    { "Grimworld", "123", "Grimworld" },
                    { "Test1", "123", "LeTest1" },
                    { "Test2", "123", "LeTest2" },
                    { "THEFRIEND", "123", "ami" },
                    { "Tyzral", "123", "Tyzral" }
                });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "idGenre", "Name" },
                values: new object[,]
                {
                    { 1, "Action-aventure" },
                    { 2, "Plateforme" },
                    { 3, "RPG" },
                    { 4, "Sandbox" },
                    { 5, "FPS" },
                    { 6, "Strategy" },
                    { 7, "Sports" },
                    { 8, "Simulation" },
                    { 9, "Puzzle" },
                    { 10, "Horror" }
                });

            migrationBuilder.InsertData(
                table: "Wishlist",
                columns: new[] { "Id", "JeuIdJeu", "User" },
                values: new object[,]
                {
                    { 2, null, "test1" },
                    { 3, null, "test2" }
                });

            migrationBuilder.InsertData(
                table: "Client",
                columns: new[] { "idClient", "AdresseCourriel", "AdressePhysique", "Nom", "Prenom", "User" },
                values: new object[,]
                {
                    { 1, "", "", "admin", "admin", "admin" },
                    { 2, "Tyzral@gmail.com", "5150 rues des ormes", "Beaudry", "Simon", "Tyzral" },
                    { 3, "Grimworld@gmail.com", "221B Baker Street", "Mercier", "Francis", "Grimworld" },
                    { 4, "ami@gmail.com", "50 rue l'Amitié", "Ami", "Ami", "THEFRIEND" },
                    { 6, "ami3@gmail.com", "45 rue l'Amitié", "Le", "Test2", "Test2" },
                    { 7, "ami2@gmail.com", "44 rue l'Amitié", "Le", "Test1", "Test1" }
                });

            migrationBuilder.InsertData(
                table: "Jeu",
                columns: new[] { "idJeu", "Description", "IdGenre", "ImagePath", "NomJeu", "Prix" },
                values: new object[,]
                {
                    { 1, "Aidez Mario à sauver la princesse Peach dans une aventure trépidante à travers de nombreux royaumes.", 2, "/image/SMOdyssey.png", "Super Mario Odyssey", 59.990000000000002 },
                    { 2, "Explorez le vaste monde d'Hyrule en incarnant le héros Link et affrontez de redoutables ennemis.", 1, "/image/LoZeldaBoTW.png", "The Legend of Zelda: Breath of the Wild", 79.989999999999995 },
                    { 3, "Construisez et explorez un monde infini rempli de blocs, où seules vos limites sont votre créativité et votre imagination.", 4, "/image/Minecraft.png", "Minecraft", 29.989999999999998 },
                    { 4, "Incarnez Geralt de Riv, un puissant chasseur de monstres, et embarquez dans une quête épique à travers un monde fantastique rempli de dangers et de choix moraux.", 3, "/image/TheWitcher3WildHunt.png", "The Witcher 3: Wild Hunt", 49.990000000000002 },
                    { 5, "Rejoignez Rayman and ses amis dans des niveaux colorés et remplis de défis pour sauver le monde des créatures maléfiques.", 2, "/image/RaymanLegends.png", "Rayman Legends", 39.990000000000002 },
                    { 6, "Découvrez l'histoire des origines de la confrérie des Assassins dans l'Égypte antique, et frayez-vous un chemin à travers des batailles épiques et des conspirations.", 1, "/image/ACOrigine.png", "Assassin's Creed Origins", 59.990000000000002 },
                    { 7, "Explorez, construisez et combattez dans un monde rempli de créatures mystérieuses et de trésors cachés.", 4, "/image/Terraria.png", "Terraria", 19.989999999999998 },
                    { 8, "Plongez dans le monde de la saga légendaire Final Fantasy avec des milliers d'autres joueurs dans ce MMORPG riche en histoires et en combats épiques.", 3, "/image/FF14.png", "Final Fantasy XIV", 29.989999999999998 },
                    { 9, "Aidez Madeline à surmonter ses peurs intérieures et à escalader la montagne de Celeste dans ce jeu de plateforme acclamé.", 2, "/image/Celeste.png", "Celeste", 19.989999999999998 },
                    { 10, "Explorez le Far West américain à l'époque des hors-la-loi et participez à des braquages, des duels et des aventures épiques.", 1, "/image/RDR2.png", "Red Dead Redemption 2", 59.990000000000002 },
                    { 11, "Quittez la ville pour hériter de la vieille ferme de votre grand-père et transformez-la en un lieu prospère en cultivant des cultures, en élevant du bétail et en tissant des liens avec les habitants de la ville.", 4, "/image/stardewVal.png", "Stardew Valley", 14.99 },
                    { 12, "Un vaste monde ouvert avec des quêtes épiques, des dragons redoutables et des mystères à découvrir.", 3, "/image/skyrim.png", "The Elder Scrolls V: Skyrim", 39.990000000000002 },
                    { 13, "Incarnez Batman et combattez les super-vilains dans les rues sombres et corrompues d'Arkham City.", 1, "/image/batman.png", "Batman: Arkham City", 39.990000000000002 },
                    { 14, "Plongez dans des donjons générés de manière procédurale, affrontez des monstres redoutables et obtenez des trésors légendaires dans ce jeu d'action-aventure inspiré de l'univers de Minecraft.", 1, "/image/minecraftDungeon.png", "Minecraft: Dungeons", 29.989999999999998 },
                    { 15, "Gérez une colonie de survivants échoués sur une planète extraterrestre dans ce jeu de gestion de colonie complexe et captivant.", 4, "/image/rimworld.png", "RimWorld", 34.990000000000002 },
                    { 16, "Revivez l'histoire épique de Cloud Strife et du groupe de résistants Avalanche dans ce remake du célèbre jeu de rôle japonais.", 3, "/image/ff7remake.png", "Final Fantasy VII Remake", 59.990000000000002 },
                    { 17, "Redécouvrez les aventures classiques de Crash Bandicoot dans une collection remasterisée comprenant les trois premiers jeux de la série.", 2, "/image/trilogy Crash.png", "Crash Bandicoot N. Sane Trilogy", 39.990000000000002 },
                    { 18, "Explorez un univers de science-fiction dystopique, prenez des décisions morales difficiles et façonnez votre propre destinée dans ce RPG captivant.", 3, "/image/TOW.png", "The Outer Worlds", 49.990000000000002 },
                    { 19, "Affrontez vos personnages préférés de Nintendo et d'autres franchises dans des combats épiques mettant en scène des crossovers incroyables.", 1, "/image/SSBrosUlti.png", "Super Smash Bros. Ultimate", 59.990000000000002 },
                    { 20, "Affrontez des ennemis redoutables en tant que 'Loup à un bras' dans ce jeu d'action-aventure intense et exigeant développé par FromSoftware.", 1, "/image/seikiro.png", "Sekiro: Shadows Die Twice", 59.990000000000002 },
                    { 21, "Plongez dans les profondeurs mystérieuses d'une planète océanique extraterrestre et survivez en explorant, en construisant et en découvrant les secrets de ce monde aquatique hostile.", 4, "/image/subnautica.png", "Subnautica", 29.989999999999998 },
                    { 22, "Plongez dans un vaste monde de fantasy et menez une équipe de héros dans une quête pour sauver le monde de la destruction dans ce RPG isométrique riche en choix et en conséquences.", 3, "/image/DOS2.png", "Divinity: Original Sin 2", 44.990000000000002 },
                    { 23, "Affrontez des hordes de démons infernaux dans ce jeu de tir frénétique et sanglant.", 5, "/image/DoomE.png", "Doom Eternal", 39.990000000000002 },
                    { 24, "Revivez les batailles emblématiques de la Seconde Guerre mondiale dans ce jeu de tir à la première personne.", 5, "/image/BF5.png", "Battlefield V", 49.990000000000002 },
                    { 25, "Prenez les commandes d'une équipe de football américain et menez-la vers la victoire ultime.", 7, "/image/Madden23.png", "Madden NFL 23", 59.990000000000002 },
                    { 26, "Plongez dans une histoire terrifiante et découvrez les sombres secrets qui vous entourent.", 10, "/image/Amnesia.png", "Amnesia: Rebirth", 29.989999999999998 },
                    { 27, "Dominez le terrain de basket et vivez l'expérience de la NBA avec des joueurs célèbres.", 7, "/image/NBA2K23.png", "NBA 2K23", 59.990000000000002 },
                    { 28, "Prenez le contrôle d'une des factions fantastiques de l'univers de Warhammer et dominez le monde.", 6, "/image/TWW2.png", "Total War: Warhammer II", 49.990000000000002 },
                    { 29, "Envolez-vous dans les cieux et explorez le monde entier avec des détails incroyablement réalistes.", 8, "/image/MFS.png", "Microsoft Flight Simulator", 59.990000000000002 },
                    { 30, "Vivez l'excitation du football avec des graphismes réalistes et une jouabilité améliorée.", 7, "/image/fifa23.png", "FIFA 23", 59.990000000000002 },
                    { 31, "Créez et contrôlez des vies virtuelles dans ce jeu de simulation de vie réaliste.", 8, "/image/sims4.png", "The Sims 4", 39.990000000000002 },
                    { 32, "Résolvez des énigmes et manipulez l'espace avec votre pistolet de portail dans ce jeu de puzzle captivant.", 9, "/image/P2.png", "Portal 2", 19.989999999999998 },
                    { 33, "Plongez dans une guerre moderne avec des graphismes époustouflants et une expérience multijoueur intense.", 5, "/image/CODMW.png", "Call of Duty: Modern Warfare", 59.990000000000002 }
                });

            migrationBuilder.InsertData(
                table: "Wishlist",
                columns: new[] { "Id", "JeuIdJeu", "User" },
                values: new object[] { 1, null, "admin" });

            migrationBuilder.InsertData(
                table: "GameReview",
                columns: new[] { "IdReview", "Commentaire", "IdJeu", "Note", "User" },
                values: new object[,]
                {
                    { 1, "Ce jeu est incroyable! Les graphismes sont à couper le souffle, et l'histoire est passionnante. J'adore!", 1, 4, "admin" },
                    { 2, "J'ai passé des heures à jouer à ce jeu. C'est vraiment addictif, et les personnages sont attachants.", 2, 3, "admin" },
                    { 3, "Ce jeu mérite 5 étoiles. La jouabilité est fluide, et les niveaux sont bien conçus.", 3, 5, "admin" },
                    { 4, "The Witcher 3 est un chef-d'œuvre absolu! L'univers est riche, les quêtes sont captivantes. Ma note : 5/5.", 4, 5, "admin" },
                    { 5, "Rayman Legends est un jeu de plateforme incroyablement amusant. Les niveaux musicaux sont géniaux! Note : 4/5.", 5, 4, "admin" },
                    { 6, "Assassin's Creed Origins est un voyage passionnant dans l'Égypte antique. Les combats sont géniaux. Note : 4/5.", 6, 4, "admin" },
                    { 7, "Terraria est un jeu de construction addictif. L'exploration est infinie! Ma note : 4/5.", 7, 4, "admin" },
                    { 8, "Final Fantasy XIV est un MMORPG de qualité avec une histoire épique. Je recommande! Note : 5/5.", 8, 5, "admin" },
                    { 9, "Celeste est un jeu de plateforme exigeant mais gratifiant. Les défis sont stimulants. Note : 4/5.", 9, 4, "admin" },
                    { 10, "Red Dead Redemption 2 est une expérience immersive dans le Far West. Les détails sont incroyables. Note : 5/5.", 10, 5, "admin" },
                    { 11, "Les graphismes de ce jeu sont correct, et l'intrigue est palpitante. Je lui donne 3 étoiles!", 1, 3, "Grimworld" },
                    { 12, "J'ai été accro à ce jeu pendant des semaines. Les personnages sont super attachants, et l'aventure est passionnante. Ma note : 4/5.", 2, 4, "Grimworld" },
                    { 13, "Ce jeu mérite toutes les éloges. La jouabilité est fluide, et chaque niveau est un plaisir à parcourir. Ma note : 5/5.", 3, 5, "Grimworld" },
                    { 14, "Super Mario Odyssey est un jeu incroyable! Les graphismes sont époustouflants, et le gameplay est une pure joie. Ma note : 5/5.", 1, 5, "Tyzral" },
                    { 15, "J'ai passé d'innombrables heures à explorer chaque royaume de ce jeu. C'est un chef-d'œuvre du genre. Note : 5/5.", 2, 5, "Tyzral" },
                    { 16, "Ce jeu est tellement amusant! Les niveaux sont bien conçus, et les défis sont stimulants. Ma note : 3/5.", 3, 3, "Tyzral" },
                    { 17, "Ce jeu est décevant. Les graphismes sont médiocres, et l'histoire est ennuyeuse. Ma note : 2/5.", 1, 2, "THEFRIEND" },
                    { 18, "The Legend of Zelda: Breath of the Wild est un jeu surévalué. Je ne vois pas ce que les gens lui trouvent. Note : 2/5.", 2, 2, "THEFRIEND" },
                    { 19, "Minecraft est un jeu sans intérêt. Construire des choses n'a rien d'amusant. Ma note : 2/5.", 3, 2, "THEFRIEND" }
                });

            migrationBuilder.InsertData(
                table: "jeuWishlists",
                columns: new[] { "JeuxIdJeu", "WishlistsId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 3, 3 },
                    { 4, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Client_User",
                table: "Client",
                column: "User");

            migrationBuilder.CreateIndex(
                name: "IX_Commande_User",
                table: "Commande",
                column: "User");

            migrationBuilder.CreateIndex(
                name: "IX_CommandeJeu_JeuxIdJeu",
                table: "CommandeJeu",
                column: "JeuxIdJeu");

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
                name: "IX_Jeu_IdGenre",
                table: "Jeu",
                column: "IdGenre");

            migrationBuilder.CreateIndex(
                name: "IX_jeuWishlists_WishlistsId",
                table: "jeuWishlists",
                column: "WishlistsId");

            migrationBuilder.CreateIndex(
                name: "IX_Wishlist_JeuIdJeu",
                table: "Wishlist",
                column: "JeuIdJeu");

            migrationBuilder.CreateIndex(
                name: "IX_Wishlist_User",
                table: "Wishlist",
                column: "User",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AverageReviewForEachGame");

            migrationBuilder.DropTable(
                name: "AverageScoreResult");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "CommandeJeu");

            migrationBuilder.DropTable(
                name: "FavoriteGameStats");

            migrationBuilder.DropTable(
                name: "GameReview");

            migrationBuilder.DropTable(
                name: "jeuWishlists");

            migrationBuilder.DropTable(
                name: "Commande");

            migrationBuilder.DropTable(
                name: "Wishlist");

            migrationBuilder.DropTable(
                name: "Compte");

            migrationBuilder.DropTable(
                name: "Jeu");

            migrationBuilder.DropTable(
                name: "Genre");
        }
    }
}
