using System;

namespace QuickleeBackEnd.Models
{
  public class InventoryDetails
  {
    public int Id { get; set; }

    public int ItemsId { get; set; }

    public Items Items { get; set; }

    public float ItemOnHandCount { get; set; }

    public int InventoriesId { get; set; }

    public Inventories Inventories { get; set; }

  }
}
