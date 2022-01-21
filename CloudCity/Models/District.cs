using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CloudCity.Models
{
  public class District
  {
    public int DistrictId { get; set; }

    [Required]
    [StringLength(20)]
    public string Name { get; set; }

    [Required]
    [StringLength(300)]
    public string Description { get; set; }

    public virtual ICollection<Location> Locations { get; set; }

    public District()
    {
      Locations = new HashSet<Location>();
    }
  }
}