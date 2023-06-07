using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IITWorkerRepository
    {
        void CreateWorker(ITWorker worker);
        void UpdateWorker(ITWorker workerEntry);
        List<ITWorker> GetWorkers();
        ITWorker GetITWorkerById(int id);
    }
}