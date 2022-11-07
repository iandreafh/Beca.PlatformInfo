using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Beca.PlatformInfo.API.Migrations
{
    public partial class PlatformIndoDBInitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Platforms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platforms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 300, nullable: false),
                    PlatformId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_Platforms_PlatformId",
                        column: x => x.PlatformId,
                        principalTable: "Platforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[] { 1, "The reliable one, always creating new content.", "Netflix" });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[] { 2, "The cheapest one, accesible for everyone.", "Amazon Prime Video" });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[] { 3, "The youngest of them all.", "Disney+" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "PlatformId", "Title" },
                values: new object[] { 1, "Película romántica de época basada en una novela.", 1, "Orgullo y Prejuicio" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "PlatformId", "Title" },
                values: new object[] { 2, "Película de ciencia ficción sobre la galaxia.", 1, "Star Wars" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "PlatformId", "Title" },
                values: new object[] { 3, "Película de comedia americana sobre un grupo de amigos.", 2, "Niños grandes" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "PlatformId", "Title" },
                values: new object[] { 4, "Película musical de animación sobre un teatro de animales.", 2, "Canta" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "PlatformId", "Title" },
                values: new object[] { 5, "Película musical sobre un grupo de adolescentes que van a un campamento de verano.", 3, "Camp Rock" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "PlatformId", "Title" },
                values: new object[] { 6, "Película infantil de animación sobre el valor de la amistad y la familia.", 3, "Hermano Oso" });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_PlatformId",
                table: "Movies",
                column: "PlatformId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Platforms");
        }
    }
}
