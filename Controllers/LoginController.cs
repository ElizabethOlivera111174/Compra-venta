using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using PowerAutomate.Core;
using PowerAutomate.Core.Entities;
using PowerAutomate.Core.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using PowerAutomate.Core.Helpers;
using System.Text;


namespace PowerAutomate.Controllers;

public class LoginController : Controller
{
    private readonly IConfiguration _config;
    private readonly ILogger<HomeController> _logger;
    ApplicationDbContext _context;

     public LoginController(ILogger<HomeController> logger, ApplicationDbContext context, IConfiguration config)
    {
        _logger = logger;
        _context = context;
        _config = config;
    }

    public IActionResult Index()
    {
        if (User.Identity.IsAuthenticated)
        {
            return Redirect("/Home");
        }
        else
        {
        return View();
        }
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
            var result= await _context.User.Include("Role").Where(x=> x.Email == Useuario.Email).SingleOrDefaultAsync();
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
                //        var secretKey = _config.GetValue<string>("SecretKey");
                //     var key = Encoding.ASCII.GetBytes(secretKey);

                // var claims = new ClaimsIdentity();
                // claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, Useuario.Email));

                // var tokenDescriptor = new SecurityTokenDescriptor
                // {
                //     Subject = claims,
                //     Expires = DateTime.UtcNow.AddHours(4),
                //     SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                // };

                // var tokenHandler = new JwtSecurityTokenHandler();
                // var createdToken = tokenHandler.CreateToken(tokenDescriptor);
                
                // string bearer_token = tokenHandler.WriteToken(createdToken);
                // return Ok(bearer_token);
                  var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Email, ClaimTypes.Role);
                        identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, result.Id.ToString()));
                        identity.AddClaim(new Claim(ClaimTypes.Email, result.Email));
                        identity.AddClaim(new Claim(ClaimTypes.Role, result.Role.Name));
                        // identity.AddClaim(new Claim(ClaimTypes.Email, "jose.jairo.fuentes@gmail.com"));
                        identity.AddClaim(new Claim("Dato", "Valor"));
                        var principal = new ClaimsPrincipal(identity);
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal,
                            new AuthenticationProperties { ExpiresUtc = DateTime.Now.AddDays(2), IsPersistent = true });
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
  
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();
        return Redirect("/Login");
    }
    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
