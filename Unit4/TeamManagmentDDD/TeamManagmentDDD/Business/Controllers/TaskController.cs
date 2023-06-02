using Business.DTO.RequestDTO;
using Business.DTO.ResponseDTO;
using Business.Services;

namespace Business.Controllers
{
    public class TaskController : ITaskController
    {
        private readonly ITaskServices _taskService;

        public TaskController(TaskServices taskServices) 
        {
            _taskService = taskServices;
        }

        public CreateTaskResponseDTO CreateTask(CreateTaskRequestDTO createTaskRequest)
        {
            return _taskService.CreateTask(createTaskRequest);
        }

    }
}
