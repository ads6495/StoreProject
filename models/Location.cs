using System.Collections.Generic;

namespace StoreProject.models
{
  public class Location
  {
    public int Id { get; set; }
    public string Address { get; set; }
    public string ManagerName { get; set; }
    public int PhoneNumber { get; set; }

    public List<Inventory> Inventories { get; set; } = new List<Inventory>();

  }
}