using System;
using System.Collections.Generic;
using System.Linq;
using Business.DTO.RequestDTO;
using Business.DTO.ResponseDTO;
using Business.Validations;
using Domain.Entities;
using Infrastructure.Data.Repositories;

namespace Business.Services
{
    public class TeamServices : ITeamServices
    {
        private readonly ValidateDataAnnotations _validateDataAnnotations;
        private readonly ITeamRepository _teamRepository;

        public TeamServices(TeamRepository teamRepository, ValidateDataAnnotations validateDataAnnotations)
        {
            _validateDataAnnotations = new ValidateDataAnnotations();
            _teamRepository = teamRepository;
        }

        public CreateTeamResponseDTO CreateTeam(CreateTeamRequestDTO request)
        {
            CreateTeamResponseDTO response = new CreateTeamResponseDTO();

            try
            {
                Team team = GenerateTeamEntity(request);
                _validateDataAnnotations.ValidateObject(team);
                _teamRepository.CreateTeam(team);
                response.ResultMessage = "\nThe team was loaded properly";
            }
            catch (Exception ex)
            {
                response.ResultMessage = string.Concat("\nFailed to create the team.\n", ex.Message);
            }

            return response;
        }

        public List<GetTeamsResponseDTO> GetTeams()
        {
            List<GetTeamsResponseDTO> response = new List<GetTeamsResponseDTO>();

            foreach (var team in _teamRepository.GetTeams())
            {
                response.Add(GenerateGetTeamResponse(team));
            }
            return response;
        }

        public GetTeamMembersByTeamResponseDTO GetTeamsMembersByTeam(GetTeamMembersByTeamRequestDTO getTeamMembersByTeamRequestDTO)
        {
            GetTeamMembersByTeamResponseDTO response = new GetTeamMembersByTeamResponseDTO();
            Team team = _teamRepository.GetTeams().Where(team1 => team1.Name.ToLower() == getTeamMembersByTeamRequestDTO.TeamName.ToLower()).FirstOrDefault();

            if (team != null)
            {
                response = GenerateGetTeamMembersResponse(team);
            }
            else
            {
                response.Error = true;
                response.ErrorMessage = "The entered team doesn't exists";
            }

            return response;
        }

        public List<ITWorker> GetITWorkersByTeam(GetTaskByTeamRequestDTO request)
        {
            Team team = _teamRepository.GetTeams().Where(team1 => team1.Name.ToLower() == request.TeamName.ToLower()).FirstOrDefault();

            return team != null ? team.Technicians : null;
        }

        private Team GenerateTeamEntity(CreateTeamRequestDTO request)
        {
            return new Team()
            {
                Name = request.Name,
                Manager = new ITWorker(),
                Technicians = new List<ITWorker>()
            };
        }

        private GetTeamsResponseDTO GenerateGetTeamResponse(Team team)
        {
            return new GetTeamsResponseDTO()
            {
                IdTeam = team.Id,
                NameTeam = team.Name
            };
        }

        private GetTeamMembersByTeamResponseDTO GenerateGetTeamMembersResponse(Team team)
        {
            return new GetTeamMembersByTeamResponseDTO()
            {
                Manager = team.Manager == null ? "This team has no manager assigned yet" : $"{team.Manager.Name} {team.Manager.Surname}",
                TeamMembers = team.Technicians != null ? team.Technicians.Select(worker => $"{worker.Name} {worker.Surname}").ToList() : new List<string>(),
                Error = false
            };
        }
    }
}