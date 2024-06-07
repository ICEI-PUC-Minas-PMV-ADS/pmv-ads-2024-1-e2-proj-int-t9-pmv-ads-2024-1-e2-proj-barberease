using BarberEaseApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BarberEaseApi.Mappings
{
    public class EstablishmentPeriodMap : IEntityTypeConfiguration<EstablishmentPeriodEntity>
    {
        public void Configure(EntityTypeBuilder<EstablishmentPeriodEntity> builder)
        {
            builder.ToTable("establishment_periods");

            builder.HasKey((establishmentPeriod) => establishmentPeriod.Id);

            builder.HasOne((establishmentPeriod) => establishmentPeriod.Establishment)
                .WithMany((establishment) => establishment.EstablishmentPeriods);

            builder.Property((establishmentPeriod) => establishmentPeriod.Id)
                .HasColumnName("id");
            builder.Property((establishmentPeriod) => establishmentPeriod.DayOfWeek)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("day_of_week");
            builder.Property((establishmentPeriod) => establishmentPeriod.OpeningTime)
                .HasMaxLength(8)
                .HasColumnName("opening_time");
            builder.Property((establishmentPeriod) => establishmentPeriod.ClosingTime)
                .HasMaxLength(8)
                .HasColumnName("closing_time");
            builder.Property((establishmentPeriod) => establishmentPeriod.TimeBetweenService)
                .HasMaxLength(8)
                .HasColumnName("time_between_service");
            builder.Property((establishmentPeriod) => establishmentPeriod.IsClosed)
                .IsRequired()
                .HasColumnName("is_closed");
            builder.Property((establishmentPeriod) => establishmentPeriod.EstablishmentId)
                .IsRequired()
                .HasColumnName("establishment_id");
            builder.Property((establishmentPeriod) => establishmentPeriod.CreatedAt)
                .IsRequired()
                .HasColumnName("created_at");
            builder.Property((establishmentPeriod) => establishmentPeriod.UpdatedAt)
                .IsRequired()
                .HasColumnName("updated_at");
        }
    }
}
