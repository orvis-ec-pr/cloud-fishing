using CloudFishing.Models;
using Microsoft.EntityFrameworkCore;

namespace CloudFishing.Data
{
    public class CloudFishingContext : DbContext 
    {

        public CloudFishingContext(DbContextOptions<CloudFishingContext> options) : base(options) {}

        public DbSet<Weather>? Weather { get; set; }
        public DbSet<Fish>? Fish { get; set; }
        public DbSet<Fly>? Flies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Weather>().ToTable("Weather");
            modelBuilder.Entity<Fish>().ToTable("Fish");
            modelBuilder.Entity<Fly>().ToTable("Flies");
        }
    }
}
