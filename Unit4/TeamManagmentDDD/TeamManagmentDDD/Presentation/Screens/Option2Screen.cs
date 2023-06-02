using System;
using Business.Controllers;
using Business.DTO.RequestDTO;

namespace Presentation.Screens
{
    public class Option2Screen
    {
        private readonly ITeamController _teamController;

        public Option2Screen(TeamController teamController)
        {
            _teamController = teamController;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Start()
        {

            CreateTeamRequestDTO teamRequest = new CreateTeamRequestDTO()
            {
                Name = GetName()
            };

            Console.WriteLine(_teamController.CreateTeam(teamRequest).ResultMessage);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetName()
        {
            Console.WriteLine("Enter the team name:");
            return Console.ReadLine();
        }
    }
}
