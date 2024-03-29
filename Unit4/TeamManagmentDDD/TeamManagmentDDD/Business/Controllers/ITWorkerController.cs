﻿using System.Collections.Generic;
using Business.DTO.RequestDTO;
using Business.DTO.ResponseDTO;
using Business.Services;

namespace Business.Controllers
{
    public class ITWorkerController : IITWorkerController
    {
        private readonly IITWorkerServices _iTWorkerService;

        public ITWorkerController(ITWorkerServices iTWorkerServices) 
        {
            _iTWorkerService = iTWorkerServices;
        }

        //POST
        public CreateWorkerResponseDTO CreateWorker(CreateWorkerRequestDTO createWorkerRequest)
        {
            return _iTWorkerService.CreateWorker(createWorkerRequest);
        }

        //GET
        public List<GetWorkersResponseDTO> GetWorkers(int id)
        {
            return _iTWorkerService.GetWorkers();
        }

    }
}
