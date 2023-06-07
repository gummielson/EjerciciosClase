using System;
using System.Collections.Generic;
using System.Linq;
using Business.DTO.RequestDTO;
using Business.DTO.ResponseDTO;
using Business.Validations;
using Domain.Entities;
using Infrastructure.Data.Repositories;
using static Infrastructure.Utils.Enums.Enums;

namespace Business.Services
{
    public class TeamServices : ITeamServices
    {
        private readonly ValidateDataAnnotations _validateDataAnnotations;
        private readonly ITeamRepository _teamRepository;
        private readonly IITWorkerServices _workerServices;

        public TeamServices(ITeamRepository teamRepository, ValidateDataAnnotations validateDataAnnotations, IITWorkerServices workerServices)
        {
            _validateDataAnnotations = new ValidateDataAnnotations();
            _teamRepository = teamRepository;
            _workerServices = workerServices;
        }

        public CreateTeamResponseDTO CreateTeam(CreateTeamRequestDTO request)
        {
            CreateTeamResponseDTO response = new CreateTeamResponseDTO();

            try
            {
                Team team = GenerateTeamEntity(request);
                _validateDataAnnotations.ValidateObject(team);
                ValidateIfTeamExists(_teamRepository.GetTeams(), team);
                _teamRepository.CreateTeam(team);
                response.ResultMessage = "\nThe team was loaded properly";
            }
            catch (Exception ex)
            {
                response.ResultMessage = $"\nFailed to create the worker.\n {ex.Message}";
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

        public void UpdateTeam(Team team)
        {
            _teamRepository.UpdateTeam(team);
        }

        public Team GetTeamById(int id) 
        {
            return _teamRepository.GetTeamById(id);
        }

        public void AssignITWorkerToTeam(AssignITWorkerToTeamRequestDTO assignITWorkerToTeamRequestDTO)
        {
            ITWorker worker = _workerServices.GetITWorkerById(assignITWorkerToTeamRequestDTO.IdWorker);
            Team team = GetTeamById(assignITWorkerToTeamRequestDTO.IdTeam);

            if (assignITWorkerToTeamRequestDTO.Manager)
            {
                //ValidateAssignment(team);
                AssignManagerToTeam(worker, team);
            }
            else
            {
                team.AddTechnician(worker);
            }

            UpdateTeam(team);
        }

        private void ValidateAssignment(ITWorker worker, Team team)
        {
            worker.CanBeManager();
            team.HasAManager();
        }

        private void AssignManagerToTeam(ITWorker worker, Team team)
        {
            worker.ChangeRol(Rol.Manager);
            team.Manager = worker;
            _workerServices.UpdateITWorker(worker);
        }

        #region private methods
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

        private void ValidateIfTeamExists(List<Team> teamList, Team team)
        {
            if(teamList.Where(team1 => team1.Name == team.Name).Any()) 
            {
                throw new Exception("The name of the entered team is already used.");
            }
        }
        #endregion
    }
}