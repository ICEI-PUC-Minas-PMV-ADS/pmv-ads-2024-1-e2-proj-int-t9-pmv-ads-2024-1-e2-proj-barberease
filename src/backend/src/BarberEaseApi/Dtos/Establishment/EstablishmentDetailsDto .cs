using BarberEaseApi.Dtos.EstablishmentPeriod;
using BarberEaseApi.Dtos.EstablishmentService;

namespace BarberEaseApi.Dtos.Establishment
{
    public class EstablishmentDetailsDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }
        public string OwnerFirstName { get; set; }
        public string OwnerLastName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Cep { get; set; }
        public string Address { get; set; }
        public string? Phone { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public IEnumerable<EstablishmentServiceDto> EstablishmentServices { get; set; }
        public IEnumerable<EstablishmentPeriodDto> EstablishmentPeriods { get; set; }
    }
}
