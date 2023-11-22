using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BitirmeApp.Migrations
{
    /// <inheritdoc />
    public partial class NotNullKullanici : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KategoriId",
                table: "Yorumlar",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Yorumlar_KategoriId",
                table: "Yorumlar",
                column: "KategoriId");

            migrationBuilder.AddForeignKey(
                name: "FK_Yorumlar_Kategoriler_KategoriId",
                table: "Yorumlar",
                column: "KategoriId",
                principalTable: "Kategoriler",
                principalColumn: "KategoriId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Yorumlar_Kategoriler_KategoriId",
                table: "Yorumlar");

            migrationBuilder.DropIndex(
                name: "IX_Yorumlar_KategoriId",
                table: "Yorumlar");

            migrationBuilder.DropColumn(
                name: "KategoriId",
                table: "Yorumlar");
        }
    }
}
