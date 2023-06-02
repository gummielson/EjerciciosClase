using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infrastructure.Data.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        public List<Team> teams = new List<Team>();

        public TeamRepository()
        {
            CreatingMockTeamData();
        }

        public void CreateWorker(Team team)
        {
            teams.Add(team);
        }

        public List<Team> GetTeams() 
        {
            return teams;
        }

        public void CreatingMockTeamData()
        {
            teams = new List<Team>()
            {
                new Team()
                {
                    Name = "Team1"
                },

                new Team()
                {
                    Name = "Team2"
                },

                new Team()
                {
                    Name = "Team3"
                },

                new Team()
                {
                    Name = "Team4"
                }
            };
        }
    }
}
