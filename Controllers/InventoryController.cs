using System.Linq;
using Microsoft.AspNetCore.Mvc;
using storeproject;
using StoreProject.models;

namespace StoreProject.Controllers
{
  [Route("api[controller]")]
  [ApiController]
  public class InventoryController { }
  //   {
  //     private DatabaseContext context;

  //     public InventoryController()
  //     {
  //       this.context = new DatabaseContext();
  //     }

  //     [HttpPost]
  //     public ActionResult<IOrderedEnumerable<Inventory>> GetAllInventory()
  //     {
  //       var Invetories = context.Inventories;
  //       context.SaveChanges();
  //     }

  //   }
}