using CoordsManagment.Domain.DomainEntities;

namespace CoordsManagment.Domain.RepositoryContracts
{
    public interface ICoordinateRepository
    {
        void Insert(Coordinates cords);
    }
}
