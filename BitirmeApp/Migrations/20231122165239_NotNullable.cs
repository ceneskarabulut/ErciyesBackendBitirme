using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BitirmeApp.Migrations
{
    /// <inheritdoc />
    public partial class NotNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Makaleler_Kullanicilar_KullaniciId",
                table: "Makaleler");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Makaleler_Kullanicilar_KullaniciId",
                table: "Makaleler");

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
        }
    }
}
