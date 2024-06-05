namespace BarberEaseApi.Entities
{
    public class EstablishmentBusinessHours : BaseEntity
    {
        public string DayOfWeek { get; set; }
        public TimeOnly OpeningTime { get; set; }
        public TimeOnly ClosingTime { get; set; }
        public TimeOnly TimeBetweenService { get; set; }
        public Guid EstablishmentId { get; set; }

        public EstablishmentEntity Establishment { get; set; }
    }
}
