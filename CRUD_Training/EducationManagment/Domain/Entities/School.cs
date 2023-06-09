using System.ComponentModel.DataAnnotations;
using static Domain.Enums.Enums;

namespace Domain.Entities
{
    public class School
    {
        [Required]
        [StringLength(30, ErrorMessage = "Name only can have 30 characters")]
        [RegularExpression(@"^[^0-9]*$", ErrorMessage = "Name can't contain numeric chars.")]
        public string Name { get; set; } = string.Empty;

        [StringLength(30, ErrorMessage = "Name only can have 30 characters")]
        public string Address { get; set; } = string.Empty;

        [Required]
        [StringLength(20, ErrorMessage = "Name only can have 20 characters")]
        [RegularExpression(@"^[^0-9]*$", ErrorMessage = "Name can't contain numeric chars.")]
        public string Country { get; set; } = string.Empty;

        [Required]
        public AdministrationEnum Administration { get; set; } = new AdministrationEnum();
    }
}
