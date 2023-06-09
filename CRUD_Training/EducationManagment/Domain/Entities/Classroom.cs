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
        [Range(0, 6, ErrorMessage = "The field course can´t be less than 0 and greater than 6.")]
        public int Course { get; set; }

        [Required]
        public AreaEnum Area { get; set; } = new AreaEnum();

        [Required]
        public School School { get; set; } = new School();

        public void ValidCourse()
        {
            switch (Area) 
            {
                case AreaEnum.Secundary:
                    CourseException(4);
                    break;
                case AreaEnum.Tertiary:
                    CourseException(2);
                    break;
            }
        }

        private void CourseException(int num)
        {
            if(Course > num)
            {
                throw new ValidationException("Invalid area or course");
            }
        }
    }
}
