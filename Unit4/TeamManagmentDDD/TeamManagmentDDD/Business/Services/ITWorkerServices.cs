using System;
using System.Collections.Generic;
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
        private readonly IITWorkerRepository _iTWorkerRepository;

        public ITWorkerServices(ITWorkerRepository iTWorkerRepositoriy) //ValidateDataAnnotations validateDataAnnotations, ) 
        {
            _validateDataAnnotations = new ValidateDataAnnotations();
            _iTWorkerRepository = iTWorkerRepositoriy;
        }

        public CreateWorkerResponseDTO CreateWorker(CreateWorkerRequestDTO request)
        {
            CreateWorkerResponseDTO response = new CreateWorkerResponseDTO();

            try
            {
                ITWorker worker = GenerateITWorkerEntity(request);
                _validateDataAnnotations.ValidateObject(worker);
                worker.CanBeSenior();
                _iTWorkerRepository.CreateWorker(worker);
                response.ResultMessage = "\nThe worker was loaded properly";
            }
            catch (Exception ex)
            {
                response.ResultMessage = string.Concat("\nFailed to create the worker.\n", ex.Message);
            }

            return response;
        }

        public void UpdateITWorker(ITWorker worker) 
        {
            _iTWorkerRepository.UpdateWorker(worker);
        }

        public void GetAvailableWorkers(List<int> idWorkers)
        {
            _iTWorkerRepository.GetAvailableWorkers(idWorkers);
        }

        public ITWorker GetITWorkerById(int id)
        {
            return _iTWorkerRepository.GetITWorkerById(id);
        }

        private ITWorker GenerateITWorkerEntity(CreateWorkerRequestDTO request)
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
