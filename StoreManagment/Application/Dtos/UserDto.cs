using System.ComponentModel.DataAnnotations;

namespace Application.Dtos
{
    public class UserDto
    {
        [Required(ErrorMessage = "The Lat field is required.")]
        [RegularExpression(@"^[-+]?([1-8]?\d(\.\d+)?|90(\.0+)?)$", ErrorMessage = "Invalid Latitude format.")]
        public string Lat { get; set; } = string.Empty;

        [Required(ErrorMessage = "The Long field is required.")]
        [RegularExpression(@"^[-+]?((1[0-7]|[1-9])?\d(\.\d+)?|180(\.0+)?)$", ErrorMessage = "Invalid Longitude format.")]
        public string Long { get; set; } = string.Empty;

        [Required(ErrorMessage = "The City field is required.")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "The City field can only contain alphabetical characters.")]
        [MaxLength(50, ErrorMessage = "The City field cannot exceed 50 characters.")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "The Street field is required.")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "The Street field can only contain alphabetical characters.")]
        [MaxLength(50, ErrorMessage = "The Title field cannot exceed 50 characters.")]
        public string Street { get; set; } = string.Empty;

        [Required(ErrorMessage = "The Number field is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "The Number field must be greater than or equal to 1.")]
        public int Number { get; set; }

        [Required(ErrorMessage = "The ZipCode field is required.")]
        public string ZipCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "The Email field is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "The Username field is required.")]
        [MaxLength(20, ErrorMessage = "The Username field cannot exceed 20 characters.")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "The Password field is required.")]
        [MaxLength(20, ErrorMessage = "The Password field cannot exceed 20 characters.")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "The FirstName field is required.")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "The FirstName field can only contain alphabetical characters.")]
        [MaxLength(20, ErrorMessage = "The FirstName field cannot exceed 20 characters.")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "The LastName field is required.")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "The LastName field can only contain alphabetical characters.")]
        [MaxLength(20, ErrorMessage = "The LastName field cannot exceed 20 characters.")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "The Phone field is required.")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        public string Phone { get; set; } = string.Empty;
    }
}
