using ColorsManagment.Domain.Entities;
using ColorsManagment.Domain.RepositoriesContracts;
using ColorsManagment.Domain.Services;
using ColorsManagment.Infrastructure.Data.Repositories;
using Moq;
using Xunit;

namespace ColorsManagment.Infrastructure.Test.Infrastructure.Data
{
    public class ColorRepositoryTestSuite
    {
        #region initialize

        private ColorRepository InitRepository()
        {
            return new ColorRepository();
        }

        #endregion

        #region tests

        [Fact]
        public void IntegrationTest_Register_InputValid_ReturnsOk()
        {
            // Arrange
            ColorRepository repository = InitRepository();
            ColorEntity color = new ColorEntity();

            // Act
            var ex = Record.Exception(() => repository.Insert(color));

            // Assert
            Assert.Null(ex);
        }
        #endregion
    }
}
