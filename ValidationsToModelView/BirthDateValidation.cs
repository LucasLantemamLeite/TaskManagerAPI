using System.ComponentModel.DataAnnotations;

namespace TaskManager.ModelView.Validation;

public class BirthDateValidation : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is DateTime BirthDate)
        {
            if (BirthDate <= DateTime.Now)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(ErrorMessage ?? "O campo BirthDate não pode ser uma data maior que a Data Atual.");
            }
        }
        return new ValidationResult(ErrorMessage ?? "O campo BirthDate não é uma data válido.");
    }
}