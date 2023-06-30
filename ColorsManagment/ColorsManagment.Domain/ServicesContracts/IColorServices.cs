using ColorsManagment.Domain.Entities;

namespace ColorsManagment.Domain.ServicesContracts
{
    public interface IColorServices
    {
        void Register(ColorEntity color);
    }
}
