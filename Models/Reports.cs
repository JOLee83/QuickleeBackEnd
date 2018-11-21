using System;

namespace QuickleeBackEnd.Models
{
  public class Reports
  {
    public int Id { get; set; }

    public float Sales { get; set; }

    public float Purchases { get; set; }

    public DateTime ReportDate { get; set; }

    public float InventoriesBegin { get; set; }
    //using to call Beginning Inventory total and date
    public float InventoriesEnd { get; set; }
    //using to call Ending Inventory total and date
    public int? UsersId { get; set; }

    public Users Users { get; set; }


  }
}