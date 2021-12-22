using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PowerAutomate.Migrations
{
    public partial class primeraMigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Categoria = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.IdCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DNI = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "Proveedores",
                columns: table => new
                {
                    IdProveedor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DNI = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.IdProveedor);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    IdProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.IdProducto);
                    table.ForeignKey(
                        name: "FK_Productos_Categorias_IdCategoria",
                        column: x => x.IdCategoria,
                        principalTable: "Categorias",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    IdVenta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    NumeroFactura = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.IdVenta);
                    table.ForeignKey(
                        name: "FK_Ventas_Clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Clientes",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    IdCompra = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProveedor = table.Column<int>(type: "int", nullable: false),
                    NumeroFactura = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.IdCompra);
                    table.ForeignKey(
                        name: "FK_Compras_Proveedores_IdProveedor",
                        column: x => x.IdProveedor,
                        principalTable: "Proveedores",
                        principalColumn: "IdProveedor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    LastName = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(320)", maxLength: 320, nullable: false),
                    Password = table.Column<string>(type: "VARCHAR(64)", maxLength: 64, nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetalleVenta",
                columns: table => new
                {
                    IdDetalleVenta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdVenta = table.Column<int>(type: "int", nullable: false),
                    IdProducto = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<decimal>(type: "money", nullable: false),
                    IVA = table.Column<decimal>(type: "money", nullable: false),
                    Total = table.Column<decimal>(type: "money", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleVenta", x => x.IdDetalleVenta);
                    table.ForeignKey(
                        name: "FK_DetalleVenta_Productos_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "Productos",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleVenta_Ventas_IdVenta",
                        column: x => x.IdVenta,
                        principalTable: "Ventas",
                        principalColumn: "IdVenta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetalleCompra",
                columns: table => new
                {
                    IdDetalleCompra = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCompra = table.Column<int>(type: "int", nullable: false),
                    IdProducto = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<decimal>(type: "money", nullable: false),
                    IVA = table.Column<decimal>(type: "money", nullable: false),
                    Total = table.Column<decimal>(type: "money", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleCompra", x => x.IdDetalleCompra);
                    table.ForeignKey(
                        name: "FK_DetalleCompra_Compras_IdCompra",
                        column: x => x.IdCompra,
                        principalTable: "Compras",
                        principalColumn: "IdCompra",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleCompra_Productos_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "Productos",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "IdCategoria", "Categoria" },
                values: new object[,]
                {
                    { 1, "Electrodomesticos" },
                    { 2, "Bicicletas" }
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "IdCliente", "Correo", "DNI", "Nombre" },
                values: new object[,]
                {
                    { 1, "nube.wartune@gmail.com", "33678965", "Cliente 1" },
                    { 2, "datanetcomerce@gmail.com", "33456785", "Cliente 2" }
                });

            migrationBuilder.InsertData(
                table: "Proveedores",
                columns: new[] { "IdProveedor", "Correo", "DNI", "Nombre" },
                values: new object[,]
                {
                    { 1, "proveedor1@gmail.com", "33456778", "Proeedor 1" },
                    { 2, "proveedor2@gmail.com", "334678778", "Proeedor 2" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Description User Admin", "Administrator" },
                    { 2, "Description User Standard", "Standard" }
                });

            migrationBuilder.InsertData(
                table: "Compras",
                columns: new[] { "IdCompra", "Fecha", "IdProveedor", "NumeroFactura" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 12, 20, 16, 33, 15, 999, DateTimeKind.Local).AddTicks(5880), 1, "0001" },
                    { 2, new DateTime(2021, 12, 20, 16, 33, 16, 1, DateTimeKind.Local).AddTicks(2078), 2, "0002" }
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "IdProducto", "Descripcion", "IdCategoria", "Marca", "Modelo", "Nombre" },
                values: new object[,]
                {
                    { 1, "Rectangular y delgado", 1, "Sanyo", "Nuevo", "Televisor" },
                    { 2, "Con dos Ruedas", 2, "Kore", "Nuevo", "Bicicleta Kore" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password", "RoleId" },
                values: new object[,]
                {
                    { 1, "Email for user 1 ", "User", "LastName for user ", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", 1 },
                    { 2, "Email for user 2", "User 2", "LastName for user ", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", 2 }
                });

            migrationBuilder.InsertData(
                table: "Ventas",
                columns: new[] { "IdVenta", "Fecha", "IdCliente", "NumeroFactura" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 12, 20, 16, 33, 16, 1, DateTimeKind.Local).AddTicks(5382), 1, "001" },
                    { 2, new DateTime(2021, 12, 20, 16, 33, 16, 1, DateTimeKind.Local).AddTicks(5620), 2, "002" }
                });

            migrationBuilder.InsertData(
                table: "DetalleCompra",
                columns: new[] { "IdDetalleCompra", "Cantidad", "IdCompra", "IdProducto", "IVA", "Precio", "Total" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, 42m, 200m, 242m },
                    { 2, 1, 2, 2, 42m, 200m, 242m }
                });

            migrationBuilder.InsertData(
                table: "DetalleVenta",
                columns: new[] { "IdDetalleVenta", "Cantidad", "IdProducto", "IdVenta", "IVA", "Precio", "Total" },
                values: new object[,]
                {
                    { 1, 2, 1, 1, 21m, 300m, 726m },
                    { 2, 2, 2, 2, 363m, 300m, 726m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Compras_IdProveedor",
                table: "Compras",
                column: "IdProveedor");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleCompra_IdCompra",
                table: "DetalleCompra",
                column: "IdCompra");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleCompra_IdProducto",
                table: "DetalleCompra",
                column: "IdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleVenta_IdProducto",
                table: "DetalleVenta",
                column: "IdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleVenta_IdVenta",
                table: "DetalleVenta",
                column: "IdVenta");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_IdCategoria",
                table: "Productos",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_IdCliente",
                table: "Ventas",
                column: "IdCliente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleCompra");

            migrationBuilder.DropTable(
                name: "DetalleVenta");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Compras");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Ventas");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Proveedores");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
