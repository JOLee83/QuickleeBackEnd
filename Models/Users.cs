using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuickleeBackEnd.Models
{
  public class Users
  {
    public int Id { get; set; }
    public string CompanyName { get; set; }

  }
}