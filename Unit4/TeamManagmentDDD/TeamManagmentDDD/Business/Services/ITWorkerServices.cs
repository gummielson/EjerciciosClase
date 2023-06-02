using System;
using Business.DTO.RequestDTO;
using Business.DTO.ResponseDTO;
using Business.Validations;
using Domain.Entities;
using Domain.Repositories;

namespace Business.Services
{
    public class ITWorkerServices : IITWorkerServices
    {
        private readonly ValidateDataAnnotations _validateDataAnnotations;
        private readonly IITWorkerRepository _teamManagmentRepositoriy;

        public ITWorkerServices(ITWorkerRepository iTWorkerRepositoriy) //ValidateDataAnnotations validateDataAnnotations, ) 
        {
            _validateDataAnnotations = new ValidateDataAnnotations();
            _teamManagmentRepositoriy = iTWorkerRepositoriy;
        }

        public CreateWorkerResponseDTO CreateWorker(CreateWorkerRequestDTO request)
        {
            CreateWorkerResponseDTO response = new CreateWorkerResponseDTO();

            try
            {
                ITWorker worker = GenerateITWorkerEntity(request);
                _validateDataAnnotations.ValidateObject(worker);
                worker.CanBeSenior();
                _teamManagmentRepositoriy.CreateWorker(worker);
                response.ResultMessage = "\nThe worker was loaded properly";
            }
            catch (Exception ex)
            {
                response.ResultMessage = string.Concat("\nFailed to create the worker.\n", ex.Message);
            }

            return response;
        }

        public ITWorker GenerateITWorkerEntity(CreateWorkerRequestDTO request)
        {
            return new ITWorker()
            {
                Name = request.Name,
                Surname = request.Surname,
                BirthDate = request.BirthDate,
                YearsOfExperience = request.YearsOfExperience,
                TechKnowledges = request.Technologies,
                ITLevel = request.ITLevel
            };
        }
    }
}
