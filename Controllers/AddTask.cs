using System.Data.Common;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Context;
using TaskManager.Models;
using TaskManager.ModelView.Validation;

namespace TaskManager.Controllers;


[ApiController]
public class AddNewTaskItem : ControllerBase
{

    [HttpPost("/new-task")]
    public async Task<IActionResult> AddNewTask(
        [FromBody] TaskItemModelView ModelTask,
        [FromServices] TaskManagerContext context
    )
    {
        try
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var newTask = new TaskItem
            {

                Title = ModelTask.Title,
                Description = ModelTask.Description,
                DeadLine = ModelTask.DeadLine,
                UserId = ModelTask.UserId

            };

            await context.TaskItems.AddAsync(newTask);
            await context.SaveChangesAsync();

            return Ok(newTask);
        }
        catch (DbException e)
        {
            return BadRequest($"Falha ao se conectar ao banco de dados.\nCódigo de Erro: {e.InnerException}");
        }
    }
}