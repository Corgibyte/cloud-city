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
  public class LocationsController : ControllerBase
  {
    private readonly CloudCityContext _db;

    public LocationsController(CloudCityContext db)
    {
      _db = db;
    }

    //GET api/locations
    [HttpGet]
    public async Task<ActionResult> Get()
    {
      List<Location> locations = await _db.Locations
        .Include(location => location.District)
        .OrderBy(location => location.LocationId)
        .ToListAsync();
      return new JsonResult(locations);
    }

    //GET api/locations/id
    [HttpGet("{id}")]
    public async Task<ActionResult<Location>> GetLocation(int id)
    {
      Location location = await _db.Locations.FirstOrDefaultAsync(dist => dist.LocationId == id);
      if (location == null)
      {
        return NotFound();
      }
      return location;
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
        if (!_db.Locations.Any(dist => dist.LocationId == id))
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