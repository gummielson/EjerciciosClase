using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Exercise1.Enums.Enum;

namespace Exercise1.Enterprise
{
    public class ITWorker : Worker
    {
        //public ITWorker(int years, List<string> techs, string level)
        //{
        //    YearsOfExperience = years;
        //    TechKnowledges = techs;

        //    if(level != null)
        //    {
        //        ITLevel = Level.Junior;
        //    }
        //}

        public int YearsOfExperience { get; set; }
        public List<string> TechKnowledges { get; set; } = new List<string>();
        public Level ITLevel { get; set; } = new Level();
    }
}
