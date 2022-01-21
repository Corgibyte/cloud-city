using CloudCity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudCity.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class LocationsController : ControllerBase
  {
    private readonly CloudCityContext _db;

    public LocationsController(CloudCityContext db)
    {
      _db = db;
    }

    //GET api/locations
    [HttpGet]
    public async Task<ActionResult> Get(int districtId)
    {
      IQueryable<Location> query = _db.Locations.Include(loc => loc.District).AsQueryable();
      if (districtId != 0)
      {
        query = query.Where(loc => loc.DistrictId == districtId);
      }
      List<Location> locations = await query.OrderBy(location => location.LocationId).ToListAsync();
      return new JsonResult(locations);
    }

    //GET api/locations/id
    [HttpGet("{id}")]
    public async Task<ActionResult<Location>> GetLocation(int id)
    {
      Location location = await _db.Locations.FirstOrDefaultAsync(loc => loc.LocationId == id);
      if (location == null)
      {
        return NotFound();
      }
      return new JsonResult(location);
    }

    //POST api/locations
    [HttpPost]
    public async Task<ActionResult<Location>> Post(Location location)
    {
      _db.Locations.Add(location);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetLocation), new { id = location.LocationId }, location);
    }

    //PUT api/locations/id
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Location location)
    {
      if (id != location.LocationId)
      {
        return BadRequest(new { Message = "LocationId must match id in endpoint URL." });
      }
      _db.Entry(location).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!_db.Locations.Any(loc => loc.LocationId == id))
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

    //DELETE api/locations/id
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLocation(int id)
    {
      Location location = await _db.Locations.FindAsync(id);
      if (location == null)
      {
        return NotFound();
      }
      _db.Locations.Remove(location);
      await _db.SaveChangesAsync();
      return NoContent();
    }
  }
}