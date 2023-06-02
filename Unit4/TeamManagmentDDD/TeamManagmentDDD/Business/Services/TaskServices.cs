using System;
using Business.DTO.RequestDTO;
using Business.DTO.ResponseDTO;
using Business.Validations;
using Domain.Entities;
using Infrastructure.Data.Repositories;

namespace Business.Services
{
    public class TaskServices : ITaskServices
    {
        private readonly ValidateDataAnnotations _validateDataAnnotations;
        private readonly ITaskRepository _taskRepositoriy;

        public TaskServices(TaskRepository taskRepository)//, ValidateDataAnnotations validateDataAnnotations) 
        {
            _validateDataAnnotations = new ValidateDataAnnotations();
            _taskRepositoriy = taskRepository;
        }

        public CreateTaskResponseDTO CreateTask(CreateTaskRequestDTO request)
        {
            CreateTaskResponseDTO response = new CreateTaskResponseDTO();

            try
            {
                TaskEntity task = GenerateTaskEntity(request);
                _validateDataAnnotations.ValidateObject(task);
                _taskRepositoriy.CreateTask(task);
                response.ResultMessage = "\nThe task was loaded properly";
            }
            catch (Exception ex)
            {
                response.ResultMessage = string.Concat("\nFailed to create the task.\n", ex.Message);
            }

            return response;
        }

        public TaskEntity GenerateTaskEntity(CreateTaskRequestDTO request)
        {
            return new TaskEntity()
            {
                Description = request.Description,
                Technology = request.Technology
            };
        }
    }
}
