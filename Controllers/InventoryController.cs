using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using storeproject;
using StoreProject.models;

namespace StoreProject.Controllers
{
  [Route("api[controller]")]
  [ApiController]
  public class InventoryController : ControllerBase
  {
    private DatabaseContext context;

    public InventoryController()
    {
      this.context = new DatabaseContext();
    }

    [HttpGet]
    public ActionResult<IEnumerable<Inventory>> GetAllInventory()
    {
      var invs = context.Inventories.OrderByDescending(inv => inv.SKU);

      return invs.ToList();
    }

    [HttpGet("{Id}")]
    public ActionResult GetOneItem(int Id)
    {
      var invs = context.Inventories.FirstOrDefault(inv => inv.Id == Id);
      if (invs != null)
      {
        return Ok(invs);
      }
      else
      {
        return NotFound();
      }
    }
  }
}