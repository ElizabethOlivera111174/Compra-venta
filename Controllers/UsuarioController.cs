using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PowerAutomate.Core;
using PowerAutomate.Core.Entities;
using PowerAutomate.Core.ViewModel;

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

      public async Task<IActionResult> Index([Bind] UserVm Useuario)
    {
        var result= await _context.User.Include("Role").Where(x=> x.Email == Useuario.Email).SingleOrDefaultAsync();
        // var result= await _context.User.Include("Role").ToListAsync();
        return Ok(result.Role.Name);
    }

     

        public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}