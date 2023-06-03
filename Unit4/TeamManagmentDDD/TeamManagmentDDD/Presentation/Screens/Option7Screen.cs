using System;
using Business.Controllers;
using Business.DTO.RequestDTO;

namespace Presentation.Screens
{
    public class Option7Screen
    {
        private readonly ITasksByTeamController _taskByTeamController;

        public Option7Screen(TasksByTeamController tasksByTeamController)
        {
            _taskByTeamController = tasksByTeamController;
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

            Console.WriteLine(_taskByTeamController.GetTasksByTeam(taskDTO).ToString());
        }
    }
}
