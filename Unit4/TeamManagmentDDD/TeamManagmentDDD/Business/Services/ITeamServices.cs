using System.Collections.Generic;
using Business.DTO.RequestDTO;
using Business.DTO.ResponseDTO;
using Domain.Entities;

namespace Business.Services
{
    public interface ITeamServices
    {
        CreateTeamResponseDTO CreateTeam(CreateTeamRequestDTO request);
        List<GetTeamsResponseDTO> GetTeams();
        GetTeamMembersByTeamResponseDTO GetTeamsMembersByTeam(GetTeamMembersByTeamRequestDTO getTeamMembersByTeamRequestDTO);
    }
}