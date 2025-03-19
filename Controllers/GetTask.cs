using System.Data.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager.Context;
using TaskManager.ModelView;

namespace TaskManager.Controllers;

[ApiController]
public class GetTask : ControllerBase
{
    [HttpGet("/get-task")]
    public async Task<IActionResult> GetTaskByIdUser(
        [FromBody] GetTaskModelView userid,
        [FromServices] TaskManagerContext context
    )
    {
        try
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userTasks = await context.UserAccounts.AsNoTracking().OrderByDescending(x => x.UserTasks.FirstOrDefault().CreatedOn).Where(x => x.Id == userid.UserId).Include(x => x.UserTasks).FirstOrDefaultAsync();

            if (userTasks == null)
                return NotFound("Id não encontrado!");

            return Ok(userTasks);

        }
        catch (DbException e)
        {
            return BadRequest($"Falha ao se conectar ao banco de dados.\nCódigo de Erro: {e.InnerException}");
        }
    }
}