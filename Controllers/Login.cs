using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using TaskManager.Models;
using TaskManager.Services;

namespace TaskManager.Controllers;
[ApiController]
public class AccountLogin : ControllerBase
{
    [HttpPost("/login")]
    public IActionResult Login(
        [FromServices] TokenService _tokenService
    )
    {
        var token = _tokenService.GerenerateToken(null);

        return Ok(token);
    }
}