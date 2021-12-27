using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PowerAutomate.Core;
using PowerAutomate.Core.Entities;

namespace PowerAutomate.Controllers
{
    [Authorize(Roles="Administrator")]
    public class ClientesController: Controller
    {
        ApplicationDbContext _context;
        private readonly ILogger<ClientesController> _logger;

        public ClientesController(ILogger<ClientesController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            Clientes cliente = new Clientes();
            ViewBag.Clientes = _context.Clientes.ToList();
            return View(cliente);
        }

        [BindProperty]
        public Clientes Cliente {get;set;}
        public IActionResult Guardar()
        {
            if(!ModelState.IsValid)
                {
                    return Redirect("/Clientes/");
                }
                var _Cliente = _context.Clientes.Where(x=> x.IdCliente == Cliente.IdCliente).SingleOrDefault();
                if (_Cliente== null)
                {
                    _context.Clientes.Add(Cliente);
                }
                else
                {
                    _Cliente.Nombre = Cliente.Nombre;
                    _Cliente.Dni= Cliente.Dni;
                    _Cliente.Correo = Cliente.Correo;
                }
                _context.SaveChanges();
                return RedirectToAction("Index");
        }

        public IActionResult Modificar(int id)
        {
            var cliente = _context.Clientes.Find(id);
            if(cliente == null)
            {
                return Redirect("/Clientes/");
            }

            return View(cliente);
        }

        public IActionResult Eliminar(int id)
        {
            var cliente= _context.Clientes.Find(id);
            if(cliente== null)
            {
                return StatusCode(404);
            }

            _context.Clientes.Remove(cliente);
            _context.SaveChanges();
            
            return Redirect("/Clientes/");;
        }

            public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
