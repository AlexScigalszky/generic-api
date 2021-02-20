using GenericApi.Model.Models;
using GenericApi.Model.Seeds;
using Microsoft.EntityFrameworkCore;

namespace GenericApi.Model
{
    public class GenericApiContext : DbContext
    {
        
        public GenericApiContext() : base()
        {
        }

        public GenericApiContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.EnableSensitiveDataLogging(true);
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-S6KI11E;Database=GenericApi;Integrated Security=True;Trusted_Connection=True");
            }
        }

        public DbSet<Log> Logs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Log>().HasData(LogSeed.GetData());
        }
    }
}
