using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SerTerraQueijaria.Migrations
{
    /// <inheritdoc />
    public partial class CorrigeRelacaoProdutoTipo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbProdutos_tbTiposProdutos_TipoProdTiposProdutosId",
                table: "tbProdutos");

            migrationBuilder.DropIndex(
                name: "IX_tbProdutos_TipoProdTiposProdutosId",
                table: "tbProdutos");

            migrationBuilder.DropColumn(
                name: "TipoProdTiposProdutosId",
                table: "tbProdutos");

            migrationBuilder.RenameColumn(
                name: "TipoProdutoId",
                table: "tbProdutos",
                newName: "TiposProdutosId");

            migrationBuilder.CreateIndex(
                name: "IX_tbProdutos_TiposProdutosId",
                table: "tbProdutos",
                column: "TiposProdutosId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbProdutos_tbTiposProdutos_TiposProdutosId",
                table: "tbProdutos",
                column: "TiposProdutosId",
                principalTable: "tbTiposProdutos",
                principalColumn: "TiposProdutosId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbProdutos_tbTiposProdutos_TiposProdutosId",
                table: "tbProdutos");

            migrationBuilder.DropIndex(
                name: "IX_tbProdutos_TiposProdutosId",
                table: "tbProdutos");

            migrationBuilder.RenameColumn(
                name: "TiposProdutosId",
                table: "tbProdutos",
                newName: "TipoProdutoId");

            migrationBuilder.AddColumn<Guid>(
                name: "TipoProdTiposProdutosId",
                table: "tbProdutos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbProdutos_TipoProdTiposProdutosId",
                table: "tbProdutos",
                column: "TipoProdTiposProdutosId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbProdutos_tbTiposProdutos_TipoProdTiposProdutosId",
                table: "tbProdutos",
                column: "TipoProdTiposProdutosId",
                principalTable: "tbTiposProdutos",
                principalColumn: "TiposProdutosId");
        }
    }
}
