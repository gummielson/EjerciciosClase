using System.Collections.Generic;
using Business.DTO.RequestDTO;
using Business.DTO.ResponseDTO;
using Domain.Entities;

namespace Business.Services
{
    public interface ITaskServices
    {
        CreateTaskResponseDTO CreateTask(CreateTaskRequestDTO request);
        GetUnassignedTaskResponseDTO GetUnassignedTasks();
        List<TaskEntity> GetAssignedTasks(List<ITWorker> iTWorkers);
        void UpdateTask(TaskEntity task);
    }
}