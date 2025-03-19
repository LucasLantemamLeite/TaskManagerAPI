using System.ComponentModel.DataAnnotations;

namespace TaskManager.ModelView.Validation;

public class DeadLineValidation : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {

        if (value == null)
            return ValidationResult.Success;

        if (value is DateTime DeadLine)
        {
            if (DeadLine >= DateTime.Now)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(ErrorMessage ?? "O campo DeadLine não pode ser uma data menor que a Data Atual.");
            }

        }
        return new ValidationResult(ErrorMessage ?? "O campo DeadLine não é uma data válida.");
    }
}