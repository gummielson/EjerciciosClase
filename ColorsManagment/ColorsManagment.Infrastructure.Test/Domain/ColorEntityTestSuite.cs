using System.ComponentModel.DataAnnotations;
using ColorsManagment.Domain.Entities;
using ColorsManagment.Domain.Validations;
using Xunit;

namespace ColorsManagment.Infrastructure.Test.Domain
{
    public class ColorEntityTestSuite
    {
        private ColorEntity CreateEntity(string color, int number) 
        {
            return new ColorEntity
            {
                Color = color,
                NumericValue = number
            };
        }

        [Fact]
        public void ColorEntity_InsertRightValues_ThrowsNoException()
        {
            // Arrange
            ColorEntity color = CreateEntity("Red", 3);

            // Act
            var ex = Record.Exception(() => color.ValidateObject());

            // Assert
            Assert.Null(ex);
        }

        [Fact]
        public void ColorEntity_InsertWrongColor_ThrowsValidationException()
        {
            // Arrange
            ColorEntity color = CreateEntity("yellow", 3);

            // Act and Assert
            Assert.Throws<ValidationException>(() => color.ValidateObject());
        }

        [Fact]
        public void ColorEntity_InsertWrongNumber_ThrowsValidationException()
        {
            // Arrange
            ColorEntity color = CreateEntity("Red", -5);

            // Act and Assert
            Assert.Throws<ValidationException>(() => color.ValidateObject());
        }
    }
}
