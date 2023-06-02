using System;
using System.ComponentModel.DataAnnotations;
using static Infrastructure.Utils.Enums.Enums;

namespace Domain.Entities
{
    public class TaskEntity
    {
        public TaskEntity()
        {
            Id = count++;
        }

        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string Technology { get; set; } = string.Empty;

        public Status TaskStatus { get; set; } = Status.ToDo;

        public int IdWorker { get; set; }

        public static int count = 0;
    }
}
