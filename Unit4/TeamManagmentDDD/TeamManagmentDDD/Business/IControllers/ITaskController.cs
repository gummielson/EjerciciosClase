using Business.DTO.RequestDTO;
using Business.DTO.ResponseDTO;

namespace Business.Controllers
{
    public interface ITaskController
    {
        CreateTaskResponseDTO CreateTask(CreateTaskRequestDTO createTaskRequest);
    }
}