using BarberEaseApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BarberEaseApi.Mappings
{
    public class EstablishmentMap : IEntityTypeConfiguration<EstablishmentEntity>
    {
        public void Configure(EntityTypeBuilder<EstablishmentEntity> builder)
        {
            builder.ToTable("establishments");

            builder.HasKey((establishment) => establishment.Id);
            builder.HasIndex((establishment) => establishment.Email)
                .IsUnique();
            builder.HasIndex((establishment) => establishment.Cnpj)
                .IsUnique();

            builder.Property((establishment) => establishment.Id)
                .HasColumnName("id");
            builder.Property((establishment) => establishment.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            builder.Property((establishment) => establishment.HashedPassword)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("hashed_password");
            builder.Property((establishment) => establishment.CompanyName)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("company_name");
            builder.Property((establishment) => establishment.Cnpj)
                .HasMaxLength(50)
                .HasColumnName("cnpj");
            builder.Property((establishment) => establishment.OwnerFirstName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("owner_first_name");
            builder.Property((establishment) => establishment.OwnerLastName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("owner_last_name");
            builder.Property((establishment) => establishment.City)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("city");
            builder.Property((establishment) => establishment.State)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("state");
            builder.Property((establishment) => establishment.Cep)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("cep");
            builder.Property((establishment) => establishment.Address)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("address");
            builder.Property((establishment) => establishment.Phone)
                .HasMaxLength(50)
                .HasColumnName("phone");
            builder.Property((establishment) => establishment.CreatedAt)
                .IsRequired()
                .HasColumnName("created_at");
            builder.Property((establishment) => establishment.UpdatedAt)
                .IsRequired()
                .HasColumnName("updated_at");
        }
    }
}
