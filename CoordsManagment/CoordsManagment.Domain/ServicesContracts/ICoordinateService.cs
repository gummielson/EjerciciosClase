using CoordsManagment.Domain.DomainEntities;

namespace CoordsManagment.Domain.ServicesContracts
{
    public interface ICoordinateService
    {
        void Register(Coordinates coords);
    }
}
