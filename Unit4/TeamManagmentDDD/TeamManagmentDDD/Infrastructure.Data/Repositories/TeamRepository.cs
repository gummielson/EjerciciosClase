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

        public void CreateTeam(Team team)
        {
            teams.Add(team);
        }

        public List<Team> GetTeams() 
        {
            return teams;
        }

        public Team GetTeamById(int id) 
        {
            int index = teams.FindIndex(worker => worker.Id == id);

            return index != -1 ? teams[index] : null;
        }

        public void UpdateTeam(Team teamEntry) 
        {
            int index = teams.FindIndex(worker => worker.Id == teamEntry.Id);

            if (index != -1)
            {
                teams[index] = teamEntry;
            }
        }

        private void CreatingMockTeamData()
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
