using CoordsManagment.Domain.CustomExceptions;
using CoordsManagment.Domain.DomainEntities;
using CoordsManagment.Domain.RepositoryContracts;
using CoordsManagment.Domain.Services;
using Moq;
using System;
using Xunit;

namespace CoordsManagment.Infrastructure.Tests.Infrastructure.Data
{
    public class CoordinatesServiceTestSuite
    {
        private Mock<ICoordinateRepository> _coordinateRepositoryMock;
        private CoordinatesService _coordinatesService;

        public CoordinatesServiceTestSuite()
        {
            _coordinateRepositoryMock = new Mock<ICoordinateRepository>();
            _coordinatesService = new CoordinatesService(_coordinateRepositoryMock.Object);
        }

        [Fact]
        public void Register_Should_Insert_Coordinates()
        {
            // Arrange
            var coords = new Coordinates { CoordinateX = 1, CoordinateY = 2, CoordinateZ = 3 };

            // Act
            _coordinatesService.Register(coords);

            // Assert
            _coordinateRepositoryMock.Verify(x => x.Insert(coords), Times.Once);
        }

        [Fact]
        public void Register_Should_Throw_CannotSaveDataException_When_Repository_Throws_Exception()
        {
            // Arrange
            var coords = new Coordinates { CoordinateX = 1, CoordinateY = 2, CoordinateZ = 3 };
            var exceptionMessage = "Error saving data";
            _coordinateRepositoryMock.Setup(x => x.Insert(coords)).Throws(new Exception(exceptionMessage));

            // Act & Assert
            var exception = Assert.Throws<CannotSaveDataException>(() => _coordinatesService.Register(coords));
            Assert.Equal(exceptionMessage, exception.Message);
        }
    }
}
