using BarberEaseApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BarberEaseApi.Mappings
{
    public class EstablishmentServiceMap : IEntityTypeConfiguration<EstablishmentServiceEntity>
    {
        public void Configure(EntityTypeBuilder<EstablishmentServiceEntity> builder)
        {
            builder.ToTable("services");

            builder.HasKey((establishmentService) => establishmentService.Id);

            builder.HasIndex((establishmentService) => establishmentService.Name)
                .IsUnique();
            builder.HasIndex((establishmentService) => establishmentService.Category)
                .IsUnique();

            builder.HasOne((establishmentService) => establishmentService.Establishment)
                .WithMany((establishment) => establishment.EstablishmentServices);
            builder.HasMany((establishmentService) => establishmentService.Appointments)
                .WithOne((appointment) => appointment.EstablishmentService);

            builder.Property((establishmentService) => establishmentService.Id)
                .HasColumnName("id");
            builder.Property((establishmentService) => establishmentService.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("name");
            builder.Property((establishmentService) => establishmentService.Category)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("category");
            builder.Property((establishmentService) => establishmentService.Description)
                .HasColumnName("description");
            builder.Property((establishmentService) => establishmentService.Price)
                .IsRequired()
                .HasColumnName("price");
            builder.Property((establishmentService) => establishmentService.EstablishmentId)
                .IsRequired()
                .HasColumnName("establishment_id");
            builder.Property((establishmentService) => establishmentService.CreatedAt)
                .IsRequired()
                .HasColumnName("created_at");
            builder.Property((establishmentService) => establishmentService.UpdatedAt)
                .IsRequired()
                .HasColumnName("updated_at");
        }
    }
}
