using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace CloudCity.Models
{
  public class CloudCityContext : IdentityDbContext<ApplicationUser>
  {
    public DbSet<District> Districts { get; set; }
    public DbSet<Location> Locations { get; set; }

    public CloudCityContext(DbContextOptions<CloudCityContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);
      builder.Entity<District>()
        .HasData(
          new District
          {
            DistrictId = 1,
            Name = "Tourist District",
            Description = "The upper levels of Cloud City are given over primarily to resorts, hotels, casinos, museums, theaters, boutiques, restaurants, and other attractions for the sector's well-to-do."
          },
          new District
          {
            DistrictId = 2,
            Name = "Port Town",
            Description = "Immediately accessible from the majority of Cloud City's landing bays and platforms, Port Town occupies levels 121 through 160 of the facility."
          },
          new District
          {
            DistrictId = 3,
            Name = "Industrial District",
            Description = "These regions consist of tibanna gas mining and processing equipment, including carbonite freezing facilities. The industrial levels also include the necessities for maintaining Cloud City's operations."
          }
        );

      builder.Entity<Location>()
      .HasData(
        new Location
        {
          LocationId = 1,
          Name = "The Yarith Bespin",
          Description = "In a city well known for its elegant, high-class hotels, the Yarith Bespin stands out as the most elegant and highest class of them all.",
          DistrictId = 1,
          Level = 1
        },
        new Location
        {
          LocationId = 2,
          Name = "Figg Hall",
          Description = "Figg Hall is a public space for visitors and residents to speak with representatives of Cloud City's government.",
          DistrictId = 1,
          Level = 1
        },
        new Location
        {
          LocationId = 3,
          Name = "Market Row",
          Description = "Located on level 121, almost exactly in the center of Port Town, is a long, wide corridor that runs from the outermost edges of the Floating Home platform to the central shaft used as an semi-open marketplace.",
          DistrictId = 2,
          Level = 121
        },
        new Location
        {
          LocationId = 4,
          Name = "Landing Bay 124A",
          Description = "Located on level 124, Landing Bay 124A is in all respects a perfectly normal and average Port Town landing bay for Cloud City.",
          DistrictId = 2,
          Level = 124
        }
        ,
        new Location
        {
          LocationId = 5,
          Name = "Honest Grek's Speeders",
          Description = "\"Finest speeders on Bespin! You can trust me, I'm Honest Grek!\"",
          DistrictId = 3,
          Level = 128
        }
        , new Location
        {
          LocationId = 6,
          Name = "Negri\'s Processing Vane",
          Description = "Negri is an Ugnaught male who oversees the operations of Process Vane 5. Negri's vane is the least efficient vane in the entire complex, with the most unscheduled downtime for \"maintenance.\" In reality, Negri is perfectly willing to take a little money under the table to freeze anything a client might want in one of his carbonite sledges.",
          DistrictId = 3,
          Level = 1
        }
      );
    }
  }
}
