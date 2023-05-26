using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Exercise1.Enums.Enum;

namespace Exercise1.Enterprise
{
    public class Task
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Technology { get; set; } = string.Empty;
        public Status TaskStatus { get; set; } = new Status();
    }
}
