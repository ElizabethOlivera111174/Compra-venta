using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PowerAutomate.Core;
using PowerAutomate.Core.Entities;

namespace PowerAutomate.Controllers;

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

    public async Task<IActionResult> Nuevo()
    {
            ViewBag.Proveedores = await _context.Proveedores.ToListAsync();
            ViewBag.Productos = await _context.Productos.Select(x=>new{x.IdProducto, NombreProducto= x.Nombre + " - " + x.Marca}).ToListAsync();
            Tuple<Compras, DetalleCompra> Model = new Tuple<Compras, DetalleCompra>(new Compras(), new DetalleCompra());
            return View(Model);
    }
    public async Task<IActionResult> SetEncabezado([Bind(Prefix="Item1")] Compras Compra)
        {
            if(!ModelState.IsValid)
            {
                res.estado = false;
                res.mensaje = "Rellene los campos solicitados.";
                return Json(res);
            }
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
    
    // public async Task<IActionResult> SetEncabezado([Bind(Prefix="Item1")] Compras Compra)
    // {
    //     if(!ModelState.IsValid)
    //     {
    //         res.estado= false;
    //         res.mensaje= "Rellene los campos Solicitados.";
    //         return Json(res);
    //     }
    //     _context.Compras.Add(Compra);
    //     await _context.SaveChangesAsync();
    //     res.resultado= Compra.IdCompra;
    //     res.estado=true;
    //     return Json(res);
    // }

   

        public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}