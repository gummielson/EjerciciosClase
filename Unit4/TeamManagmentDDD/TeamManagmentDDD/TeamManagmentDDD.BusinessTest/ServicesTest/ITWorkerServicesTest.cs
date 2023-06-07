using System.Collections.Generic;
using System;
using Xunit;
using Business.DTO.RequestDTO;
using static Infrastructure.Utils.Enums.Enums;
using Domain.Repositories;
using Moq;
using Domain.Entities;
using Business.Validations;
using Business.Services;
using Business.DTO.ResponseDTO;

namespace TeamManagmentDDD.BusinessTest.ServicesTest
{
    public class ITWorkerServicesTest
    {
        private readonly ValidateDataAnnotations _validateDataAnnotations = new ValidateDataAnnotations();

        private CreateWorkerRequestDTO CreateWorkerRequest(int yearsOfExperience, string name) 
        { 
            return new CreateWorkerRequestDTO
            {
                Name = name,
                Surname = "Doe",
                BirthDate = new DateTime(1990, 1, 1),
                YearsOfExperience = yearsOfExperience,
                Technologies = new List<string> { "C#", "ASP.NET" },
                ITLevel = Level.Senior
            };
        }

        [Fact]
        public void CreateWorker_ReceiveCorrectData_ReturnNoError() 
        {
            // Arrange
            CreateWorkerRequestDTO request = CreateWorkerRequest(6, "John");

            Mock<IITWorkerRepository> workerRepositoryMock = new Mock<IITWorkerRepository>();
            workerRepositoryMock.Setup(repo => repo.CreateWorker(It.IsAny<ITWorker>()));

            IITWorkerRepository workerRepository = workerRepositoryMock.Object;

            ITWorkerServices iTWorkerServices = new ITWorkerServices(workerRepository);

            // Act
            CreateWorkerResponseDTO response = iTWorkerServices.CreateWorker(request);

            // Assert
            Assert.Equal("\nThe worker was loaded properly", response.ResultMessage);
        }

        [Fact]
        public void CreateWorker_ReceiveCorrectData_ReturnError()
        {
            // Arrange
            CreateWorkerRequestDTO request = CreateWorkerRequest(2, "AAA");

            Mock<IITWorkerRepository> workerRepositoryMock = new Mock<IITWorkerRepository>();
            workerRepositoryMock.Setup(repo => repo.CreateWorker(It.IsAny<ITWorker>()));

            IITWorkerRepository workerRepository = workerRepositoryMock.Object;

            ITWorkerServices iTWorkerServices = new ITWorkerServices(workerRepository);

            // Act
            CreateWorkerResponseDTO response = iTWorkerServices.CreateWorker(request);

            // Assert
            Assert.NotEqual("\nThe worker was loaded properly", response.ResultMessage);
        }

        [Fact]
        public void UpdateITWorker_CallsRepositoryToUpdateWorker()
        {
            // Arrange
            var workerRepositoryMock = new Mock<IITWorkerRepository>();
            var worker = new ITWorker();

            var workerServices = new ITWorkerServices(workerRepositoryMock.Object);

            // Act
            workerServices.UpdateITWorker(worker);

            // Assert
            workerRepositoryMock.Verify(repo => repo.UpdateWorker(worker), Times.Once);
        }

    }
}
