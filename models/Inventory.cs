using System;


namespace StoreProject.models
{
  public class Inventory
  {
    public int Id { get; set; }
    public int SKU { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int NumberInStock { get; set; }
    public int Price { get; set; }
    public DateTime DateOrdered { get; set; }

    public int? LocationId { get; set; }

    public Location Location { get; set; }
  }
}

