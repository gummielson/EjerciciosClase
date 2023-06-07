using System;
using Business.Controllers;
using Business.DTO.RequestDTO;

namespace Presentation.Screens
{
    public class Option7Screen
    {
        private readonly IMultiEntityController _multiEntityController;

        public Option7Screen(MultiEntityController multiEntityController)
        {
            _multiEntityController = multiEntityController;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Start()
        {
            GetTasksByTeam(GetTeam());
        }

        private string GetTeam()
        {
            Console.WriteLine("Enter a team name: ");
            return Console.ReadLine();
        }

        private void GetTasksByTeam(string team)
        {
            GetTaskByTeamRequestDTO taskDTO = new GetTaskByTeamRequestDTO();
            taskDTO.TeamName = team;

            Console.WriteLine(_multiEntityController.GetTasksByTeam(taskDTO).ToString());
        }
    }
}
