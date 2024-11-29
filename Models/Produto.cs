﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SerTerraQueijaria.Models
{
    public class Produto
    {

        public Guid ProdutoId { get; set; }

        [DisplayName("Nome do Produto")]
        [Required(ErrorMessage = "É necessário ter um Nome do Produto.")]
        public string NomeProduto { get; set; }

        [DisplayName("Descrição")]
        [Required(ErrorMessage = "É necessário ter uma Descrição.")]
        public string Descricao { get; set; }

        [DisplayName("Preço")]
        [Required(ErrorMessage = "É necessário ter um Preço.")]
        public decimal PrecoUnitario { get; set; }

        [DisplayName("Estoque")]
        [Required(ErrorMessage = "É necessário ter um Estoque.")]
        public int QtdEstoque { get; set; }

        public string? Imagem { get; set; }

        [DisplayName("Categoria")]
        [Required(ErrorMessage = "É necessário ter uma Categoria.")]
        public Guid TiposProdutosId { get; set; }

        public TiposProdutos? TiposProdutos {  get; set; }
    }
}

