using System;

namespace QuickleeBackEnd.Models
{
  public class Reports
  {
    public int Id { get; set; }

    public float Sales { get; set; }

    public float Purchases { get; set; }

    public DateTime ReportDate { get; set; }

    public int InventoriesBeginId { get; set; }
    //using to call Beginning Inventory total and date
    public int InventoriesEndId { get; set; }
    //using to call Ending Inventory total and date
    public Inventories InventoriesBegin { get; set; }
    public Inventories InventoriesEnd { get; set; }

  }
}