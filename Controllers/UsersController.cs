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
  public class UsersController : ControllerBase
  {
    private QuickleeDatabaseContext _db;

    public UsersController()
    {
      this._db = new QuickleeDatabaseContext();
    }
    [HttpGet]
    // https://localhost:5001/api/users 
    public IEnumerable<Users> Get()
    {
      return _db.Users.OrderBy(o => o.Id);
    }
  }
}