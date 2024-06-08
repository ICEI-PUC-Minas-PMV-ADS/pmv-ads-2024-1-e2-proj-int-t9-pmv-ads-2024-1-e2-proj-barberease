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

            optionsBuilder.UseSqlServer(connectionString);
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
            modelBuilder.Entity<EstablishmentPeriodEntity>(new EstablishmentPeriodMap().Configure);

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
                var establishmentPeriod1 = new EstablishmentPeriodEntity
                {
                    Id = new Guid("182cde4a-b74d-49a9-a2ec-59d1a82c2e68"),
                    DayOfWeek = "MONDAY",
                    OpeningTime = "09:00:00",
                    ClosingTime = "18:00:00",
                    TimeBetweenService = "00:30:00",
                    IsClosed = false,
                    EstablishmentId = establishment.Id,
                    CreatedAt = DateTime.Parse("2024-06-06T00:41:32+0000"),
                    UpdatedAt = DateTime.Parse("2024-06-06T00:41:32+0000"),
                };
                var establishmentPeriod2 = new EstablishmentPeriodEntity
                {
                    Id = new Guid("58695664-a938-4dc7-9384-54616a77ad9f"),
                    DayOfWeek = "TUESDAY",
                    OpeningTime = "09:00:00",
                    ClosingTime = "18:00:00",
                    TimeBetweenService = "00:30:00",
                    IsClosed = false,
                    EstablishmentId = establishment.Id,
                    CreatedAt = DateTime.Parse("2024-06-06T00:41:32+0000"),
                    UpdatedAt = DateTime.Parse("2024-06-06T00:41:32+0000"),
                };
                var establishmentPeriod3 = new EstablishmentPeriodEntity
                {
                    Id = new Guid("cdb52f2e-04e2-466c-8154-1403eb4aed63"),
                    DayOfWeek = "WEDNESDAY",
                    OpeningTime = "09:00:00",
                    ClosingTime = "18:00:00",
                    TimeBetweenService = "00:30:00",
                    IsClosed = false,
                    EstablishmentId = establishment.Id,
                    CreatedAt = DateTime.Parse("2024-06-06T00:41:32+0000"),
                    UpdatedAt = DateTime.Parse("2024-06-06T00:41:32+0000"),
                };
                var establishmentPeriod4 = new EstablishmentPeriodEntity
                {
                    Id = new Guid("30813908-3985-42c2-8cee-0b7fde58a1be"),
                    DayOfWeek = "THURSDAY",
                    OpeningTime = "09:00:00",
                    ClosingTime = "18:00:00",
                    TimeBetweenService = "00:30:00",
                    IsClosed = false,
                    EstablishmentId = establishment.Id,
                    CreatedAt = DateTime.Parse("2024-06-06T00:41:32+0000"),
                    UpdatedAt = DateTime.Parse("2024-06-06T00:41:32+0000"),
                };
                var establishmentPeriod5 = new EstablishmentPeriodEntity
                {
                    Id = new Guid("ecf07789-b490-4c26-acc7-8acd123767b6"),
                    DayOfWeek = "FRIDAY",
                    OpeningTime = "09:00:00",
                    ClosingTime = "18:00:00",
                    TimeBetweenService = "00:30:00",
                    IsClosed = false,
                    EstablishmentId = establishment.Id,
                    CreatedAt = DateTime.Parse("2024-06-06T00:41:32+0000"),
                    UpdatedAt = DateTime.Parse("2024-06-06T00:41:32+0000"),
                };
                var establishmentPeriod6 = new EstablishmentPeriodEntity
                {
                    Id = new Guid("c7e3ba97-ae61-4ee5-bfb2-5e571cf6856e"),
                    DayOfWeek = "SATURDAY",
                    IsClosed = true,
                    EstablishmentId = establishment.Id,
                    CreatedAt = DateTime.Parse("2024-06-06T00:41:32+0000"),
                    UpdatedAt = DateTime.Parse("2024-06-06T00:41:32+0000"),
                };
                var establishmentPeriod7 = new EstablishmentPeriodEntity
                {
                    Id = new Guid("4568c25f-ee4c-430f-a852-99d2d27bad8f"),
                    DayOfWeek = "SUNDAY",
                    IsClosed = true,
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
                modelBuilder.Entity<EstablishmentPeriodEntity>().HasData(
                    establishmentPeriod1,
                    establishmentPeriod2,
                    establishmentPeriod3,
                    establishmentPeriod4,
                    establishmentPeriod5,
                    establishmentPeriod6,
                    establishmentPeriod7
                );
                modelBuilder.Entity<AppointmentEntity>().HasData(appointment1, appointment2, appointment3);
            }
        }
    }
}
