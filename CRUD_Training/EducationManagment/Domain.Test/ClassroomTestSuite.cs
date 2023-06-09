using System.ComponentModel.DataAnnotations;
using Crosscuting.Validations;
using Domain.Entities;
using Xunit;
using static Domain.Enums.Enums;

namespace Domain.Test
{
    public class ClassroomTestSuite
    {
        /// <summary>
        /// Initializes an instance of the Classroom class with the specified name and course.
        /// </summary>
        /// <param name="name">The name of the classroom.</param>
        /// <param int="course">Course of the classroom.</param>
        /// <returns>An instance of the Classroom class with the specified name and course.</returns>
        public Classroom InitializeClassroom(string name, int course, AreaEnum area)
        {
            return new Classroom
            {
                Name = name,
                Course = course,
                Area = area
            };
        }

        [Fact]
        public void Name_ContainNumericChars_ThrowException()
        {
            // Arrange
            Classroom classroom = InitializeClassroom("3", 1, AreaEnum.Primary);

            // Act and Assert
            Assert.Throws<ValidationException>(() => classroom.ValidateObject());
        }

        [Fact]
        public void Name_CantHaveMoreThan30Chars_ThrowException()
        {
            // Arrange
            Classroom classroom = InitializeClassroom("ss", 1, AreaEnum.Primary);

            // Act and Assert
            Assert.Throws<ValidationException>(() => classroom.ValidateObject());
        }

        [Fact]
        public void Course_InRange_ThrowException()
        {
            // Arrange
            Classroom classroom = InitializeClassroom("A", 7, AreaEnum.Primary);

            // Act and Assert
            Assert.Throws<ValidationException>(() => classroom.ValidateObject());
        }

        [Fact]
        public void ValidCourse_CantBeArea3AndCourse3_ThrowException()
        {
            // Arrange
            Classroom classroom = InitializeClassroom("A", 3, AreaEnum.Tertiary);

            // Act and Assert
            Assert.Throws<ValidationException>(() => classroom.ValidCourse());
        }

        [Fact]
        public void ValidCourse_CantBeArea2AndCourse5_ThrowException()
        {
            // Arrange
            Classroom classroom = InitializeClassroom("A", 5, AreaEnum.Secundary);

            // Act and Assert
            Assert.Throws<ValidationException>(() => classroom.ValidCourse());
        }

        [Fact]
        public void ValidCourse_CanBeArea2AndCourse3_ReturnNoErrror()
        {
            // Arrange
            Classroom classroom = InitializeClassroom("A", 3, AreaEnum.Secundary);

            // Act
            var ex = Record.Exception(() => classroom.ValidCourse());

            // Assert
            Assert.Null(ex);
        }
    }
}
