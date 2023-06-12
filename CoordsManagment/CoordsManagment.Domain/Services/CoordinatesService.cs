using System;
using CoordsManagment.Domain.CustomExceptions;
using CoordsManagment.Domain.DomainEntities;
using CoordsManagment.Domain.RepositoryContracts;
using CoordsManagment.Domain.ServicesContracts;

namespace CoordsManagment.Domain.Services
{
    public class CoordinatesService : ICoordinateService
    {
        private readonly ICoordinateRepository _coordinateRepository;

        public CoordinatesService(ICoordinateRepository repository)
        {
            _coordinateRepository = repository;
        }

        public void Register(Coordinates coords)
        {
            try
            {
                _coordinateRepository.Insert(coords);
            }
            catch (Exception ex)
            {
                throw new CannotSaveDataException(ex.Message);
            }
        }
    }
}
