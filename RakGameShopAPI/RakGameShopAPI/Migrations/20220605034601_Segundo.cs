using Microsoft.EntityFrameworkCore.Migrations;

namespace RakGameShopAPI.Migrations
{
    public partial class Segundo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Classificacao",
                table: "Jogo",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Categoria",
                table: "Jogo",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Classificacao",
                table: "Jogo",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Categoria",
                table: "Jogo",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
