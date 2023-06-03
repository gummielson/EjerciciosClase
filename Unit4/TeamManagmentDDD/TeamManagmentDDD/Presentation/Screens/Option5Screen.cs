using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Controllers;
using Business.DTO.RequestDTO;
using Business.DTO.ResponseDTO;

namespace Presentation.Screens
{
    public class Option5Screen
    {
        private readonly ITeamController _teamController;

        public Option5Screen(TeamController teamController)
        {
            _teamController = teamController;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Start()
        {
            GetTeamMembersByTeamRequestDTO getTeamMembersByTeamRequestDTO = new GetTeamMembersByTeamRequestDTO()
            {
                TeamName = GetTeamName()
            };

            GetTeamMembersByTeamResponseDTO getTeamMembersByTeamResponseDTO = GetTeamsMembersByTeam(getTeamMembersByTeamRequestDTO);

            if (getTeamMembersByTeamResponseDTO.Error)
            {
                Console.WriteLine(getTeamMembersByTeamResponseDTO.ErrorMessage);
            }
            else
            {
                Console.WriteLine(getTeamMembersByTeamResponseDTO.ToString());
            };
        }

        public string GetTeamName()
        {
            Console.WriteLine("Enter the name of the team: ");
            return Console.ReadLine();
        }

        public GetTeamMembersByTeamResponseDTO GetTeamsMembersByTeam(GetTeamMembersByTeamRequestDTO getTeamMembersByTeamRequestDTO)
        {
            return _teamController.GetTeamMembersByTeam(getTeamMembersByTeamRequestDTO);
        }
    }
}
