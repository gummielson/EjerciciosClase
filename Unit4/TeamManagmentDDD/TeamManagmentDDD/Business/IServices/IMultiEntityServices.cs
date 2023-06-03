using Business.DTO.RequestDTO;
using Business.DTO.ResponseDTO;

namespace Business.Services
{
    public interface IMultiEntityServices
    {
        GetTaskByTeamResponseDTO GetTasksByTeam(GetTaskByTeamRequestDTO getTasksByTeamRequestDTO);
        void AssignITWorkerToTeam(AssignITWorkerToTeamRequestDTO assignITWorkerToTeamRequestDTO);
    }
}