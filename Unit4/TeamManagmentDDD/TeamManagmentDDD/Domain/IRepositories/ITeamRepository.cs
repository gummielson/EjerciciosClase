using System.Collections.Generic;
using Domain.Entities;

namespace Infrastructure.Data.Repositories
{
    public interface ITeamRepository
    {
        void CreateWorker(Team team);
        List<Team> GetTeams();
        void CreatingMockTeamData();
    }
}