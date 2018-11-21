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
  public class ReportsController : ControllerBase
  {
    private QuickleeDatabaseContext _db;

    public ReportsController()
    {
      this._db = new QuickleeDatabaseContext();
    }
    [HttpGet]
    // https://localhost:5001/api/reports 
    public IEnumerable<Reports> Get()
    {
      return _db.Reports.Include(i => i.Users).OrderBy(o => o.ReportDate);
    }
    [HttpPost]
    public ActionResult Post([FromBody]Models.Reports report)
    {
      _db.Reports.Add(report);
      _db.SaveChanges();
      return Ok(report);
    }
    [HttpPut("{reportsId}")]
    public ActionResult<Reports> Put([FromRoute] int reportsId, [FromBody] Reports updatedData)
    {
      var reports = _db.Reports.FirstOrDefault(report => report.Id == reportsId);
      reports.Sales = updatedData.Sales;
      reports.Purchases = updatedData.Purchases;
      reports.ReportDate = updatedData.ReportDate;
      reports.InventoriesBegin = updatedData.InventoriesBegin;
      reports.InventoriesEnd = updatedData.InventoriesEnd;
      _db.SaveChanges();
      return updatedData;
    }
    [HttpDelete("{reportsId}")]
    public ActionResult Delete([FromRoute]int reportsId)
    {
      var report = _db.Reports.FirstOrDefault(f => f.Id == reportsId);
      _db.Reports.Remove(report);
      _db.SaveChanges();
      return Ok();
    }
  }


}