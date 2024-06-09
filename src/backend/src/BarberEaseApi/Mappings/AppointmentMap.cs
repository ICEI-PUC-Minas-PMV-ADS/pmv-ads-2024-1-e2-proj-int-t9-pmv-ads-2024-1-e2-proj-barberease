using BarberEaseApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BarberEaseApi.Mappings
{
    public class AppointmentMap : IEntityTypeConfiguration<AppointmentEntity>
    {
        public void Configure(EntityTypeBuilder<AppointmentEntity> builder)
        {
            builder.ToTable("appointments");

            builder.HasKey((appointment) => appointment.Id);

            builder.HasOne((appointment) => appointment.EstablishmentService)
                .WithMany((establishmentService) => establishmentService.Appointments);
            builder.HasOne((appointment) => appointment.Client)
                .WithMany((client) => client.Appointments);

            builder.Property((appointment) => appointment.Id)
                .HasColumnName("id");
            builder.Property((appointment) => appointment.Date)
                .IsRequired()
                .HasColumnName("date");
            builder.Property((appointment) => appointment.Status)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("status");
            builder.Property((appointment) => appointment.ClientId)
                .IsRequired()
                .HasColumnName("client_id");
            builder.Property((appointment) => appointment.EstablishmentServiceId)
                .IsRequired()
                .HasColumnName("establishment_service_id");
            builder.Property((appointment) => appointment.CreatedAt)
                .IsRequired()
                .HasColumnName("created_at");
            builder.Property((appointment) => appointment.UpdatedAt)
                .IsRequired()
                .HasColumnName("updated_at");
        }
    }
}
