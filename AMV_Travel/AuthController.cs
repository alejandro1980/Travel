using AMV_Travel.Entities;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public AuthController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] Usuario login)
    {
        var usuario = _context.Usuarios.SingleOrDefault(u => u.NombreUsuario == login.NombreUsuario && u.Contrasena == login.Contrasena);
        if (usuario == null)
        {
            return Unauthorized();
        }
        return Ok("Login successful");
    }
}