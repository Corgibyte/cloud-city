using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using CloudCity.Models;

namespace CloudCity.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class DistrictsController : ControllerBase
  {
    private readonly CloudCityContext _db;

    public DistrictsController(CloudCityContext db)
    {
      _db = db;
    }

    //GET api/districts
    [HttpGet]
    public async Task<ActionResult> Get()
    {
      List<District> districts = await _db.Districts.OrderBy(district => district.Name).ToListAsync();
      return new JsonResult(districts);
    }

    //GET api/districts/id
    [HttpGet("{id}")]
    public async Task<ActionResult<District>> GetDistrict(int id)
    {
      District district = await _db.Districts.FirstOrDefaultAsync(dist => dist.DistrictId == id);
      if (district == null)
      {
        return NotFound();
      }
      return district;
    }

    //POST api/districts
    [HttpPost]
    public async Task<ActionResult<District>> Post(District district)
    {
      _db.Districts.Add(district);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetDistrict), new { id = district.DistrictId }, district);
    }

    //PUT api/districts/id
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, District district)
    {
      if (id != district.DistrictId)
      {
        return BadRequest(new { Message = "DistrictId must match id in endpoint URL." });
      }
      _db.Entry(district).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!_db.Districts.Any(dist => dist.DistrictId == id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }
      return NoContent();
    }

    //DELETE api/districts/id
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDistrict(int id)
    {
      District district = await _db.Districts.FindAsync(id);
      if (district == null)
      {
        return NotFound();
      }
      _db.Districts.Remove(district);
      await _db.SaveChangesAsync();
      return NoContent();
    }
  }
}