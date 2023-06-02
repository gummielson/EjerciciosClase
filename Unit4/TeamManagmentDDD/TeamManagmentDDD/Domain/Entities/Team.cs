using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Team
    {
        public Team()
        {
            Id = count++;
        }

        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public ITWorker Manager { get; set; }

        public List<ITWorker> Technicians { get; set; } = new List<ITWorker>();

        public static int count = 0;
    }
}
