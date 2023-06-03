using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO.RequestDTO
{
    public class AssignITWorkerToTeamRequestDTO
    {
        public int IdWorker { get; set; }
        public int IdTeam { get; set; }
        public bool Manager { get; set; } = false;
    }
}
