using Business.DTO.RequestDTO;
using Business.DTO.ResponseDTO;
using Domain.Entities;

namespace Business.Services
{
    public interface ITaskServices
    {
        CreateTaskResponseDTO CreateTask(CreateTaskRequestDTO request);
        TaskEntity GenerateTaskEntity(CreateTaskRequestDTO request);
    }
}