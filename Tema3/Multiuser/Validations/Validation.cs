using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Exercise1.Enterprise;
using System.Linq;

namespace Multiuser.Validations
{
    public class Validation
    {
        public void ValidateObject(object obj)
        {
            if (!Validate(obj, out ICollection<ValidationResult> results))
            {
                throw new Exception(string.Join("\n", results.Select(o => o.ErrorMessage)));
            }
        }

        private bool Validate<T>(T obj, out ICollection<ValidationResult> results)
        {
            results = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, new ValidationContext(obj), results, true);
        }
    }
}
