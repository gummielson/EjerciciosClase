using System.Collections.Generic;
using Business.DTO.RequestDTO;
using Business.DTO.ResponseDTO;

namespace Business.Controllers
{
    public interface IITWorkerController
    {
        CreateWorkerResponseDTO CreateWorker(CreateWorkerRequestDTO createWorkerRequest);
        List<GetWorkersResponseDTO> GetWorkers();
    }
}