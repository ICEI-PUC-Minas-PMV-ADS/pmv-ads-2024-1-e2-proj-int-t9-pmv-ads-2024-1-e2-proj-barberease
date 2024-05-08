using BarberEaseApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BarberEaseApi.Mappings
{
    public class ClientMap : IEntityTypeConfiguration<ClientEntity>
    {
        public void Configure(EntityTypeBuilder<ClientEntity> builder)
        {
            builder.ToTable("clients");
            builder.HasKey((client) => client.Id);
            builder.HasIndex((client) => client.Email)
                .IsUnique();

            builder.Property((client) => client.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            builder.Property((client) => client.HashedPassword)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("hashed_password");
            builder.Property((client) => client.FirstName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("first_name");
            builder.Property((client) => client.LastName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("last_name");
            builder.Property((client) => client.City)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("city");
            builder.Property((client) => client.State)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("state");
            builder.Property((client) => client.Phone)
                .HasMaxLength(50)
                .HasColumnName("phone");
            builder.Property((client) => client.CreatedAt)
                .IsRequired()
                .HasColumnName("created_at");
            builder.Property((client) => client.UpdatedAt)
                .IsRequired()
                .HasColumnName("updated_at");
        }
    }
}
