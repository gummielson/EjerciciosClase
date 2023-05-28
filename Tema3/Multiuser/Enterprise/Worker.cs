using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1.Enterprise
{
    public class Worker
    {
        [Required]
        [Key]
        public int Id { get; set; } 

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Surname { get; set; } = string.Empty;

        [Required]
        public DateTime BirthDate { get; set; } = new DateTime();

        [Required]
        public DateTime LeavingDate { get; set; } = new DateTime();

        public static int Count { get; set; } 
    }
} 
