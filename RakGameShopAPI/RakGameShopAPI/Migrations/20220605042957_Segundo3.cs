using Microsoft.EntityFrameworkCore.Migrations;

namespace RakGameShopAPI.Migrations
{
    public partial class Segundo3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jogo_Cliente_ClienteId",
                table: "Jogo");

            migrationBuilder.DropIndex(
                name: "IX_Jogo_ClienteId",
                table: "Jogo");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Jogo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Jogo",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Jogo_ClienteId",
                table: "Jogo",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jogo_Cliente_ClienteId",
                table: "Jogo",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
