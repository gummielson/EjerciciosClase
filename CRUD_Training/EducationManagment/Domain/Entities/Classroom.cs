using System.ComponentModel.DataAnnotations;
using static Domain.Enums.Enums;

namespace Domain.Entities
{
    public class Classroom
    {
        [Required]
        [StringLength(1, ErrorMessage = "Name only can have 1 character")]
        [RegularExpression(@"^[^0-9]*$", ErrorMessage = "Name can't contain numeric chars.")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(20, ErrorMessage = "Course only can have 20 characters")]
        [RegularExpression(@"^[^0-9]*$", ErrorMessage = "Name can't contain numeric chars.")]
        public string Course { get; set; } = string.Empty;

        [Required]
        public AreaEnum Area { get; set; } = new AreaEnum();

        [Required]
        public School School { get; set; } = new School();
    }
}
