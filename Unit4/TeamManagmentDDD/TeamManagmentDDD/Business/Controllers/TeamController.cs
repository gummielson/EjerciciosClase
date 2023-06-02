using System.Collections.Generic;
using Business.DTO.RequestDTO;
using Business.DTO.ResponseDTO;
using Business.Services;

namespace Business.Controllers
{
    public class TeamController : ITeamController
    {
        private readonly ITeamServices _teamService;

        public TeamController(TeamServices teamServices)
        {
            _teamService = teamServices;
        }

        //POST
        public CreateTeamResponseDTO CreateTeam(CreateTeamRequestDTO createTeamRequest)
        {
            return _teamService.CreateTeam(createTeamRequest);
        }

        //GET
        public List<GetTeamsResponseDTO> GetTeams()
        {
            return _teamService.GetTeams();
        }

        //GET
        public GetTeamMembersByTeamResponseDTO GetTeamMembersByTeam(GetTeamMembersByTeamRequestDTO getTeamMembersByTeamRequestDTO)
        {
            return _teamService.GetTeamsMembersByTeam(getTeamMembersByTeamRequestDTO);
        }
    }
}
