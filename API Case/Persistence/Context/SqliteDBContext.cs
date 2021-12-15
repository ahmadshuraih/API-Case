using API_Case.Model;
using Microsoft.EntityFrameworkCore;

namespace API_Case.Persistence.Context
{
    public class SqliteDBContext : DbContext
    {
        public DbSet<AdresGegevens> AdresGegevens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data source=AdresGevgevens.db;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdresGegevens>().ToTable("AdresGegevens");
        }
    }
}