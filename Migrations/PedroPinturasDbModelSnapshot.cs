﻿// <auto-generated />
using System;
using API_PedroPinturas.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace APIPedroPinturas.Migrations
{
    [DbContext(typeof(PedroPinturasDb))]
    partial class PedroPinturasDbModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("API_PedroPinturas.Models.Color", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Colores");
                });

            modelBuilder.Entity("API_PedroPinturas.Models.Compra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("integer");

                    b.Property<int>("PedidoId")
                        .HasColumnType("integer");

                    b.Property<int?>("ProductoId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PedidoId");

                    b.HasIndex("ProductoId");

                    b.ToTable("Compra");
                });

            modelBuilder.Entity("API_PedroPinturas.Models.Evento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("AireLibre")
                        .HasColumnType("boolean");

                    b.Property<string>("Descripcion")
                        .HasColumnType("text");

                    b.Property<string>("Event")
                        .HasColumnType("text");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Lugar")
                        .HasColumnType("text");

                    b.Property<string>("Materiales")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Event")
                        .IsUnique();

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("API_PedroPinturas.Models.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Direccion")
                        .HasColumnType("text");

                    b.Property<bool>("Entrega24h")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("Fecha")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("integer");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(5, 2)");

                    b.HasKey("Id");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("API_PedroPinturas.Models.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Calidad")
                        .HasColumnType("text");

                    b.Property<int?>("ColorId")
                        .HasColumnType("integer");

                    b.Property<string>("Descripcion")
                        .HasColumnType("text");

                    b.Property<double>("Precio")
                        .HasColumnType("double precision");

                    b.Property<string>("Productos")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ColorId");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("API_PedroPinturas.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Contrasenia")
                        .HasColumnType("text");

                    b.Property<int?>("EventoId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("boolean");

                    b.Property<string>("NombreApellidos")
                        .HasColumnType("text");

                    b.Property<int>("Telefono")
                        .HasColumnType("integer");

                    b.Property<string>("User")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("EventoId");

                    b.HasIndex("User")
                        .IsUnique();

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("API_PedroPinturas.Models.Compra", b =>
                {
                    b.HasOne("API_PedroPinturas.Models.Pedido", "pedido")
                        .WithMany("Compras")
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_PedroPinturas.Models.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("ProductoId");

                    b.Navigation("Producto");

                    b.Navigation("pedido");
                });

            modelBuilder.Entity("API_PedroPinturas.Models.Pedido", b =>
                {
                    b.HasOne("API_PedroPinturas.Models.Usuario", "Usuario")
                        .WithMany("Pedidos")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("API_PedroPinturas.Models.Producto", b =>
                {
                    b.HasOne("API_PedroPinturas.Models.Color", "Color")
                        .WithMany()
                        .HasForeignKey("ColorId");

                    b.Navigation("Color");
                });

            modelBuilder.Entity("API_PedroPinturas.Models.Usuario", b =>
                {
                    b.HasOne("API_PedroPinturas.Models.Evento", null)
                        .WithMany("Usuarios")
                        .HasForeignKey("EventoId");
                });

            modelBuilder.Entity("API_PedroPinturas.Models.Evento", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("API_PedroPinturas.Models.Pedido", b =>
                {
                    b.Navigation("Compras");
                });

            modelBuilder.Entity("API_PedroPinturas.Models.Usuario", b =>
                {
                    b.Navigation("Pedidos");
                });
#pragma warning restore 612, 618
        }
    }
}
