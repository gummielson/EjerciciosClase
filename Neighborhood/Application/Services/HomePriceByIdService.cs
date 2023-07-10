using Application.ServiceContracts;
using Domain.DomainServices;
using Domain.Entities;
using Domain.RepositoryContracts;

namespace Application.Services
{
    public class HomePriceByIdService : IHomePriceByIdService
    {
        private readonly IRepository _repository;

        public HomePriceByIdService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<decimal> GetHomePrice(int id)
        {
            ViviendasEntity home = await GetVivienda(id);

            if(home is null)
            {
                return 0;
            }
            else
            {
                BarrioEntity barrio = await GetBarrio(home.IdBarrio);

                return HomePriceDomainService.GetPriceByHome(home, barrio, await GetAllAniadidos());
            }
        }

        #region private methods

        private async Task<ViviendasEntity> GetVivienda(int id)
        {
            ViviendasEntity? vivienda = (await GetAllHomes()).FirstOrDefault(x => x.Id == id);

            return vivienda;
        }

        private async Task<BarrioEntity> GetBarrio(int id)
        {
            BarrioEntity? barrio = (await GetAllBarrios()).FirstOrDefault(x => x.Id == id);

            return barrio ?? new();
        }

        #region get data
        private async Task<Dictionary<string, AniadidoEntity>> GetAllAniadidos()
        {
            return await _repository.GetAll<Dictionary<string, AniadidoEntity>>("Anadidos");
        }

        private async Task<IEnumerable<BarrioEntity>> GetAllBarrios()
        {
            return await _repository.GetAll<IEnumerable<BarrioEntity>>("Barrios");
        }

        private async Task<IEnumerable<ViviendasEntity>> GetAllHomes()
        {
            return await _repository.GetAll<IEnumerable<ViviendasEntity>>("Viviendas");
        }
        #endregion
        #endregion
    }
}
