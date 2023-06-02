using Domain.Entities;

namespace Domain.Repositories
{
    public interface IITWorkerRepository
    {
        void CreateWorker(ITWorker worker);
    }
}