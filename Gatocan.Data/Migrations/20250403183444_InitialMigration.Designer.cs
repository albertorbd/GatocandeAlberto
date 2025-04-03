﻿// <auto-generated />
using System;
using Gatocan.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Gatocan.Data.Migrations
{
    [DbContext(typeof(GatocanContext))]
    [Migration("20250403183444_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Gatocan.Model.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Carts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateCreated = new DateTime(2024, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 1
                        });
                });

            modelBuilder.Entity("Gatocan.Model.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Brand = "MarcaA",
                            Category = "Comida",
                            Description = "Alimento balanceado para perros",
                            ImageUrl = "https://example.com/imagen1.jpg",
                            Name = "Comida para perros",
                            Price = 20.5,
                            Stock = 50
                        },
                        new
                        {
                            Id = 2,
                            Brand = "MarcaB",
                            Category = "Juguetes",
                            Description = "Juguete interactivo para gatos",
                            ImageUrl = "https://example.com/imagen2.jpg",
                            Name = "Juguete para gatos",
                            Price = 15.0,
                            Stock = 30
                        });
                });

            modelBuilder.Entity("Gatocan.Model.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("Transactions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 20.5,
                            Date = new DateTime(2024, 5, 6, 0, 9, 2, 0, DateTimeKind.Unspecified),
                            PaymentMethod = "Tarjeta",
                            ProductId = 1,
                            Quantity = 1,
                            Tipo = 1,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Amount = 50.0,
                            Date = new DateTime(2024, 5, 6, 0, 9, 12, 0, DateTimeKind.Unspecified),
                            PaymentMethod = "Transferencia",
                            ProductId = 1,
                            Quantity = 1,
                            Tipo = 0,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("Gatocan.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("Balance")
                        .HasColumnType("float");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Balance = 100.0,
                            Email = "juan@example.com",
                            Lastname = "Pérez",
                            Name = "Juan",
                            Password = "pass123",
                            Role = "Cliente"
                        },
                        new
                        {
                            Id = 2,
                            Balance = 150.0,
                            Email = "ana@example.com",
                            Lastname = "Gómez",
                            Name = "Ana",
                            Password = "pass456",
                            Role = "Admin"
                        });
                });

            modelBuilder.Entity("Gatocan.Model.Cart", b =>
                {
                    b.HasOne("Gatocan.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsMany("Gatocan.Model.CartItem", "Items", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"), 1L, 1);

                            b1.Property<int>("CartId")
                                .HasColumnType("int");

                            b1.Property<int>("ProductId")
                                .HasColumnType("int");

                            b1.Property<int>("Quantity")
                                .HasColumnType("int");

                            b1.HasKey("Id");

                            b1.HasIndex("CartId");

                            b1.ToTable("CartItem");

                            b1.WithOwner()
                                .HasForeignKey("CartId");

                            b1.HasData(
                                new
                                {
                                    Id = 1,
                                    CartId = 1,
                                    ProductId = 2,
                                    Quantity = 3
                                });
                        });

                    b.Navigation("Items");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Gatocan.Model.Transaction", b =>
                {
                    b.HasOne("Gatocan.Model.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Gatocan.Model.User", "User")
                        .WithMany("Transactions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Gatocan.Model.User", b =>
                {
                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
