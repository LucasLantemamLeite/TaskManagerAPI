using System.Data;
using System.Net.NetworkInformation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TaskManager.Context;
using TaskManager.Models;
using TaskManager.ModelView;

namespace TaskManager.Controllers;

[ApiController]
public class AddNewUser : ControllerBase
{

    [HttpPost("/new-user")]
    public async Task<IActionResult> AddNewUserAccount(
        [FromBody] UserAccountModelView ModelUser,
        [FromServices] TaskManagerContext context
    )
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newUserAccount = new UserAccount
            {
                Name = ModelUser.Name,
                Login = ModelUser.Login,
                Password = ModelUser.Password,
                Email = ModelUser.Email,
                PhoneNumber = ModelUser.PhoneNumber,
                BirthDate = ModelUser.BirthDate,
            };

            await context.UserAccounts.AddAsync(newUserAccount);
            await context.SaveChangesAsync();

            return Ok(newUserAccount);

        }
        catch (DbUpdateException e)
        {
            return BadRequest($"Falha ao se conectar ao banco de dados.\nCódigo de Erro: {e.InnerException}");
        }
    }
}