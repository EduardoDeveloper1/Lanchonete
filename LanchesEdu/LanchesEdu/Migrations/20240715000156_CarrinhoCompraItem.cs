using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LanchesEdu.Migrations
{
    /// <inheritdoc />
    public partial class CarrinhoCompraItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarrinhoDeComprasItens",
                columns: table => new
                {
                    CarrinhoCompraItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lancheIdLanche = table.Column<int>(type: "int", nullable: true),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    CarrinhoCompraId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarrinhoDeComprasItens", x => x.CarrinhoCompraItemId);
                    table.ForeignKey(
                        name: "FK_CarrinhoDeComprasItens_Lanches_lancheIdLanche",
                        column: x => x.lancheIdLanche,
                        principalTable: "Lanches",
                        principalColumn: "IdLanche");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarrinhoDeComprasItens_lancheIdLanche",
                table: "CarrinhoDeComprasItens",
                column: "lancheIdLanche");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarrinhoDeComprasItens");
        }
    }
}
