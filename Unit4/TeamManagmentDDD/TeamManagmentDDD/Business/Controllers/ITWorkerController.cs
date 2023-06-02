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

        public CreateWorkerResponseDTO CreateWorker(CreateWorkerRequestDTO createWorkerRequest)
        {
            return _iTWorkerService.CreateWorker(createWorkerRequest);
        }

    }
}
