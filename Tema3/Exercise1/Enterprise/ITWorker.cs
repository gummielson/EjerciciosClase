using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Exercise1.Enums.Enum;

namespace Exercise1.Enterprise
{
    public class ITWorker
    {
        public int YearsOfExperience { get; set; }
        public string TechKnowledges { get; set; } = string.Empty;
        public Level ITLevel { get; set; } = new Level();
    }
}
