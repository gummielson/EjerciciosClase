using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiuser3.Models
{
    public class User
    {
        [Key]
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string AccountNumber { get; set; } = string.Empty;

        [Required]
        public int Pin { get; set; }

        public decimal Balance { get; set; } = 0;

        public List<decimal> Movements { get; set; } = new List<decimal>();
    }
}
