using System.Security.Cryptography.X509Certificates;
using System.Reflection.PortableExecutable;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PowerAutomate.Core;
using PowerAutomate.Core.Entities;

namespace PowerAutomate.Controllers;

public class ProductosController : Controller
{

    ApplicationDbContext _context;

    public ProductosController( ApplicationDbContext context)
    {
        _context = context;
    }

        public async Task<IActionResult> Index()
        {
            List<Productos> Productos = await _context.Productos.Include(x=>x.Categoria).ToListAsync();
            Productos Producto = new Productos();
            ViewBag.Productos = Productos;
            ViewBag.Categorias = await _context.Categorias.ToListAsync();
            return View(Producto);
        }

        [BindProperty]
        public Productos Producto {get; set;}
        public async Task<IActionResult> SetProducto()
        {   
           
            var _Producto = await _context.Productos.Where(x=>x.IdProducto == Producto.IdProducto).AnyAsync();
            if(!_Producto)
            {
                _context.Productos.Add(Producto);
            }
            else
            {
                _context.Productos.Attach(Producto);
                _context.Entry(Producto).State = EntityState.Modified;
            }            
            await _context.SaveChangesAsync();
            return Redirect("/Productos");
        }

          public async Task<IActionResult> Modificar(int id)
        {
            var Producto = await _context.Productos.FindAsync(id);
            if(Producto == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Categorias = await _context.Categorias.OrderBy(x=>x.Categoria).ToListAsync();
            return View(Producto);
        }

        
        public async Task<IActionResult> Eliminar(int id)
        {
            var _Producto = await _context.Productos.FindAsync(id);
            if(_Producto == null)
            {
                return RedirectToAction("Index");
            }
            else
                _context.Productos.Remove(_Producto);
                _context.SaveChanges();
            return RedirectToAction("Index");
        }

        

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
