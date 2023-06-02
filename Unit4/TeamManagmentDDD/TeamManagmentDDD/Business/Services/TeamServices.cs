using System;
using System.Collections.Generic;
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
                _teamRepository.CreateWorker(team);
                response.ResultMessage = "\nThe team was loaded properly";
            }
            catch (Exception ex)
            {
                response.ResultMessage = string.Concat("\nFailed to create the team.\n", ex.Message);
            }

            return response;
        }

        public Team GenerateTeamEntity(CreateTeamRequestDTO request)
        {
            return new Team()
            {
                Name = request.Name,
                Manager = new ITWorker(),
                Technicians = new List<ITWorker>()

            };
        }
    }
}