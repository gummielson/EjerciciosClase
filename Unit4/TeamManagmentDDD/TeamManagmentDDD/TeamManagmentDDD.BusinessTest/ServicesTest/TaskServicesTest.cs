using Business.DTO.RequestDTO;
using Business.DTO.ResponseDTO;
using Business.Services;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data.Repositories;
using Moq;
using Xunit;

namespace TeamManagmentDDD.BusinessTest.ServicesTest
{
    public class TaskServicesTest
    {
        [Fact]
        public void CreateTask_ReceiveCorrectData_ReturnNoError()
        {
            // Arrange
            CreateTaskRequestDTO request = new CreateTaskRequestDTO
            {
                Description = "description",
                Technology = "C#"
            };

            Mock<ITaskRepository> taskRepositoryMock = new Mock<ITaskRepository>();
            taskRepositoryMock.Setup(repo => repo.CreateTask(It.IsAny<TaskEntity>()));

            ITaskRepository taskRepository = taskRepositoryMock.Object;

            TaskServices taskServices = new TaskServices(taskRepository);

            // Act
            CreateTaskResponseDTO response = taskServices.CreateTask(request);

            // Assert
            Assert.Equal("\nThe task was loaded properly", response.ResultMessage);
        }
    }
}
