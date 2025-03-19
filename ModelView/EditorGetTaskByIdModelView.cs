using System.ComponentModel.DataAnnotations;

namespace TaskManager.ModelView;

public class GetTaskModelView
{
    [Required(ErrorMessage = "O campo UserId é obrigatório")]
    public int UserId { get; set; }
}