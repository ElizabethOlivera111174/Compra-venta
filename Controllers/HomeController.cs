using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using PowerAutomate.Core;
using PowerAutomate.Core.Entities;



namespace PowerAutomate.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    ApplicationDbContext _context;

     public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }
    public async Task<IActionResult> Registro()
    {
        return View();
    }
  
    [HttpPost]
    public async Task<IActionResult> Registrar([Bind]User Usuario)
    {
        var result= await _context.Users.Where(x => x.FirstName == Usuario.FirstName).SingleOrDefaultAsync();
        if (result != null)
        {
                return BadRequest(new JObject() {
                    { "StatusCode", 400 },
                    { "Message", "El usuario ya existe, seleccione otro." }
                });
        }
        else 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.SelectMany(x=> x.Value.Errors.SelectMany(y=> y.ErrorMessage)).ToList());
            }
            else
            {
                var Pass= Encrypt.GetSHA256(Usuario.Password);
                Usuario.Password=Pass;
                _context.Users.Add(Usuario);
                await _context.SaveChangesAsync();
                Usuario.Password= "";
                return Created($"/Usuarios/{Usuario.Id}", Usuario);
            }
        }
    }
    public IActionResult Login(){
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
