﻿// <auto-generated />
using ComicShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Comics.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20241003234109_table_quadrinho")]
    partial class table_quadrinho
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ComicShop.Models.Editora", b =>
                {
                    b.Property<int>("IdEditora")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEditora"));

                    b.Property<int>("AnoFundacao")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PaisOrigem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WebSite")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEditora");

                    b.ToTable("Editora");
                });

            modelBuilder.Entity("ComicShop.Models.Quadrinho", b =>
                {
                    b.Property<int>("IdQuadrinho")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdQuadrinho"));

                    b.Property<string>("Autor")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("IdEditora")
                        .HasColumnType("int");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("IdQuadrinho");

                    b.HasIndex("IdEditora");

                    b.ToTable("Quadrinho");
                });

            modelBuilder.Entity("ComicShop.Models.Quadrinho", b =>
                {
                    b.HasOne("ComicShop.Models.Editora", "Editora")
                        .WithMany("Quadrinhos")
                        .HasForeignKey("IdEditora")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Editora");
                });

            modelBuilder.Entity("ComicShop.Models.Editora", b =>
                {
                    b.Navigation("Quadrinhos");
                });
#pragma warning restore 612, 618
        }
    }
}
