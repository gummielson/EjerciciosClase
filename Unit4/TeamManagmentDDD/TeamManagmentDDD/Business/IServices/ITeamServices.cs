﻿using System.Collections.Generic;
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
        List<ITWorker> GetITWorkersByTeam(GetTaskByTeamRequestDTO request);
        void UpdateTeam(Team team);
        Team GetTeamById(int id);
        void AssignITWorkerToTeam(AssignITWorkerToTeamRequestDTO assignITWorkerToTeamRequestDTO);
    }
}