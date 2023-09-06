using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreGame_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class dummyEntittyScoreResult : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameReviewAverageDTO");
        }
    }
}
