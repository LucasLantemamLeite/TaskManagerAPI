using System.ComponentModel.DataAnnotations;
using TaskManager.ModelView.Validation;

namespace TaskManager.ModelView;

public class UserAccountModelView
{
    [Required(ErrorMessage = "O campo Name é obrigatório.")]
    [MaxLength(100, ErrorMessage = "O campo Name deve ter menos de 100 caracteres.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "O campo Login é obrigatório.")]
    [MaxLength(50, ErrorMessage = "O campo Login deve ter menos de 50 caracteres.")]
    public string Login { get; set; }

    [Required(ErrorMessage = "O campo Password é obrigatório")]
    [MaxLength(50, ErrorMessage = "O campo Password deve ter menos de 50 caracteres")]
    public string Password { get; set; }

    [Required(ErrorMessage = "O campo Email é obrigatório.")]
    [EmailAddressDomain(ErrorMessage = "O campo Email é inválido, deve possuir '@' e um 'dominio (Ex: .com)' e sem caracteres especiais.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "O campo PhoneNumber é obrigatório.")]
    [MaxLength(20, ErrorMessage = "O campo PhoneNumber deve ter menos de 20 caracteres.")]
    public string PhoneNumber { get; set; }

    [Required(ErrorMessage = "O campo BirthDate é obrigatório.")]
    [DataType(DataType.Date, ErrorMessage = "O campo BirthDate não é uma data válido.")]
    [BirthDateValidation(ErrorMessage = "O campo BirthDate não pode ser uma data maior que a Data Atual.")]
    public DateTime BirthDate { get; set; }

    [Range(1, 2, ErrorMessage = "Deve escolher um nível de 1 (User) à 2(Admin)")]
    public int AcessLevel { get; set; } = 1;
}