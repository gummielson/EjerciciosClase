using System.ComponentModel.DataAnnotations;
using Crosscuting.Validations;
using Domain.Entities;
using Xunit;

namespace Domain.Test
{
    public class SchoolTestSuite
    {
        /// <summary>
        /// Initializes an instance of the School class with the specified name and country.
        /// </summary>
        /// <param name="name">The name of the school.</param>
        /// <param name="country">Country of teh school.</param>
        /// <returns>An instance of the School class with the specified name and school.</returns>
        public School InitializeSchool(string name, string country)
        {
            return new School
            {
                Name = name,
                Country = country
            };
        }

        [Fact]
        public void Name_ContainNumericChars_ThrowException()
        {
            // Arrange
            School school = InitializeSchool("3435", "Spain");

            // Act and Assert
            Assert.Throws<ValidationException>(() => school.ValidateObject());
        }

        [Fact]
        public void Name_CantHaveMoreThan30Chars_ThrowException()
        {
            // Arrange
            School school = InitializeSchool("ssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss", "Spain");

            // Act and Assert
            Assert.Throws<ValidationException>(() => school.ValidateObject());
        }

        [Fact]
        public void Country_ContainNumericChars_ThrowException()
        {
            // Arrange
            School school = InitializeSchool("Marianistas", "4354");

            // Act and Assert
            Assert.Throws<ValidationException>(() => school.ValidateObject());
        }

        [Fact]
        public void Country_CantHaveMoreThan30Chars_ThrowException()
        {
            // Arrange
            School school = InitializeSchool("Marianistas", "ssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss");

            // Act and Assert
            Assert.Throws<ValidationException>(() => school.ValidateObject());
        }
    }
}
