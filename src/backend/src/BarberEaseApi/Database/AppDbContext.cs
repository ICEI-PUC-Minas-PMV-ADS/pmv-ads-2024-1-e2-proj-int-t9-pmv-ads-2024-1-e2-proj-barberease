using BarberEaseApi.Entities;
using BarberEaseApi.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace BarberEaseApi.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<ClientEntity> Clients { get; set; }
        public DbSet<EstablishmentEntity> Establishments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION") ?? "Data Source=db.sqlite3;Pooling=False";
            var dbDialect = Environment.GetEnvironmentVariable("DB_DIALECT") ?? "SQLite";

            if (dbDialect.Equals("sqlite", StringComparison.CurrentCultureIgnoreCase))
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
            modelBuilder.Entity<AppointmentEntity>(new AppointmentMap().Configure);
            modelBuilder.Entity<EstablishmentServiceEntity>(new EstablishmentServiceMap().Configure);

            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")?.ToLower() == "development")
            {
                var client = new ClientEntity
                {
                    Id = new Guid("ba997890-aa6a-4c10-bbad-c930a19b119f"),
                    Email = "client@default.com",
                    FirstName = "Client",
                    LastName = "Default",
                    City = "São Paulo",
                    State = "São Paulo",
                    Phone = "119123456789",
                    CreatedAt = DateTime.Parse("2024-06-06T00:41:32+0000"),
                    UpdatedAt = DateTime.Parse("2024-06-06T00:41:32+0000"),
                };
                client.SetPassword("123");
                var establishment = new EstablishmentEntity
                {
                    Id = new Guid("db279123-e792-44aa-9c43-87c869ff5abd"),
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
                    CreatedAt = DateTime.Parse("2024-06-06T00:41:32+0000"),
                    UpdatedAt = DateTime.Parse("2024-06-06T00:41:32+0000"),
                };
                establishment.SetPassword("123");
                var establishmentService1 = new EstablishmentServiceEntity
                {
                    Id = new Guid("18e9b482-7c3e-4db5-8c40-3d79c9ac4f66"),
                    Name = "Corte de Cabelo Masculino",
                    Category = "Corte de Cabelo",
                    Price = 50.0,
                    EstablishmentId = establishment.Id,
                    CreatedAt = DateTime.Parse("2024-06-06T00:41:32+0000"),
                    UpdatedAt = DateTime.Parse("2024-06-06T00:41:32+0000"),
                };
                var establishmentService2 = new EstablishmentServiceEntity
                {
                    Id = new Guid("21e79cb3-9385-4f9c-9e55-28c6c3b0a8bc"),
                    Name = "Barba Completa",
                    Category = "Barba",
                    Price = 35.0,
                    EstablishmentId = establishment.Id,
                    CreatedAt = DateTime.Parse("2024-06-06T00:41:32+0000"),
                    UpdatedAt = DateTime.Parse("2024-06-06T00:41:32+0000"),
                };
                var establishmentService3 = new EstablishmentServiceEntity
                {
                    Id = new Guid("cffb2e84-71a1-4977-afb2-13197662210b"),
                    Name = "Design de Sobrancelhas",
                    Category = "Sobrancelha",
                    Price = 25.0,
                    EstablishmentId = establishment.Id,
                    CreatedAt = DateTime.Parse("2024-06-06T00:41:32+0000"),
                    UpdatedAt = DateTime.Parse("2024-06-06T00:41:32+0000"),
                };
                var appointment1 = new AppointmentEntity
                {
                    Id = new Guid("aa4f97ba-514e-4964-a2f2-f639d2400aa6"),
                    Date = DateTime.Parse("2024-06-06T12:00:00+0000"),
                    Status = "CONFIRMED",
                    ClientId = client.Id,
                    EstablishmentServiceId = establishmentService1.Id,
                    CreatedAt = DateTime.Parse("2024-06-06T00:41:32+0000"),
                    UpdatedAt = DateTime.Parse("2024-06-06T00:41:32+0000"),
                };
                var appointment2 = new AppointmentEntity
                {
                    Id = new Guid("9454ae1e-38a0-4a24-86e4-548e672c6396"),
                    Date = DateTime.Parse("2024-06-06T12:30:00+0000"),
                    Status = "CANCELLED",
                    ClientId = client.Id,
                    EstablishmentServiceId = establishmentService2.Id,
                    CreatedAt = DateTime.Parse("2024-06-06T00:41:32+0000"),
                    UpdatedAt = DateTime.Parse("2024-06-06T00:41:32+0000"),
                };
                var appointment3 = new AppointmentEntity
                {
                    Id = new Guid("7f16ad90-8d07-42ac-9257-dbb2a9aa7343"),
                    Date = DateTime.Parse("2024-06-06T13:00:00+0000"),
                    Status = "RECEIVED",
                    ClientId = client.Id,
                    EstablishmentServiceId = establishmentService3.Id,
                    CreatedAt = DateTime.Parse("2024-06-06T00:41:32+0000"),
                    UpdatedAt = DateTime.Parse("2024-06-06T00:41:32+0000"),
                };

                modelBuilder.Entity<ClientEntity>().HasData(client);
                modelBuilder.Entity<EstablishmentEntity>().HasData(establishment);
                modelBuilder.Entity<EstablishmentServiceEntity>().HasData(establishmentService1, establishmentService2, establishmentService3);
                modelBuilder.Entity<AppointmentEntity>().HasData(appointment1, appointment2, appointment3);
            }
        }
    }
}
