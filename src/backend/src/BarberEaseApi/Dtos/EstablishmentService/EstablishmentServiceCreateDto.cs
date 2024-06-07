using System.ComponentModel.DataAnnotations;

namespace BarberEaseApi.Dtos.EstablishmentService
{
    public class EstablishmentServiceCreateDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name must have {1} chars")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Category is required")]
        [StringLength(20, ErrorMessage = "Category must have {1} chars")]
        public string Category { get; set; }

        [StringLength(255, ErrorMessage = "Description must have {1} chars")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

        [Required(ErrorMessage = "EstablishmentId is required")]
        public Guid EstablishmentId { get; set; }
    }
}
