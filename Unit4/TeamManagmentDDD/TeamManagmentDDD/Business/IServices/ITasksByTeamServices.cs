using Business.DTO.RequestDTO;
using Business.DTO.ResponseDTO;

namespace Business.Services
{
    public interface ITasksByTeamServices
    {
        GetTaskByTeamResponseDTO GetTasksByTeam(GetTaskByTeamRequestDTO getTasksByTeamRequestDTO);
    }
}