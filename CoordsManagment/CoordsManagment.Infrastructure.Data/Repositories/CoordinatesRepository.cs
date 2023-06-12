using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CoordsManagment.Domain.DomainEntities;
using CoordsManagment.Domain.RepositoryContracts;

namespace CoordsManagment.Infrastructure.Data.Repositories
{
    public class CoordinatesRepository : ICoordinateRepository
    {
        private readonly string _localDbFullPath;

        public CoordinatesRepository()
        {
            _localDbFullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LocalFiles", "Coordinates.txt");
        }

        public void Insert(Coordinates cords)
        {
            List<string> dbAsList = File.ReadAllLines(_localDbFullPath).ToList();

            string dataToInsert = $"Coords [{cords.CoordinateX}, {cords.CoordinateY}, {cords.CoordinateZ}] added on {DateTime.UtcNow}";

            dbAsList.Add(dataToInsert);

            File.WriteAllLines(_localDbFullPath, dbAsList);
        }
    }
}
