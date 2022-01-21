using Microsoft.EntityFrameworkCore;
using System;

namespace CloudCity.Models
{
  public class CloudCityContext : DbContext
  {
    public DbSet<District> Districts { get; set; }
    public DbSet<Location> Locations { get; set; }

    public CloudCityContext(DbContextOptions<CloudCityContext> options) : base(options) { }

    /*
     TODO: Add database seeding
    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Station>()
        .HasData(
          new Station { StationId = 1, Name = "Vancouver" },
          new Station { StationId = 2, Name = "Calgary" },
          new Station { StationId = 3, Name = "Winnipeg" },
          new Station { StationId = 4, Name = "Seattle" },
          new Station { StationId = 5, Name = "Helena" }
        );
        */
  }
}
