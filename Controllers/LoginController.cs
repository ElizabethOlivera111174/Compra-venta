using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using PowerAutomate.Core;
using PowerAutomate.Core.Entities;
using PowerAutomate.Core.ViewModel;

namespace PowerAutomate.Controllers;

public class LoginController : Controller
{
    private readonly ILogger<HomeController> _logger;
    ApplicationDbContext _context;

     public LoginController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }
    public async Task<IActionResult> Login([Bind] UserVm Useuario)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new JObject() {
                    { "StatusCode", 400 },
                    { "Message", "El usuario ya existe, seleccione otro." }
                });
        }
        else
        {
            var result= await _context.Users.Where(x=> x.Email == Useuario.Email).SingleOrDefaultAsync();
            if (result == null)
            {
                return NotFound(new JObject() {
                    { "StatusCode", 400 },
                    { "Message", "Usuario no encontrado" }
                });
            }
            else
            {
                if (Encrypt.Verify(Useuario.Password, result.Password))
                {
                    return Ok(result);
                }
                else
                {
                    var response = new JObject() {
                            { "StatusCode", 403 },
                            { "Message", "Usuario o contraseña no válida." }
                        };
                        return StatusCode(403, response);
                }
            }
        }
    }
  

    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
