using Microsoft.EntityFrameworkCore.Migrations;

namespace RakGameShopAPI.Migrations
{
    public partial class Segundo2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jogo_Pedido_PedidoId",
                table: "Jogo");

            migrationBuilder.DropIndex(
                name: "IX_Jogo_PedidoId",
                table: "Jogo");

            migrationBuilder.DropColumn(
                name: "PedidoId",
                table: "Jogo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PedidoId",
                table: "Jogo",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Jogo_PedidoId",
                table: "Jogo",
                column: "PedidoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jogo_Pedido_PedidoId",
                table: "Jogo",
                column: "PedidoId",
                principalTable: "Pedido",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
