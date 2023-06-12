using System;
using System.IO;
using System.Linq;
using CoordsManagment.Domain.DomainEntities;
using CoordsManagment.Infrastructure.Data.Repositories;
using Xunit;

namespace CoordsManagment.Infrastructure.Tests.Infrastructure.Data
{
    public class CoordinatesRepositoryTestSuite
    {
        private readonly string _localDbFullPath;
        private CoordinatesRepository _coordinatesRepository;

        public CoordinatesRepositoryTestSuite()
        {
            // Establecer la ruta del archivo de la base de datos de prueba
            _coordinatesRepository = new CoordinatesRepository();
            _localDbFullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LocalFiles", "Coordinates.txt");
        }

        [Fact]
        public void Insert_Should_Add_Coordinates_To_Database_File()
        {
            // Arrange
            var coords = new Coordinates { CoordinateX = 1, CoordinateY = 2, CoordinateZ = 3 };

            // Act
            _coordinatesRepository.Insert(coords);

            // Assert
            var dbEntries = File.ReadAllLines(_localDbFullPath).ToList();
            var lastEntry = dbEntries.Last();
            Assert.Contains($"Coords [{coords.CoordinateX}, {coords.CoordinateY}, {coords.CoordinateZ}] added on", lastEntry);
        }

        [Fact]
        public void Insert_Should_Throw_Exception_When_Database_File_Not_Found()
        {
            // Arrange
            var coords = new Coordinates { CoordinateX = 1, CoordinateY = 2, CoordinateZ = 3 };
            var nonExistingFilePath = "non_existing.txt";
            var repository = new CoordinatesRepository();

            // Act & Assert
            var exception = Assert.Throws<FileNotFoundException>(() => File.ReadAllLines(nonExistingFilePath).ToList());
            Assert.Equal($"The file '{nonExistingFilePath}' was not found.", exception.Message);
        }
    }
}
