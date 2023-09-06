using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreGame_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class dummyEntittyScoreResult2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameReviewAverageDTO");

            migrationBuilder.CreateTable(
                name: "AverageScoreResult",
                columns: table => new
                {
                    MoyenneNote = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AverageScoreResult");

            migrationBuilder.CreateTable(
                name: "GameReviewAverageDTO",
                columns: table => new
                {
                    IdJeu = table.Column<int>(type: "int", nullable: false),
                    MoyenneNote = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                });
        }
    }
}
