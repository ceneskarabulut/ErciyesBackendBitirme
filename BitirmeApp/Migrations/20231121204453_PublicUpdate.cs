using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BitirmeApp.Migrations
{
    /// <inheritdoc />
    public partial class PublicUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Makaleler_Kullanicilar_KullaniciId",
                table: "Makaleler");

            migrationBuilder.DropForeignKey(
                name: "FK_Yorumlar_Kullanicilar_KullaniciId",
                table: "Yorumlar");

            migrationBuilder.DropForeignKey(
                name: "FK_Yorumlar_Makaleler_MakaleId",
                table: "Yorumlar");

            migrationBuilder.AlterColumn<int>(
                name: "MakaleId",
                table: "Yorumlar",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "KullaniciId",
                table: "Yorumlar",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "KullaniciId",
                table: "Makaleler",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Makaleler_Kullanicilar_KullaniciId",
                table: "Makaleler",
                column: "KullaniciId",
                principalTable: "Kullanicilar",
                principalColumn: "KullaniciId");

            migrationBuilder.AddForeignKey(
                name: "FK_Yorumlar_Kullanicilar_KullaniciId",
                table: "Yorumlar",
                column: "KullaniciId",
                principalTable: "Kullanicilar",
                principalColumn: "KullaniciId");

            migrationBuilder.AddForeignKey(
                name: "FK_Yorumlar_Makaleler_MakaleId",
                table: "Yorumlar",
                column: "MakaleId",
                principalTable: "Makaleler",
                principalColumn: "MakaleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Makaleler_Kullanicilar_KullaniciId",
                table: "Makaleler");

            migrationBuilder.DropForeignKey(
                name: "FK_Yorumlar_Kullanicilar_KullaniciId",
                table: "Yorumlar");

            migrationBuilder.DropForeignKey(
                name: "FK_Yorumlar_Makaleler_MakaleId",
                table: "Yorumlar");

            migrationBuilder.AlterColumn<int>(
                name: "MakaleId",
                table: "Yorumlar",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "KullaniciId",
                table: "Yorumlar",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "KullaniciId",
                table: "Makaleler",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Makaleler_Kullanicilar_KullaniciId",
                table: "Makaleler",
                column: "KullaniciId",
                principalTable: "Kullanicilar",
                principalColumn: "KullaniciId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Yorumlar_Kullanicilar_KullaniciId",
                table: "Yorumlar",
                column: "KullaniciId",
                principalTable: "Kullanicilar",
                principalColumn: "KullaniciId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Yorumlar_Makaleler_MakaleId",
                table: "Yorumlar",
                column: "MakaleId",
                principalTable: "Makaleler",
                principalColumn: "MakaleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
