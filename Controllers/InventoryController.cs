using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
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
    public ActionResult<IEnumerable<object>> GetAllInventory()
    {
      var invs = context.Inventories.Join(context.Locations, i => i.LocationId, l => l.Id, (i, l) => new
      {
        ItemName = i.Name,
        ItemId = i.Id,
        LocationAddress = l.Address,
        LocationId = l.Id

      }
      );
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

    [HttpPost]
    public ActionResult<Inventory> AddItemToInventory([FromBody]Inventory entry)
    {
      context.Inventories.Add(entry);
      context.SaveChanges();
      return entry;
    }


    [HttpPut("{Id}")]

    public ActionResult<Inventory> UpdateItem(int Id)
    {

      var invs = context.Inventories.FirstOrDefault(inv => inv.Id == Id);
      context.Inventories.Update(invs);
      context.SaveChanges();
      return invs;
    }

    [HttpDelete("{Id}")]
    public ActionResult<Inventory> DeleteItem(int Id)
    {
      return Ok(Id);
    }

    [HttpGet("OutOfStock")]
    public ActionResult<IEnumerable<Inventory>> GetOutOfStock()
    {
      var invs = context.Inventories.OrderByDescending(inv => inv.NumberInStock == 0);
      return invs.ToList();
    }
    [HttpGet("SKU")]
    public ActionResult<IEnumerable<Inventory>> GetSku(int SKU)
    {
      var invs = context.Inventories.OrderByDescending(inv => inv.SKU == SKU);
      return invs.ToList();
    }

  }
}