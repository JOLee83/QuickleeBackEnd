using System;

namespace QuickleeBackEnd.Models
{
  public class Inventories
  {
    public int Id { get; set; }

    public float InventoryTotal { get; set; }
    //will be calculated form Inventory Details
    public DateTime InventoryDate { get; set; }

    public int? UsersId { get; set; }

    public Users Users { get; set; }

  }
}