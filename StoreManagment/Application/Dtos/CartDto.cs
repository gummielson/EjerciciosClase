using System.ComponentModel.DataAnnotations;

namespace Application.Dtos
{
    public class CartDto
    {
        [Required(ErrorMessage = "The IdUser field is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "The IdUser field must be greater than or equal to 1.")]
        public int IdUser { get; set; }
    }
}
