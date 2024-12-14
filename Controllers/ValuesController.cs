// Controllers/UserController.cs
using Microsoft.AspNetCore.Mvc;
using testoker.Data;
using testoker.Models;
using Microsoft.EntityFrameworkCore;
namespace testoker.Controllers;

[ApiController]
public class UserController : ControllerBase
{
    private readonly TestContext _context;
    private readonly ILogger<UserController> _logger;

    public UserController(TestContext context, ILogger<UserController> logger)
    {
        _context = context;
        _logger = logger;
    }

    [HttpPost]
    [Route("api/Guardar[controller]")]

    public async Task<IActionResult> CreateUser([FromBody] Usuario user)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _context.Usuarios.AddAsync(user);
        await _context.SaveChangesAsync();

        _logger.LogInformation($"Mensaje de bienvenida enviado a {user.Nombre} al número {user.Telefono}");

        return Ok(new { message = "Datos recibidos correctamente." });
    }

    [HttpGet]
    [Route("api/Obetener[controller]")]

    public async Task<IActionResult> GetUsers()
    {
        var users = await _context.Usuarios.ToListAsync();
        return Ok(users);
    }
}
   
