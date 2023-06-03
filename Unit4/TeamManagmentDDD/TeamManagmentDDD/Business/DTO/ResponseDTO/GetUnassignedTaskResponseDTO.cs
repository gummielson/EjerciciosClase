using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO.ResponseDTO
{
    public class GetUnassignedTaskResponseDTO
    {
        public List<int> idsTasks { get; set; } = new List<int>();
        public List<string> unassignedTaskDesc { get; set; } = new List<string>();

        public override string ToString()
        {
            string idsTasksString = idsTasks.Any() ? string.Join(",\n", idsTasks) : "There is no unassigned tasks";
            string unassignedTaskDescString = unassignedTaskDesc.Any() ? string.Join(",\n", unassignedTaskDesc) : "There is no unassigned tasks";

            return $"Ids Tasks: {idsTasksString}\n\nUnassigned task description: {unassignedTaskDescString}";
        }
    }
}
