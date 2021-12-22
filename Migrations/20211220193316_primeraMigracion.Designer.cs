﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace PowerAutomate.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211220193316_primeraMigracion")]
    partial class primeraMigracion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OngProject.Core.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR(255)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Description User Admin",
                            Name = "Administrator"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Description User Standard",
                            Name = "Standard"
                        });
                });

            modelBuilder.Entity("PowerAutomate.Core.Categorias", b =>
                {
                    b.Property<int>("IdCategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdCategoria");

                    b.ToTable("Categorias");

                    b.HasData(
                        new
                        {
                            IdCategoria = 1,
                            Categoria = "Electrodomesticos"
                        },
                        new
                        {
                            IdCategoria = 2,
                            Categoria = "Bicicletas"
                        });
                });

            modelBuilder.Entity("PowerAutomate.Core.Clientes", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Dni")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("DNI");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdCliente");

                    b.ToTable("Clientes");

                    b.HasData(
                        new
                        {
                            IdCliente = 1,
                            Correo = "nube.wartune@gmail.com",
                            Dni = "33678965",
                            Nombre = "Cliente 1"
                        },
                        new
                        {
                            IdCliente = 2,
                            Correo = "datanetcomerce@gmail.com",
                            Dni = "33456785",
                            Nombre = "Cliente 2"
                        });
                });

            modelBuilder.Entity("PowerAutomate.Core.Compras", b =>
                {
                    b.Property<int>("IdCompra")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime");

                    b.Property<int>("IdProveedor")
                        .HasColumnType("int");

                    b.Property<string>("NumeroFactura")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("IdCompra");

                    b.HasIndex("IdProveedor");

                    b.ToTable("Compras");

                    b.HasData(
                        new
                        {
                            IdCompra = 1,
                            Fecha = new DateTime(2021, 12, 20, 16, 33, 15, 999, DateTimeKind.Local).AddTicks(5880),
                            IdProveedor = 1,
                            NumeroFactura = "0001"
                        },
                        new
                        {
                            IdCompra = 2,
                            Fecha = new DateTime(2021, 12, 20, 16, 33, 16, 1, DateTimeKind.Local).AddTicks(2078),
                            IdProveedor = 2,
                            NumeroFactura = "0002"
                        });
                });

            modelBuilder.Entity("PowerAutomate.Core.DetalleCompra", b =>
                {
                    b.Property<int>("IdDetalleCompra")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("IdCompra")
                        .HasColumnType("int");

                    b.Property<int>("IdProducto")
                        .HasColumnType("int");

                    b.Property<decimal>("Iva")
                        .HasColumnType("money")
                        .HasColumnName("IVA");

                    b.Property<decimal>("Precio")
                        .HasColumnType("money");

                    b.Property<decimal?>("Total")
                        .HasColumnType("money");

                    b.HasKey("IdDetalleCompra");

                    b.HasIndex("IdCompra");

                    b.HasIndex("IdProducto");

                    b.ToTable("DetalleCompra");

                    b.HasData(
                        new
                        {
                            IdDetalleCompra = 1,
                            Cantidad = 1,
                            IdCompra = 1,
                            IdProducto = 1,
                            Iva = 42m,
                            Precio = 200m,
                            Total = 242m
                        },
                        new
                        {
                            IdDetalleCompra = 2,
                            Cantidad = 1,
                            IdCompra = 2,
                            IdProducto = 2,
                            Iva = 42m,
                            Precio = 200m,
                            Total = 242m
                        });
                });

            modelBuilder.Entity("PowerAutomate.Core.DetalleVenta", b =>
                {
                    b.Property<int>("IdDetalleVenta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("IdProducto")
                        .HasColumnType("int");

                    b.Property<int>("IdVenta")
                        .HasColumnType("int");

                    b.Property<decimal>("Iva")
                        .HasColumnType("money")
                        .HasColumnName("IVA");

                    b.Property<decimal>("Precio")
                        .HasColumnType("money");

                    b.Property<decimal?>("Total")
                        .HasColumnType("money");

                    b.HasKey("IdDetalleVenta");

                    b.HasIndex("IdProducto");

                    b.HasIndex("IdVenta");

                    b.ToTable("DetalleVenta");

                    b.HasData(
                        new
                        {
                            IdDetalleVenta = 1,
                            Cantidad = 2,
                            IdProducto = 1,
                            IdVenta = 1,
                            Iva = 21m,
                            Precio = 300m,
                            Total = 726m
                        },
                        new
                        {
                            IdDetalleVenta = 2,
                            Cantidad = 2,
                            IdProducto = 2,
                            IdVenta = 2,
                            Iva = 363m,
                            Precio = 300m,
                            Total = 726m
                        });
                });

            modelBuilder.Entity("PowerAutomate.Core.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(320)
                        .HasColumnType("VARCHAR(320)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("VARCHAR(64)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "Email for user 1 ",
                            FirstName = "User",
                            LastName = "LastName for user ",
                            Password = "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92",
                            RoleId = 1
                        },
                        new
                        {
                            Id = 2,
                            Email = "Email for user 2",
                            FirstName = "User 2",
                            LastName = "LastName for user ",
                            Password = "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92",
                            RoleId = 2
                        });
                });

            modelBuilder.Entity("PowerAutomate.Core.Productos", b =>
                {
                    b.Property<int>("IdProducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("IdCategoria")
                        .HasColumnType("int");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdProducto");

                    b.HasIndex("IdCategoria");

                    b.ToTable("Productos");

                    b.HasData(
                        new
                        {
                            IdProducto = 1,
                            Descripcion = "Rectangular y delgado",
                            IdCategoria = 1,
                            Marca = "Sanyo",
                            Modelo = "Nuevo",
                            Nombre = "Televisor"
                        },
                        new
                        {
                            IdProducto = 2,
                            Descripcion = "Con dos Ruedas",
                            IdCategoria = 2,
                            Marca = "Kore",
                            Modelo = "Nuevo",
                            Nombre = "Bicicleta Kore"
                        });
                });

            modelBuilder.Entity("PowerAutomate.Core.Proveedores", b =>
                {
                    b.Property<int>("IdProveedor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Dni")
                        .IsRequired()
                        .HasMaxLength(17)
                        .HasColumnType("nvarchar(17)")
                        .HasColumnName("DNI");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdProveedor");

                    b.ToTable("Proveedores");

                    b.HasData(
                        new
                        {
                            IdProveedor = 1,
                            Correo = "proveedor1@gmail.com",
                            Dni = "33456778",
                            Nombre = "Proeedor 1"
                        },
                        new
                        {
                            IdProveedor = 2,
                            Correo = "proveedor2@gmail.com",
                            Dni = "334678778",
                            Nombre = "Proeedor 2"
                        });
                });

            modelBuilder.Entity("PowerAutomate.Core.Ventas", b =>
                {
                    b.Property<int>("IdVenta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<string>("NumeroFactura")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("IdVenta");

                    b.HasIndex("IdCliente");

                    b.ToTable("Ventas");

                    b.HasData(
                        new
                        {
                            IdVenta = 1,
                            Fecha = new DateTime(2021, 12, 20, 16, 33, 16, 1, DateTimeKind.Local).AddTicks(5382),
                            IdCliente = 1,
                            NumeroFactura = "001"
                        },
                        new
                        {
                            IdVenta = 2,
                            Fecha = new DateTime(2021, 12, 20, 16, 33, 16, 1, DateTimeKind.Local).AddTicks(5620),
                            IdCliente = 2,
                            NumeroFactura = "002"
                        });
                });

            modelBuilder.Entity("PowerAutomate.Core.Compras", b =>
                {
                    b.HasOne("PowerAutomate.Core.Proveedores", "Proveedor")
                        .WithMany("Compras")
                        .HasForeignKey("IdProveedor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Proveedor");
                });

            modelBuilder.Entity("PowerAutomate.Core.DetalleCompra", b =>
                {
                    b.HasOne("PowerAutomate.Core.Compras", "Compra")
                        .WithMany("DetalleCompra")
                        .HasForeignKey("IdCompra")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PowerAutomate.Core.Productos", "Producto")
                        .WithMany("DetalleCompra")
                        .HasForeignKey("IdProducto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Compra");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("PowerAutomate.Core.DetalleVenta", b =>
                {
                    b.HasOne("PowerAutomate.Core.Productos", "Producto")
                        .WithMany("DetalleVenta")
                        .HasForeignKey("IdProducto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PowerAutomate.Core.Ventas", "Venta")
                        .WithMany("DetalleVenta")
                        .HasForeignKey("IdVenta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producto");

                    b.Navigation("Venta");
                });

            modelBuilder.Entity("PowerAutomate.Core.Entities.User", b =>
                {
                    b.HasOne("OngProject.Core.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("PowerAutomate.Core.Productos", b =>
                {
                    b.HasOne("PowerAutomate.Core.Categorias", "Categoria")
                        .WithMany("Productos")
                        .HasForeignKey("IdCategoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("PowerAutomate.Core.Ventas", b =>
                {
                    b.HasOne("PowerAutomate.Core.Clientes", "Cliente")
                        .WithMany("Ventas")
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("PowerAutomate.Core.Categorias", b =>
                {
                    b.Navigation("Productos");
                });

            modelBuilder.Entity("PowerAutomate.Core.Clientes", b =>
                {
                    b.Navigation("Ventas");
                });

            modelBuilder.Entity("PowerAutomate.Core.Compras", b =>
                {
                    b.Navigation("DetalleCompra");
                });

            modelBuilder.Entity("PowerAutomate.Core.Productos", b =>
                {
                    b.Navigation("DetalleCompra");

                    b.Navigation("DetalleVenta");
                });

            modelBuilder.Entity("PowerAutomate.Core.Proveedores", b =>
                {
                    b.Navigation("Compras");
                });

            modelBuilder.Entity("PowerAutomate.Core.Ventas", b =>
                {
                    b.Navigation("DetalleVenta");
                });
#pragma warning restore 612, 618
        }
    }
}
