using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1.Enterprise
{
    public class Worker
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; } = new DateTime();
        public DateTime LeavingDate { get; set; } = new DateTime();
        public static int Count { get; set; }
    }
} 
