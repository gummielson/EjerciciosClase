using System.Collections.Generic;
using Domain.Entities;

namespace Infrastructure.Data.Repositories
{
    public interface ITaskRepository
    {
        void CreateTask(TaskEntity task);
        //List<TaskEntity> GetUnassignedTasks();
        //List<TaskEntity> GetAssignedTasks(List<ITWorker> iTWorkers);
        void UpdateTask(TaskEntity taskEntry);
    }
}