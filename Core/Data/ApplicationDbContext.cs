using System;
using Microsoft.EntityFrameworkCore;
using OngProject.Core.Entities;
using PowerAutomate.Core;
using PowerAutomate.Core.Entities;

public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options)
        {
        }
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //de esta manera la propiedad email de los usuarios sera unica y no se podra repetir
            builder.Entity<User>(entity => {
                entity.HasIndex(e => e.Email).IsUnique();
            });

            SeedRoles(builder);
            SeedUsers(builder);
            SeedClientes(builder);
            SeedCategorias(builder); 
            SeedProductos(builder);
            SeedProveedores(builder);
            SeedCompras(builder);
            SeedVentas(builder);
            SeedDetalleCompra(builder);
            SeedDetalleVenta(builder);
            

        }
        
              public DbSet<User> User { get; set; }
              public DbSet<Role> Role { get; set; } 
              public DbSet<Categorias> Categorias { get; set; }
              public DbSet<Clientes> Clientes { get; set; }
              public DbSet<DetalleCompra> DetalleCompra { get; set; }
              public DbSet<DetalleVenta> DetalleVenta { get; set; }
              public DbSet<Productos> Productos { get; set; }
              public DbSet<Proveedores> Proveedores { get; set; }
              public DbSet<Compras> Compras { get; set; }



           private void SeedUsers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FirstName = "User",
                    LastName = "LastName for user ",
                    Email = "user1@gmail.com",
                    Password = Encrypt.GetSHA256("123456"),
                    RoleId = 1,
                }
            );
            
            
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 2,
                    FirstName = "User 2",
                    LastName = "LastName for user ",
                    Email = "user2@gmail.com",
                    Password = Encrypt.GetSHA256("123456"),
                    RoleId = 2,
                       
                }
            );
            
        }
        private void SeedRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                    new Role
                    {
                        Id = 1,
                        Name = "Administrator",
                        Description = "Description User Admin",
                    },
                    new Role
                    {
                        Id = 2,
                        Name = "Standard",
                        Description = "Description User Standard"
                    }
                );
        }
         private void SeedClientes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clientes>().HasData(
                    new Clientes
                    {
                        IdCliente = 1,
                        Nombre = "Cliente 1",
                        Dni = "33678965",
                        Correo= "nube.wartune@gmail.com"

                    },
                    new Clientes
                    {
                        IdCliente = 2,
                        Nombre = "Cliente 2",
                        Dni = "33456785",
                        Correo= "datanetcomerce@gmail.com"
                    }
                );
        }
         private void SeedCategorias(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorias>().HasData(
                    new Categorias
                    {
                        IdCategoria = 1,
                        Categoria = "Electrodomesticos",
                    },
                    new Categorias
                    {
                        IdCategoria = 2,
                        Categoria = "Bicicletas",
                    }
                );
        }

         private void SeedProductos(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Productos>().HasData(
                    new Productos
                    {
                        IdProducto = 1,
                        Nombre = "Televisor",
                        Descripcion= "Rectangular y delgado",
                        Marca= "Sanyo",
                        Modelo= "Nuevo",
                        IdCategoria= 1
                    },
                    new Productos
                    {
                        IdProducto = 2,
                        Nombre = "Bicicleta Kore",
                        Descripcion= "Con dos Ruedas",
                        Marca= "Kore",
                        Modelo= "Nuevo",
                        IdCategoria= 2
                    }
                );
        }

         private void SeedProveedores(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Proveedores>().HasData(
                    new Proveedores
                    {
                        IdProveedor = 1,
                        Nombre = "Proeedor 1",
                        Dni= "33456778",
                        Correo= "proveedor1@gmail.com",
                    },
                    new Proveedores
                    {
                        IdProveedor = 2,
                        Nombre = "Proeedor 2",
                        Dni= "334678778",
                        Correo= "proveedor2@gmail.com",
                    }
                );
        }

          private void SeedCompras(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Compras>().HasData(
                    new Compras
                    {
                        IdCompra = 1,
                        IdProveedor = 1,
                        NumeroFactura= "0001",
                        Fecha= DateTime.Now,
                    },
                    new Compras
                    {
                        IdCompra = 2,
                        IdProveedor = 2,
                        NumeroFactura= "0002",
                        Fecha= DateTime.Now,
                    }                    
                );
        }
         private void SeedVentas(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ventas>().HasData(
                    new Ventas
                    {
                        IdVenta = 1,
                        IdCliente = 1,
                        NumeroFactura = "001",
                        Fecha= DateTime.Now,
                        
                    },
                    new Ventas
                    {
                        IdVenta = 2,
                        IdCliente = 2,
                        NumeroFactura = "002",
                        Fecha= DateTime.Now,                
                    }                    
                );
        }
          private void SeedDetalleCompra(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DetalleCompra>().HasData(
                    new DetalleCompra
                    {
                        IdDetalleCompra = 1,
                        IdCompra = 1,
                        IdProducto= 1,
                        Precio= 200,
                        Cantidad= 1,
                        Iva= 42,
                        Total= 242
                        
                    },
                    new DetalleCompra
                    {
                        IdDetalleCompra = 2,
                        IdCompra = 2,
                        IdProducto= 2,
                        Cantidad= 1,
                        Precio= 200,
                        Iva= 42, 
                        Total= 242                  
                    }                    
                );
        }
         private void SeedDetalleVenta(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DetalleVenta>().HasData(
                    new DetalleVenta
                    {
                     IdDetalleVenta= 1,
                     IdVenta=1,
                     IdProducto= 1,
                     Cantidad= 2,
                     Precio = 300,
                     Iva= 21,
                     Total= 726
                    },
                    new DetalleVenta
                    {
                     IdDetalleVenta= 2,
                     IdVenta=2,
                     IdProducto= 2,
                     Cantidad= 2,
                     Precio = 300,
                     Iva= 363,   
                     Total= 726                     
                    }                    
                );
        }
    }