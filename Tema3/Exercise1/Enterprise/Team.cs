using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1.Enterprise
{
    public class Team
    {
        public string Manager { get; set; } = string.Empty;
        public List<string> Technicians { get; set; } = new List<string>();
    }
}
