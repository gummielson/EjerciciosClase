using System.Collections.Generic;
using Business.DTO.RequestDTO;
using Business.DTO.ResponseDTO;
using Domain.Entities;

namespace Business.Services
{
    public interface IITWorkerServices
    {
        CreateWorkerResponseDTO CreateWorker(CreateWorkerRequestDTO request);
        void UpdateITWorker(ITWorker worker);
        void GetAvailableWorkers(List<int> idWorkers);
        ITWorker GetITWorkerById(int id);
    }
}