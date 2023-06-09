using System;
using System.ComponentModel.DataAnnotations;
using static Domain.Enums.Enums;

namespace Domain.Entities
{
    public class Student
    {
        [Required]
        [StringLength(30, ErrorMessage = "Name only can have 30 character")]
        [RegularExpression(@"^[^0-9]*$", ErrorMessage = "Name can't contain numeric chars.")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range(6, 22, ErrorMessage = "A student can only be between the ages of 6 and 22")]
        public int Age { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Nationality only can have 20 character")]
        [RegularExpression(@"^[^0-9]*$", ErrorMessage = "Name can't contain numeric chars.")]
        public string Nationality { get; set; } = string.Empty;

        [Required]
        public Classroom Classroom { get; set; } = new Classroom();

        public void ValidateAgeAndArea()
        {
            switch (Age) 
            { 
                case int n when n >= 6 && n <= 12:
                    CheckCourse(Classroom.Area, AreaEnum.Primary);
                    break;
                case int n when n > 12 && n <= 16:
                    CheckCourse(Classroom.Area, AreaEnum.Secundary);
                    break;
                case int n when n > 16 && n <= 22:
                    CheckCourse(Classroom.Area, AreaEnum.Tertiary);
                    break;
            }
        }

        private void CheckCourse(AreaEnum thisArea, AreaEnum area)
        {
            if (thisArea != area)
            {
                throw new Exception("The age of the student doesn´t coincede with his area");
            }
        }
    }
}
