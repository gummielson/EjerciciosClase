using System;
using System.ComponentModel.DataAnnotations;
using static Exercise1.Enums.Enum;

namespace Exercise1.Enterprise
{
    public class Task
    {
        [Key]
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Description { get; set; } = string.Empty;

        public string Technology { get; set; } = string.Empty;

        public Status TaskStatus { get; set; } = Status.ToDo;

        public int IdWorker { get; set; }
    }
}
