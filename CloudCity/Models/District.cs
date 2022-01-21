using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CloudCity.Models
{
  public class District
  {
    public int DistrictId { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    [Required]
    [StringLength(1000)]
    public string Description { get; set; }

    public virtual ICollection<Location> Locations { get; set; }

    public District()
    {
      Locations = new HashSet<Location>();
    }
  }
}