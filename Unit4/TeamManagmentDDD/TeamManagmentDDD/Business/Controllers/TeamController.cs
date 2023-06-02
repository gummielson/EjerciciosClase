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

        public CreateTeamResponseDTO CreateTeam(CreateTeamRequestDTO createTeamRequest)
        {
            return _teamService.CreateTeam(createTeamRequest);
        }
    }
}
