using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1.Enterprise
{
    public class Team
    {
        [Key]
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string Name { get; set; } = string.Empty;

        public ITWorker Manager { get; set; }

        public List<ITWorker> Technicians { get; set; } = new List<ITWorker>();
    }
}
