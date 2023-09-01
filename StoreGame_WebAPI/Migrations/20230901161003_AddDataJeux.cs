using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StoreGame_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddDataJeux : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Jeu",
                keyColumn: "idJeu",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Jeu",
                keyColumn: "idJeu",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Jeu",
                keyColumn: "idJeu",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Jeu",
                keyColumn: "idJeu",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Jeu",
                keyColumn: "idJeu",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Jeu",
                keyColumn: "idJeu",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Jeu",
                keyColumn: "idJeu",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Jeu",
                keyColumn: "idJeu",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Jeu",
                keyColumn: "idJeu",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Jeu",
                keyColumn: "idJeu",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Jeu",
                keyColumn: "idJeu",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Jeu",
                keyColumn: "idJeu",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Jeu",
                keyColumn: "idJeu",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Jeu",
                keyColumn: "idJeu",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Jeu",
                keyColumn: "idJeu",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Jeu",
                keyColumn: "idJeu",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Jeu",
                keyColumn: "idJeu",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Jeu",
                keyColumn: "idJeu",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Jeu",
                keyColumn: "idJeu",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Jeu",
                keyColumn: "idJeu",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Jeu",
                keyColumn: "idJeu",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Jeu",
                keyColumn: "idJeu",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Jeu",
                keyColumn: "idJeu",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Jeu",
                keyColumn: "idJeu",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Jeu",
                keyColumn: "idJeu",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Jeu",
                keyColumn: "idJeu",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Jeu",
                keyColumn: "idJeu",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Jeu",
                keyColumn: "idJeu",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Jeu",
                keyColumn: "idJeu",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Jeu",
                keyColumn: "idJeu",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Jeu",
                keyColumn: "idJeu",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Jeu",
                keyColumn: "idJeu",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Jeu",
                keyColumn: "idJeu",
                keyValue: 33);
        }
    }
}
