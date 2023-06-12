using System.Collections.Generic;
using System;
using Xunit;
using CoordsManagment.Domain.ServicesContracts;
using Moq;
using CoordsManagment.WebApi.Controllers;
using System.Web.Http.Results;
using CoordsManagment.Domain.DomainEntities;
using CoordsManagment.Domain.CustomExceptions;

namespace CoordsManagment.Infrastructure.Tests.WebApi
{
    public class CoordsControllerTestSuite
    {
        private Mock<ICoordinateService> _coordinateServiceMock;
        private CoordsController _coordsController;

        public CoordsControllerTestSuite()
        {
            _coordinateServiceMock = new Mock<ICoordinateService>();
            _coordsController = new CoordsController(_coordinateServiceMock.Object);
        }

        [Fact]
        public void Register_Should_Return_BadRequest_When_Coords_Count_Is_Not_3()
        {
            // Arrange
            var invalidCoords = new List<decimal> { 1, 2, 3, 4 }; // Coords count is 4, not 3

            // Act
            var result = _coordsController.Register(invalidCoords);

            // Assert
            Assert.IsType<BadRequestErrorMessageResult>(result);
            var badRequestResult = (BadRequestErrorMessageResult)result;
            Assert.Equal("Only 3 coordinate list allowed", badRequestResult.Message);
        }

        [Fact]
        public void Register_Should_Return_Ok_When_Coords_Registration_Succeeds()
        {
            // Arrange
            var validCoords = new List<decimal> { 1, 2, 3 };
            _coordinateServiceMock.Setup(x => x.Register(It.IsAny<Coordinates>()));

            // Act
            var result = _coordsController.Register(validCoords);

            // Assert
            Assert.IsType<OkNegotiatedContentResult<string>>(result);
            var okResult = (OkNegotiatedContentResult<string>)result;
            Assert.Equal("The coordenates have been loaded properly.", okResult.Content);
            _coordinateServiceMock.Verify(x => x.Register(It.IsAny<Coordinates>()), Times.Once);
        }

        [Fact]
        public void Register_Should_Return_BadRequest_When_Coords_Registration_Fails()
        {
            // Arrange
            var validCoords = new List<decimal> { 1, 2, 3 };
            var exceptionMessage = "Error saving data";
            _coordinateServiceMock.Setup(x => x.Register(It.IsAny<Coordinates>()))
                .Throws(new CannotSaveDataException(exceptionMessage));

            // Act
            var result = _coordsController.Register(validCoords);

            // Assert
            Assert.IsType<BadRequestErrorMessageResult>(result);
            var badRequestResult = (BadRequestErrorMessageResult)result;
            Assert.Equal($"Error in loading data: {exceptionMessage}", badRequestResult.Message);
            _coordinateServiceMock.Verify(x => x.Register(It.IsAny<Coordinates>()), Times.Once);
        }

        [Fact]
        public void Register_Should_Return_BadRequest_When_Coords_Registration_Throws_Unknown_Error()
        {
            // Arrange
            var validCoords = new List<decimal> { 1, 2, 3 };
            var exceptionMessage = "Unknown error occurred";
            _coordinateServiceMock.Setup(x => x.Register(It.IsAny<Coordinates>()))
                .Throws(new Exception(exceptionMessage));

            // Act
            var result = _coordsController.Register(validCoords);

            // Assert
            Assert.IsType<BadRequestErrorMessageResult>(result);
            var badRequestResult = (BadRequestErrorMessageResult)result;
            Assert.Equal($"Unknown error: {exceptionMessage}", badRequestResult.Message);
            _coordinateServiceMock.Verify(x => x.Register(It.IsAny<Coordinates>()), Times.Once);
        }
    }
}
