using Microsoft.EntityFrameworkCore.Migrations;

namespace RakGameShopAPI.Migrations
{
    public partial class PedidosJogos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Parcelamento",
                table: "Pedido");

            migrationBuilder.AddColumn<int>(
                name: "PedidoId",
                table: "ClienteJogo",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PedidoId",
                table: "ClienteJogo");

            migrationBuilder.AddColumn<int>(
                name: "Parcelamento",
                table: "Pedido",
                nullable: false,
                defaultValue: 0);
        }
    }
}
