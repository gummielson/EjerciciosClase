using System.Collections.Generic;
using System.Web.Http.Results;
using System.Web.Http;
using ColorsManagment.Domain.Entities;
using ColorsManagment.Domain.RepositoriesContracts;
using ColorsManagment.Domain.Services;
using ColorsManagment.Domain.ServicesContracts;
using ColorsManagment.Infrastructure.Data.Repositories;
using ColorsManagment.WebAPI.Controllers;
using Moq;
using Xunit;
using ColorsManagment.Domain.Validations;

namespace ColorsManagment.Infrastructure.Test.Domain
{
    public class ColorServiceTestSuite
    {
        #region initialize

        private ColorService InitService()
        {
            return new ColorService(
                        new ColorRepository());
        }

        private ColorService InitControllerWithMockedService()
        {
            Mock<IColorRepository> repositoryMock = new Mock<IColorRepository>();
            repositoryMock.Setup(x => x.Insert(It.IsAny<ColorEntity>()));

            IColorRepository mockedRepository = repositoryMock.Object;

            return new ColorService(mockedRepository);
        }
        #endregion

        #region tests

        [Fact]
        public void IntegrationTest_Register_InputValid_ReturnsOk()
        {
            // Arrange
            ColorService service = InitService();
            ColorEntity color = new ColorEntity
            {
                Color = "Red",
                NumericValue = 10
            };

            // Act
            var ex = Record.Exception(() => service.Register(color));

            // Assert
            Assert.Null(ex);
        }
        #endregion
    }
}
