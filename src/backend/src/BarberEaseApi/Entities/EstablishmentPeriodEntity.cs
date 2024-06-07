namespace BarberEaseApi.Entities
{
    public class EstablishmentPeriodEntity : BaseEntity
    {
        public string DayOfWeek { get; set; }
        public string? OpeningTime { get; set; }
        public string? ClosingTime { get; set; }
        public string? TimeBetweenService { get; set; }
        public bool IsClosed { get; set; }
        public Guid EstablishmentId { get; set; }

        public EstablishmentEntity Establishment { get; set; }
    }
}
