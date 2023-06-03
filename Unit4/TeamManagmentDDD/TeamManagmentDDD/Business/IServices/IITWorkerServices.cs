using Business.DTO.RequestDTO;
using Business.DTO.ResponseDTO;
using Domain.Entities;

namespace Business.Services
{
    public interface IITWorkerServices
    {
        CreateWorkerResponseDTO CreateWorker(CreateWorkerRequestDTO request);
    }
}