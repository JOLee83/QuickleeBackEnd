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
  public class InventoryDetailsController : ControllerBase
  {
    private QuickleeDatabaseContext _db;
    public InventoryDetailsController()
    {
      this._db = new QuickleeDatabaseContext();
    }
    [HttpGet("{InventoriesId}")]
    // https://localhost:5001/api/iventorydetails
    public ActionResult Get([FromRoute] int InventoriesId)
    {
      return Ok(_db.InventoryDetails.Include(i => i.Inventories).FirstOrDefault(f => f.InventoriesId == InventoriesId));
    }
    // [HttpPost]
    // public ActionResult Post([FromBody]Models.InventoryDetails inventoryDetail)
    // {
    //   _db.InventoryDetails.Add(inventoryDetail);
    //   _db.SaveChanges();
    //   return Ok(inventoryDetail);
    // }
    // [HttpPut("{inventoryDetailId}")]
    // public ActionResult<InventoryDetails> Put([FromRoute] int inventoryDetailsId, [FromBody] InventoryDetails updatedData)
    // {
    //   var inventoryDetails = _db.InventoryDetails.FirstOrDefault(inventoryDetail => inventoryDetail.Id == inventoryDetailsId);
    //   inventoryDetails.ItemOnHandCount = updatedData.ItemOnHandCount;
    //   _db.SaveChanges();
    //   return updatedData;
    // }
    // [HttpDelete("{inventoriesId}")]
    // public ActionResult Delete([FromRoute]int inventoryDetailsId)
    // {
    //   var inventoryDetail = _db.InventoryDetails.FirstOrDefault(f => f.Id == inventoryDetailsId);
    //   _db.InventoryDetails.Remove(inventoryDetail);
    //   _db.SaveChanges();
    //   return Ok();
    // }

  }
}