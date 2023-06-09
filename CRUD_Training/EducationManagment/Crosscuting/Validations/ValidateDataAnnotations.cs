using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Crosscuting.Validations
{
    public static class ValidateDataAnnotations
    {
        public static void ValidateObject(this object obj)
        {
            if (!Validate(obj, out ICollection<ValidationResult> results))
            {
                throw new Exception(string.Join("\n", results.Select(o => o.ErrorMessage)));
            }
        }

        private static bool Validate<T>(T obj, out ICollection<ValidationResult> results)
        {
            results = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, new ValidationContext(obj), results, true);
        }
    }
}
