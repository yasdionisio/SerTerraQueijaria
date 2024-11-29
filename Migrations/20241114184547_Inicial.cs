using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SerTerraQueijaria.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbClientes",
                columns: table => new
                {
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbClientes", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "tbTiposProdutos",
                columns: table => new
                {
                    TiposProdutosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoProduto = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbTiposProdutos", x => x.TiposProdutosId);
                });

            migrationBuilder.CreateTable(
                name: "tbProdutos",
                columns: table => new
                {
                    ProdutoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeProduto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrecoUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QtdEstoque = table.Column<int>(type: "int", nullable: false),
                    TipoProdutoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoProdTiposProdutosId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbProdutos", x => x.ProdutoId);
                    table.ForeignKey(
                        name: "FK_tbProdutos_tbTiposProdutos_TipoProdTiposProdutosId",
                        column: x => x.TipoProdTiposProdutosId,
                        principalTable: "tbTiposProdutos",
                        principalColumn: "TiposProdutosId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbProdutos_TipoProdTiposProdutosId",
                table: "tbProdutos",
                column: "TipoProdTiposProdutosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbClientes");

            migrationBuilder.DropTable(
                name: "tbProdutos");

            migrationBuilder.DropTable(
                name: "tbTiposProdutos");
        }
    }
}
