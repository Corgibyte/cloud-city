using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudCity.Models
{
  public class Location
  {
    public int LocationId { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    [StringLength(1000)]
    public string Description { get; set; }

    [Required]
    [Range(1, 392, ErrorMessage = "Value must be on one of Cloud City's {2} levels.")]
    public int Level { get; set; }

    public int DistrictId { get; set; }

    [InverseProperty("Locations")]
    public virtual District District { get; set; }

    public bool ShouldSerializeDistrict()
    {
      return District != null;
    }
  }
}