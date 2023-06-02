using Domain.Entities;

namespace Infrastructure.Data.Repositories
{
    public interface ITaskRepository
    {
        void CreateTask(TaskEntity task);
    }
}