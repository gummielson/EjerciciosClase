using System.Collections.Generic;
using System.Linq;

namespace Business.DTO.ResponseDTO
{
    public class GetTeamMembersByTeamResponseDTO
    {
        public string ErrorMessage { get; set; } = string.Empty;
        public bool Error { get; set; }
        public string Manager { get; set; } = string.Empty;
        public List<string> TeamMembers { get; set; } = new List<string>();

        public override string ToString()
        {
            return $"Team manager: {Manager} \nTeam members: {(TeamMembers.Any() ? string.Join("\n", TeamMembers) : "No team members")}";
        }
    }
}
