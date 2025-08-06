using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestProject_API.Migrations
{
    /// <inheritdoc />
    public partial class AddShowGenreRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genre",
                table: "Shows");

            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "Shows",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Shows_GenreId",
                table: "Shows",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shows_Genres_GenreId",
                table: "Shows",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shows_Genres_GenreId",
                table: "Shows");

            migrationBuilder.DropIndex(
                name: "IX_Shows_GenreId",
                table: "Shows");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "Shows");

            migrationBuilder.AddColumn<string>(
                name: "Genre",
                table: "Shows",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
