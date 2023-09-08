using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StoreGame_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddDataGameReview : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GameReview",
                keyColumn: "IdReview",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GameReview",
                keyColumn: "IdReview",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "GameReview",
                keyColumn: "IdReview",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "GameReview",
                keyColumn: "IdReview",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "GameReview",
                keyColumn: "IdReview",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "GameReview",
                keyColumn: "IdReview",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "GameReview",
                keyColumn: "IdReview",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "GameReview",
                keyColumn: "IdReview",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "GameReview",
                keyColumn: "IdReview",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "GameReview",
                keyColumn: "IdReview",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "GameReview",
                keyColumn: "IdReview",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "GameReview",
                keyColumn: "IdReview",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "GameReview",
                keyColumn: "IdReview",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "GameReview",
                keyColumn: "IdReview",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "GameReview",
                keyColumn: "IdReview",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "GameReview",
                keyColumn: "IdReview",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "GameReview",
                keyColumn: "IdReview",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "GameReview",
                keyColumn: "IdReview",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "GameReview",
                keyColumn: "IdReview",
                keyValue: 19);
        }
    }
}
