namespace BarberEaseApi.Dtos.EstablishmentPeriod
{
    public class EstablishmentPeriodDto
    {
        public Guid Id { get; set; }
        public string DayOfWeek { get; set; }
        public string? OpeningTime { get; set; }
        public string? ClosingTime { get; set; }
        public string? TimeBetweenService { get; set; }
        public bool IsClosed { get; set; }
        public Guid EstablishmentId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
