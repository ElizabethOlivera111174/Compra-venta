using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PowerAutomate.Core;
using PowerAutomate.Core.Entities;

namespace PowerAutomate.Controllers;

public class UsuarioController: Controller
{
    Response res= new Response();
    ApplicationDbContext _context;
    private readonly ILogger<ComprasController> _logger;

    public UsuarioController(ILogger<ComprasController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

      public async Task<IActionResult> Index()
    {
        return View();
    }

     

        public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}