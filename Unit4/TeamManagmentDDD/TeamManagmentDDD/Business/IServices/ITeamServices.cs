using Business.DTO.RequestDTO;
using Business.DTO.ResponseDTO;
using Domain.Entities;

namespace Business.Services
{
    public interface ITeamServices
    {
        CreateTeamResponseDTO CreateTeam(CreateTeamRequestDTO request);
        Team GenerateTeamEntity(CreateTeamRequestDTO request);
    }
}