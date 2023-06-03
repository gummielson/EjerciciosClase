using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO.ResponseDTO
{
    public class GetTaskByTeamResponseDTO
    {
        public List<int> IdITWorkers { get; set; } = new List<int>();
        public List<string> NamesITWorkers { get; set; } = new List<string>();
        public List<int> IdTasks { get; set; } = new List<int>();
        public List<string> DescTasks { get; set; } = new List<string>();

        public override string ToString()
        {
            string result = string.Empty;

            if (IdITWorkers.Any())
            {
                for (int i = 0; i < IdITWorkers.Count; i++)
                {
                    result += $"Id worker: {IdITWorkers[i]}, Name : {NamesITWorkers[i]}, Id task: {IdTasks[i]}, Task description: {DescTasks[i]}\n";
                }
            }
            else
            {
                result = "\nThere is no data for selected team.";
            }

            return result;
        }

    }
}
