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
    public class TasksByTeamController : ITasksByTeamController
    {
        private readonly ITasksByTeamServices _tasksByTeamServices;

        public TasksByTeamController(TasksByTeamServices tasksByTeamServices)
        {
            _tasksByTeamServices = tasksByTeamServices;
        }

        //GET
        public GetTaskByTeamResponseDTO GetTasksByTeam(GetTaskByTeamRequestDTO getTasksByTeamRequestDTO)
        {
            return _tasksByTeamServices.GetTasksByTeam(getTasksByTeamRequestDTO);
        }
    }
}
