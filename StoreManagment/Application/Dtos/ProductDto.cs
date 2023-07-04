using System.ComponentModel.DataAnnotations;

namespace Application.Dtos
{
    public class ProductDto
    {
        [Required(ErrorMessage = "The title field is required")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "The Title field can only contain alphabetical characters.")]
        [MaxLength(50, ErrorMessage = "The Title field cannot exceed 50 characters.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "The tittle field is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "The Price field must be greater than or equal to 0.01.")]
        public float Price { get; set; }

        [Required(ErrorMessage = "The tittle field is required")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "The Title field can only contain alphabetical characters.")]
        [MaxLength(250, ErrorMessage = "The Description field cannot exceed 250 characters.")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "The tittle field is required")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "The Category field can only contain alphabetical characters.")]
        [MaxLength(40, ErrorMessage = "The Category field cannot exceed 40 characters.")]
        public string Category { get; set; } = string.Empty;

        [Required(ErrorMessage = "The tittle field is required")]
        [Url(ErrorMessage = "The Image field must have a url format.")]
        public string Image { get; set; } = string.Empty;

        [Required(ErrorMessage = "The tittle field is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "The Price field must be greater than or equal to 0.01.")]
        public float Rate { get; set; }

        [Required(ErrorMessage = "The tittle field is required")]
        [Range(1, int.MaxValue, ErrorMessage = "The Count field must be a positive number.")]
        public int Count { get; set; }
    }
}
