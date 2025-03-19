using System.ComponentModel.DataAnnotations;

namespace TaskManager.ModelView.Validation;

public class TaskItemModelView
{
    [Required(ErrorMessage = "O campo Title é obrigatório.")]
    [MaxLength(50, ErrorMessage = "O campo Title deve ter menos de 50 caracteres.")]
    public string Title { get; set; }

    [MaxLength(500, ErrorMessage = "O campo Description deve ter menos de 500 caractesres.")]
    public string? Description { get; set; }

    [DataType(DataType.Date, ErrorMessage = "O campo DeadLine não é uma data válida.")]
    [DeadLineValidation(ErrorMessage = "O campo DeadLine não pode ser uma data maior que a Data Atual.")]
    public DateTime? DeadLine { get; set; }

    [Required(ErrorMessage = "O campo UserId é obrigatório.")]
    public int UserId { get; set; }

}