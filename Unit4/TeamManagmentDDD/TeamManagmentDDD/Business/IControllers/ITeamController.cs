using System.Collections.Generic;
using Business.DTO.RequestDTO;
using Business.DTO.ResponseDTO;

namespace Business.Controllers
{
    public interface ITeamController
    {
        CreateTeamResponseDTO CreateTeam(CreateTeamRequestDTO createTeamRequest);

        List<GetTeamsResponseDTO> GetTeams();

        GetTeamMembersByTeamResponseDTO GetTeamMembersByTeam(GetTeamMembersByTeamRequestDTO getTeamMembersByTeamRequestDTO);

    }
}