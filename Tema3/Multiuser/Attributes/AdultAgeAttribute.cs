using System;
using System.ComponentModel.DataAnnotations;

namespace Multiuser.Attributes
{
    /// <summary>
    /// Validate if the DateTime of birthday property is an adult
    /// </summary>
    public class AdultAgeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            const int legalAge = 18;
            DateTime birthDate = (DateTime)value;
            int age = DateTime.Today.Year - birthDate.Year;

            if (age < legalAge)
            {
                return new ValidationResult("The entered birthdate does not correspond to someone of legal age");
            }

            return ValidationResult.Success;
        }
    }
}
