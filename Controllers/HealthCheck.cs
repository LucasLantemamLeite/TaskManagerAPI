using Microsoft.AspNetCore.Mvc;
using TaskManager.Context;

namespace TaskManager.Controllers;

[ApiController]
public class Health : ControllerBase
{

    [HttpGet("/health")]
    public IActionResult HealthCheck(
        [FromServices] TaskManagerContext context
    )
    {
        return Ok("TaskManagerAPI Ativa");
    }
}