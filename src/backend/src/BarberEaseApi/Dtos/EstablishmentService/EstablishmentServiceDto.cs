namespace BarberEaseApi.Dtos.EstablishmentService
{
    public class EstablishmentServiceDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public Guid EstablishmentId { get; set; }
    }
}
