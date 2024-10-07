using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Comics.Migrations
{
    /// <inheritdoc />
    public partial class add_fk_fornecedor_in_quadrinho : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdFornecedor",
                table: "Quadrinho",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Quadrinho_IdFornecedor",
                table: "Quadrinho",
                column: "IdFornecedor");

            migrationBuilder.AddForeignKey(
                name: "FK_Quadrinho_Fornecedor_IdFornecedor",
                table: "Quadrinho",
                column: "IdFornecedor",
                principalTable: "Fornecedor",
                principalColumn: "IdFornecedor",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quadrinho_Fornecedor_IdFornecedor",
                table: "Quadrinho");

            migrationBuilder.DropIndex(
                name: "IX_Quadrinho_IdFornecedor",
                table: "Quadrinho");

            migrationBuilder.DropColumn(
                name: "IdFornecedor",
                table: "Quadrinho");
        }
    }
}
