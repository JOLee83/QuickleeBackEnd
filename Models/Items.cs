using System;

namespace QuickleeBackEnd.Models
{
  public class Items
  {
    public int Id { get; set; }

    public string ItemName { get; set; }

    public float ItemPrice { get; set; }

    public float Count { get; set; }
    public int? UsersId { get; set; }

    public Users Users { get; set; }

  }
}