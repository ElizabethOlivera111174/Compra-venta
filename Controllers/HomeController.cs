using System.ComponentModel.Design.Serialization;
using System.Security.Principal;
using System;
using System.Data;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using PowerAutomate.Core;
using PowerAutomate.Core.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;



namespace PowerAutomate.Controllers;
[AllowAnonymous]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;

     public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
     [HttpGet]
    public async Task<IActionResult> Registro()
    {
        return View();
    }
  
    [HttpPost]
    public async Task<IActionResult> Registrar([Bind]User Usuario)
    {
        var result= await _context.User.Where(x => x.FirstName == Usuario.FirstName).SingleOrDefaultAsync();
        Usuario.RoleId=2;
        if (result != null)
        {
                return BadRequest(new JObject() {
                    { "StatusCode", 400 },
                    { "Message", "El usuario ya existe, seleccione otro." }
                });
        }
        else 
        {
            
            // if (!ModelState.IsValid)
            // {
            //     return BadRequest(ModelState.SelectMany(x=> x.Value.Errors.SelectMany(y=> y.ErrorMessage)).ToList());
            // }
            // else
            // {

                var Pass= Encrypt.GetSHA256(Usuario.Password);
                Usuario.Password=Pass;
                _context.User.Add(Usuario);
                await _context.SaveChangesAsync();
                var resultado= await _context.User.Include("Role").Where(x => x.FirstName == Usuario.FirstName).SingleOrDefaultAsync();
                 var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Email, ClaimTypes.Role);
                        identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, resultado.Id.ToString()));
                        identity.AddClaim(new Claim(ClaimTypes.Email, resultado.Email));
                         identity.AddClaim(new Claim(ClaimTypes.Role, resultado.Role.Name));
                        // identity.AddClaim(new Claim(ClaimTypes.Email, "jose.jairo.fuentes@gmail.com"));
                        identity.AddClaim(new Claim("Dato", "Valor"));
                        var principal = new ClaimsPrincipal(identity);
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal,
                            new AuthenticationProperties { ExpiresUtc = DateTime.Now.AddDays(2), IsPersistent = true });
                Usuario.Password= "";
                return Created($"/Usuarios/{Usuario.Id}", Usuario);
            //}
        }
    }

     [HttpGet]
    public IActionResult Login(){
        return View();
    }
     [HttpGet]
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
