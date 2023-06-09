using System;
using System.ComponentModel.DataAnnotations;
using Domain.Attributes;

namespace Domain.Entities
{
    public class Worker
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Name only can have 50 characters")]
        [RegularExpression(@"^[^0-9]*$", ErrorMessage = "Name can't contain numeric chars.")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(50, ErrorMessage = "Surname only can have 50 characters")]
        [RegularExpression(@"^[^0-9]*$", ErrorMessage = "Surname can't contain numeric chars.")]
        public string Surname { get; set; } = string.Empty;

        [Required]
        [AdultAge(ErrorMessage = "The entered birthdate does not correspond to someone of legal age")]
        public DateTime BirthDate { get; set; } = new DateTime();

        public DateTime? LeavingDate { get; set; } = new DateTime();

    }
}
