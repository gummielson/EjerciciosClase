using System;
using Crosscuting.Validations;
using Domain.Entities;
using Xunit;

namespace Domain.Test
{
    public class SchoolTest
    {
        /// <summary>
        /// Initializes an instance of the School class with the specified name and country.
        /// </summary>
        /// <param name="name">The name of the school.</param>
        /// <param name="country">Country of teh school.</param>
        /// <returns>An instance of the School class with the specified name and school.</returns>
        public School initializeSchool(string name, string country)
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
            School school = initializeSchool("3435", "Spain");

            // Act and Assert
            Assert.Throws<Exception>(() => school.ValidateObject());
        }

        [Fact]
        public void Name_CantHaveMoreThan30Chars_ThrowException()
        {
            // Arrange
            School school = initializeSchool("ssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss", "Spain");

            // Act and Assert
            Assert.Throws<Exception>(() => school.ValidateObject());
        }

        [Fact]
        public void Country_ContainNumericChars_ThrowException()
        {
            // Arrange
            School school = initializeSchool("Marianistas", "4354");

            // Act and Assert
            Assert.Throws<Exception>(() => school.ValidateObject());
        }

        [Fact]
        public void Country_CantHaveMoreThan30Chars_ThrowException()
        {
            // Arrange
            School school = initializeSchool("Marianistas", "ssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss");

            // Act and Assert
            Assert.Throws<Exception>(() => school.ValidateObject());
        }
    }
}
