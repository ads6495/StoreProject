using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using storeproject;
using StoreProject.models;

namespace StoreProject.Controllers
{
  [Route("api[controller]")]
  [ApiController]
  public class LocationController : ControllerBase
  {
    private DatabaseContext context;

    public LocationController()
    {
      this.context = new DatabaseContext();
    }
    [HttpPost]
    public ActionResult<Location> CreateLocation([FromBody] Location entry)
    {
      context.Locations.Add(entry);
      context.SaveChanges();
      return entry;
    }
    [HttpGet("All/Locations")]

    public ActionResult<IEnumerable<Location>> GetAllLocations()
    {
      var LocationList = context.Locations.OrderByDescending(i => i.Id);
      return LocationList.ToList();
    }
  }
}
