using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuickleeBackEnd.Models;
using Microsoft.EntityFrameworkCore;


namespace QuickleeBackEnd.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ItemsController : ControllerBase
  {
    private QuickleeDatabaseContext _db;

    public ItemsController()
    {
      this._db = new QuickleeDatabaseContext();
    }
    [HttpGet]
    // https://localhost:5001/api/Items 
    public IEnumerable<Items> Get()
    {
      return _db.Items.Include(i => i.Users).OrderBy(o => o.ItemName);
    }
    [HttpPost]
    public ActionResult Post([FromBody]Models.Items item)
    {
      _db.Items.Add(item);
      _db.SaveChanges();
      return Ok(item);
    }
    [HttpPut("{itemsId}")]
    public ActionResult<Items> Put([FromRoute] int itemsId, [FromBody] Items updatedData)
    {
      var items = _db.Items.FirstOrDefault(item => item.Id == itemsId);
      items.ItemName = updatedData.ItemName;
      items.ItemPrice = updatedData.ItemPrice;
      _db.SaveChanges();
      return updatedData;

    }
    [HttpDelete("{itemsId}")]
    public ActionResult Delete([FromRoute]int itemsId)
    {
      var item = _db.Items.FirstOrDefault(f => f.Id == itemsId);
      _db.Items.Remove(item);
      _db.SaveChanges();
      return Ok();
    }


  }
}
