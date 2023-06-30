using ColorsManagment.Domain.Entities;

namespace ColorsManagment.Domain.RepositoriesContracts
{
    public interface IColorRepository
    {
        void Insert(ColorEntity color);
    }
}
