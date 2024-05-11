using BarberEaseApi.Entities;
using BarberEaseApi.Mappings;
using Microsoft.EntityFrameworkCore;

namespace BarberEaseApi.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<ClientEntity> Clients { get; set; }
        public DbSet<EstablishmentEntity> Establishments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION");

            if (Environment.GetEnvironmentVariable("DB_DIALECT")?.ToLower() == "sqlite")
            {
                optionsBuilder.UseSqlite(connectionString);
            }
            else
            {
                optionsBuilder.UseSqlServer(connectionString);
            }

            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ClientEntity>(new ClientMap().Configure);
            modelBuilder.Entity<EstablishmentEntity>(new EstablishmentMap().Configure);

            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")?.ToLower() == "development")
            {
                var client = new ClientEntity
                {
                    Id = Guid.NewGuid(),
                    Email = "client@default.com",
                    FirstName = "Client",
                    LastName = "Default",
                    City = "São Paulo",
                    State = "São Paulo",
                    Phone = "119123456789",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                };
                client.SetPassword("123");
                var establishment = new EstablishmentEntity
                {
                    Id = Guid.NewGuid(),
                    Email = "establishment@default.com",
                    CompanyName = "Establishment Default",
                    Cnpj = "72835673000172",
                    OwnerFirstName = "Establishment",
                    OwnerLastName = "Default",
                    City = "São Paulo",
                    State = "São Paulo",
                    Cep = "03923087",
                    Address = "Rua Francisco Salzillo",
                    Phone = "119123456789",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                };
                establishment.SetPassword("123");

                modelBuilder.Entity<ClientEntity>().HasData(client);
                modelBuilder.Entity<EstablishmentEntity>().HasData(establishment);
            }
        }
    }
}
