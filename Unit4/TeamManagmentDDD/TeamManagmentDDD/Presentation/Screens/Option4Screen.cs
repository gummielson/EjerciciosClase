using System;
using Business.Controllers;
using Business.DTO.RequestDTO;

namespace Presentation.Screens
{
    public class Option4Screen
    {
        private readonly ITeamController _teamController;

        public Option4Screen(TeamController teamController)
        {
            _teamController = teamController;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Start()
        {
            GetTeams();
        }

        public void GetTeams()
        {
            foreach (var team in _teamController.GetTeams())
            {
                Console.WriteLine(team.ToString());
            };
        }
    }
}
