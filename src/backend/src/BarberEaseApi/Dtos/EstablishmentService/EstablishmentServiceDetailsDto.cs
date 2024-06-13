using BarberEaseApi.Dtos.Establishment;

namespace BarberEaseApi.Dtos.EstablishmentService
{
    public class EstablishmentServiceDetailsDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public EstablishmentDto Establishment { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
