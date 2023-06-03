using Business.DTO.RequestDTO;
using Business.DTO.ResponseDTO;

namespace Business.Controllers
{
    public interface IMultiEntityController
    {
        GetTaskByTeamResponseDTO GetTasksByTeam(GetTaskByTeamRequestDTO getTasksByTeamRequestDTO);
    }
}