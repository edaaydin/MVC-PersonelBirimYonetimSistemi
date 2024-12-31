using Microsoft.EntityFrameworkCore;

namespace Mvc_Projem.Models
{
    public class Context : DbContext
    {
        public DbSet<Birim> Birims { get; set; }
        public DbSet<Personel> Personels { get; set; }
        public DbSet<Admin> Admins { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server =.; Database = BirimDB; Trusted_Connection = True; MultipleActiveResultSets = true; TrustServerCertificate = True;");
        }
    }
}
