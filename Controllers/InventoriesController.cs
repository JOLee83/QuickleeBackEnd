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
  public class InventoriesController : ControllerBase
  {
    private QuickleeDatabaseContext _db;

    public InventoriesController()
    {
      this._db = new QuickleeDatabaseContext();
    }
    [HttpGet]
    // https://localhost:5001/api/iventories 
    public IEnumerable<Inventories> Get()
    {
      return _db.Inventories.Include(i => i.Users).OrderBy(o => o.InventoryDate);
    }
    [HttpPost]
    public ActionResult Post([FromBody]Models.Inventories inventory)
    {
      _db.Inventories.Add(inventory);
      _db.SaveChanges();
      return Ok(inventory);
    }
    [HttpPut("{inventoriesId}")]
    public ActionResult<Inventories> Put([FromRoute] int inventoriesId, [FromBody] Inventories updatedData)
    {
      var inventories = _db.Inventories.FirstOrDefault(inventory => inventory.Id == inventoriesId);
      inventories.InventoryTotal = updatedData.InventoryTotal;
      inventories.InventoryDate = updatedData.InventoryDate;
      _db.SaveChanges();
      return updatedData;
    }
    [HttpDelete("{inventoriesId}")]
    public ActionResult Delete([FromRoute]int inventoriesId)
    {
      var inventory = _db.Inventories.FirstOrDefault(f => f.Id == inventoriesId);
      _db.Inventories.Remove(inventory);
      _db.SaveChanges();
      return Ok();
    }


  }
}
