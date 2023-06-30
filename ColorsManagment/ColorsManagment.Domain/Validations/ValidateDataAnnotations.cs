using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ColorsManagment.Domain.Validations
{
    public static class ValidateDataAnnotations
    {
        public static void ValidateObject(this object obj)
        {
            if (!Validate(obj, out ICollection<ValidationResult> results))
            {
                throw new ValidationException(string.Join(" - ", results.Select(o => o.ErrorMessage)));
            }
        }

        private static bool Validate<T>(T obj, out ICollection<ValidationResult> results)
        {
            results = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, new ValidationContext(obj), results, true);
        }
    }
}
