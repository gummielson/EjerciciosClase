using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTO.RequestDTO;
using Business.DTO.ResponseDTO;
using Business.Services;

namespace Business.Controllers
{
    public class MultiEntityController : IMultiEntityController
    {
        private readonly IMultiEntityServices _multiEntityServices;

        public MultiEntityController(MultiEntityServices tasksByTeamServices)
        {
            _multiEntityServices = tasksByTeamServices;
        }

        //GET
        public GetTaskByTeamResponseDTO GetTasksByTeam(GetTaskByTeamRequestDTO getTasksByTeamRequestDTO)
        {
            return _multiEntityServices.GetTasksByTeam(getTasksByTeamRequestDTO);
        }

        //PUT
        public void AssignITWorkerToTeam(AssignITWorkerToTeamRequestDTO assignITWorkerToTeamRequestDTO)
        {
            _multiEntityServices.AssignITWorkerToTeam(assignITWorkerToTeamRequestDTO);
        }
    }
}
