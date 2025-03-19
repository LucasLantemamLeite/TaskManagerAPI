using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace TaskManager.ModelView.Validation;

public class EmailAddressDomain : ValidationAttribute
{

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {

        var Email = value.ToString();

        var regex = @"^[a-zA-Z0-9]+@[a-zA-Z0-9-]+(\.[a-zA-Z0-9-]{2,})*$";


        if (Regex.IsMatch(Email, regex))
            return ValidationResult.Success;

        return new ValidationResult(ErrorMessage ?? "O campo Email é inválido, deve possuir '@' e um 'dominio (Ex: .com)' e sem caracteres especiais.");

    }
}