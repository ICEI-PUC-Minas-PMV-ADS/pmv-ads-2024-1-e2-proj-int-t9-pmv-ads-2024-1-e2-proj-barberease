using BarberEaseApi.Entities;
using BarberEaseApi.Mappings;
using Microsoft.EntityFrameworkCore;

namespace BarberEaseApi.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<ClientEntity> Clients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Data Source=db.sqlite3;Pooling=False";

            optionsBuilder.UseSqlite(connectionString);
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ClientEntity>(new ClientMap().Configure);
        }
    }
}
