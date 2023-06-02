using Business.DTO.RequestDTO;
using Business.DTO.ResponseDTO;

namespace Business.Controllers
{
    public interface IITWorkerController
    {
        CreateWorkerResponseDTO CreateWorker(CreateWorkerRequestDTO createWorkerRequest);
    }
}