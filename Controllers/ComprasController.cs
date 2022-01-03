using System.Xml.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Reflection.PortableExecutable;
using System.ComponentModel.Design;
using System.Text;
using System.Data;
using System.Runtime.InteropServices;
using System.Data.Common;
using System.Reflection.Metadata;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PowerAutomate.Core;
using PowerAutomate.Core.Entities;
using Microsoft.AspNetCore.Authorization;

namespace PowerAutomate.Controllers;
[Authorize]
public class ComprasController: Controller
{
    Response res= new Response();
    ApplicationDbContext _context;
    private readonly ILogger<ComprasController> _logger;

    public ComprasController(ILogger<ComprasController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        ViewBag.Compra = await _context.Compras.Include("DetalleCompra").Include(x=>x.Proveedor).ToListAsync();
        return View();
    }

    public async Task<IActionResult> Nuevo(int? id)
    {
            var IdCompra = id ?? 0;
            var _Compra = await _context.Compras.FindAsync(IdCompra);
            var Compra = new Compras();
            if(_Compra != null)
            {
                Compra = _Compra;
            }
            ViewBag.Proveedores = await _context.Proveedores.ToListAsync();
            ViewBag.Productos = await _context.Productos.Select(x=>new{x.IdProducto, NombreProducto= x.Nombre + " - " + x.Marca}).ToListAsync();
            Tuple<Compras, DetalleCompra> Model = new Tuple<Compras, DetalleCompra>(new Compras(), new DetalleCompra());
            ViewBag.DetalleCompra= await _context.DetalleCompra.Include(x=>x.Producto).Where(x=>x.IdCompra == IdCompra).ToListAsync();
            return View(Model);
    }
    public async Task<IActionResult> SetEncabezado([Bind(Prefix="Item1")] Compras Compra)
        {
            // if(!ModelState.IsValid)
            // {
            //     res.estado = false;
            //     res.mensaje = "Rellene los campos solicitados.";
            //     return Json(res);
            // }
            var _Compra = await _context.Compras.FindAsync(Compra.IdCompra);
            if(_Compra == null)
            {
                _context.Compras.Add(Compra);
                await _context.SaveChangesAsync();
            }
            else
            {
                _Compra.IdProveedor = Compra.IdProveedor;
                _Compra.NumeroFactura = Compra.NumeroFactura;
                await _context.SaveChangesAsync();
            }
            res.resultado = Compra.IdCompra;
            res.estado = true;
            return Json(res);
        }
    
        public async Task<IActionResult> SetDetalle([Bind(Prefix="Item2")] DetalleCompra Detalle)
        {
            // if(!ModelState.IsValid)
            // {
            //     res.estado= false;
            //     res.mensaje= "Rellene los campos Solicitados.";
            //     return Json(res);
            // }
            Detalle.Iva= Detalle.Cantidad * Detalle.Precio * 0.21M;
            Detalle.Total= Detalle.Iva + Convert.ToDecimal(Detalle.Cantidad * Detalle.Precio);
            _context.DetalleCompra.Add(Detalle);
            await _context.SaveChangesAsync();
            Detalle.Producto= await _context.Productos.FindAsync(Detalle.IdProducto);
            Detalle.Producto.Precio= Detalle.Precio * Convert.ToDecimal(1.50);
            Detalle.Producto.Stock= Detalle.Producto.Stock + Detalle.Cantidad;
            res.resultado= Detalle;
            res.mensaje= "El producto ha sido agregado";
            res.estado = true;
            return Json(res);
        }

   

        public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}