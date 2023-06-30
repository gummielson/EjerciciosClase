using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Http;
using System.Web.Http.Results;
using ColorsManagment.Domain.CustomExceptions;
using ColorsManagment.Domain.Entities;
using ColorsManagment.Domain.Services;
using ColorsManagment.Domain.ServicesContracts;
using ColorsManagment.Infrastructure.Data.Repositories;
using ColorsManagment.WebAPI.Controllers;
using Moq;
using Xunit;

namespace ColorsManagment.Infrastructure.Test.WebAPI
{
    public class ColorControllerTestSuite
    {
        #region private controller initializers

        private ColorController InitController()
        {
            return new ColorController(
                    new ColorService(
                        new ColorRepository()));
        }

        private ColorController InitControllerWithMockedService()
        {
            Mock<IColorServices> serviceMock = new Mock<IColorServices>();
            serviceMock.Setup(x => x.Register(It.IsAny<ColorEntity>()));

            IColorServices mockedService = serviceMock.Object;

            return new ColorController(mockedService);
        }
        #endregion

        #region tests

        [Fact]
        public void UnitTest_Register_InputValid_ValidationException_ReturnsBadRequest()
        {
            // Arrange
            Mock<IColorServices> serviceMock = new Mock<IColorServices>();
            serviceMock.Setup(x => x.Register(It.IsAny<ColorEntity>())).Throws<ValidationException>();

            IColorServices mockedService = serviceMock.Object;

            ColorController controller = new ColorController(mockedService);

            List<string> values = new List<string> { "", "", "" };

            // Act
            IHttpActionResult result = controller.RegisterColor(values);

            // Assert
            Assert.IsType<BadRequestErrorMessageResult>(result);
        }

        [Fact]
        public void UnitTest_Register_InputValid_CannotSaveDataExceptionCaught_ReturnsBadRequest()
        {
            // Arrange
            Mock<IColorServices> serviceMock = new Mock<IColorServices>();
            serviceMock.Setup(x => x.Register(It.IsAny<ColorEntity>())).Throws< CannotInsertDataException> ();

            IColorServices mockedService = serviceMock.Object;

            ColorController controller = new ColorController(mockedService);

            List<string> values = new List<string> { "", "", "" };

            // Act
            IHttpActionResult result = controller.RegisterColor(values);

            // Assert
            Assert.IsType<BadRequestErrorMessageResult>(result);
        }

        [Fact]
        public void UnitTest_Register_InputValid_Exception_ReturnsBadRequest()
        {
            // Arrange
            Mock<IColorServices> serviceMock = new Mock<IColorServices>();
            serviceMock.Setup(x => x.Register(It.IsAny<ColorEntity>())).Throws<System.Exception>();

            IColorServices mockedService = serviceMock.Object;

            ColorController controller = new ColorController(mockedService);

            List<string> values = new List<string> { "", "", "" };

            // Act
            IHttpActionResult result = controller.RegisterColor(values);

            // Assert
            Assert.IsType<BadRequestErrorMessageResult>(result);
        }

        [Fact]
        public void IntegrationTest_Register_InputValid_ReturnsOkResult()
        {
            // Arrange
            ColorController controller = InitController();
            List<string> values = new List<string> { "Red", "14", "" };

            // Act
            IHttpActionResult result = controller.RegisterColor(values);

            // Assert
            Assert.IsType<OkNegotiatedContentResult<string>>(result);
        }

        [Fact]
        public void UnitTest_Register_InputValid_ReturnsOkResult()
        {
            // Arrange
            ColorController controller = InitControllerWithMockedService();
            List<string> values = new List<string> { "", "4", "" };

            // Act
            IHttpActionResult result = controller.RegisterColor(values);

            // Assert
            Assert.IsType<OkNegotiatedContentResult<string>>(result);
        }

        [Fact]
        public void UnitTest_Register_InputNull_ReturnsBadRequestResult()
        {
            // Arrange
            ColorController controller = InitControllerWithMockedService();
            List<string> values = null;

            // Act
            IHttpActionResult result = controller.RegisterColor(values);

            // Assert
            Assert.IsType<BadRequestErrorMessageResult>(result);
        }

        [Fact]
        public void UnitTest_Register_InputSizeZero_ReturnsBadRequestResult()
        {
            // Arrange
            ColorController controller = InitControllerWithMockedService();
            List<string> values = new List<string>();

            // Act
            IHttpActionResult result = controller.RegisterColor(values);

            // Assert
            Assert.IsType<BadRequestErrorMessageResult>(result);
        }

        [Fact]
        public void UnitTest_Register_InputSizeMoreThanThree_ReturnsBadRequestResult()
        {
            // Arrange
            ColorController controller = InitControllerWithMockedService();
            List<string> values = new List<string> { "", "", "", "", "" };

            // Act
            IHttpActionResult result = controller.RegisterColor(values);

            // Assert
            Assert.IsType<BadRequestErrorMessageResult>(result);
        }

        [Fact]
        public void UnitTest_Register_InputNotNumeric_ReturnsBadRequestResult()
        {
            // Arrange
            ColorController controller = InitControllerWithMockedService();
            List<string> values = new List<string> { "", "aa", ""};

            // Act
            IHttpActionResult result = controller.RegisterColor(values);

            // Assert
            Assert.IsType<BadRequestErrorMessageResult>(result);
        }
        #endregion

    }
}
