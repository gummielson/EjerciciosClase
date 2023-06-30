using System;
using System.ComponentModel.DataAnnotations;

namespace ColorsManagment.Domain.Entities
{
    public class ColorEntity
    {
        [RegularExpression("Green|Blue|Red", ErrorMessage = "Invalid color")]
        public string Color { get; set; } = string.Empty;

        [Range(0, 100, ErrorMessage = "Please enter valid integer number between 0 and 100")]
        public int NumericValue { get; set; }

        public string DefaultValue { get; set; } = string.Empty;

    }
}
