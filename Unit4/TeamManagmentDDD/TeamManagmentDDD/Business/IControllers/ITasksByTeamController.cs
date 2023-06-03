using Business.DTO.RequestDTO;
using Business.DTO.ResponseDTO;

namespace Business.Controllers
{
    public interface ITasksByTeamController
    {
        GetTaskByTeamResponseDTO GetTasksByTeam(GetTaskByTeamRequestDTO getTasksByTeamRequestDTO);
    }
}