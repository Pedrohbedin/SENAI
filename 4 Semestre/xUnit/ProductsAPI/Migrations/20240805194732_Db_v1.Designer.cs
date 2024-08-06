﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductsAPI.Context;

#nullable disable

namespace ProductsAPI.Migrations
{
    [DbContext(typeof(ProductsContext))]
    [Migration("20240805194732_Db_v1")]
    partial class Db_v1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProductsAPI.Domains.Products", b =>
                {
                    b.Property<Guid>("IdProduct")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("DECIMAL");

                    b.HasKey("IdProduct");

                    b.ToTable("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
