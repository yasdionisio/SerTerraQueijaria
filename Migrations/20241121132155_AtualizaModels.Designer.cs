﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SerTerraQueijaria.Data;

#nullable disable

namespace SerTerraQueijaria.Migrations
{
    [DbContext(typeof(SerTerraContext))]
    [Migration("20241121132155_AtualizaModels")]
    partial class AtualizaModels
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SerTerraQueijaria.Models.Cliente", b =>
                {
                    b.Property<Guid>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClienteId");

                    b.ToTable("tbClientes", (string)null);
                });

            modelBuilder.Entity("SerTerraQueijaria.Models.Produto", b =>
                {
                    b.Property<Guid>("ProdutoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeProduto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PrecoUnitario")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("QtdEstoque")
                        .HasColumnType("int");

                    b.Property<Guid?>("TipoProdTiposProdutosId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TipoProdutoId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ProdutoId");

                    b.HasIndex("TipoProdTiposProdutosId");

                    b.ToTable("tbProdutos", (string)null);
                });

            modelBuilder.Entity("SerTerraQueijaria.Models.TiposProdutos", b =>
                {
                    b.Property<Guid>("TiposProdutosId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TipoProduto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TiposProdutosId");

                    b.ToTable("tbTiposProdutos", (string)null);
                });

            modelBuilder.Entity("SerTerraQueijaria.Models.Produto", b =>
                {
                    b.HasOne("SerTerraQueijaria.Models.TiposProdutos", "TipoProd")
                        .WithMany()
                        .HasForeignKey("TipoProdTiposProdutosId");

                    b.Navigation("TipoProd");
                });
#pragma warning restore 612, 618
        }
    }
}
