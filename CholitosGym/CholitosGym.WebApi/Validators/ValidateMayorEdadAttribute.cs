using System.ComponentModel.DataAnnotations;

namespace CholitosGym.WebApi.Validators
{
    public class ValidateMayorEdadAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var edad = Convert.ToInt32(value);

            if (edad < 18) {
                return new ValidationResult("La edad del cliente debe ser mayor a 18 años. ");
            }

            return ValidationResult.Success;

            
        }
    }
}
