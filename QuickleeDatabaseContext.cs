using System;
using QuickleeBackEnd.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Text.RegularExpressions;

namespace QuickleeBackEnd
{
  public partial class QuickleeDatabaseContext : DbContext
  {
    public QuickleeDatabaseContext()
    {
    }

    public QuickleeDatabaseContext(DbContextOptions<QuickleeDatabaseContext> options)
        : base(options)
    {
    }

    private string ConvertPostConnectionToConnectionString(string connection)
        {
            var _connection = connection.Replace("postgres://", String.Empty);
            var output = Regex.Split(_connection, ":|@|/");
            return $"server={output[2]};database={output[4]};User Id={output[0]}; password={output[1]}; port={output[3]}";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var envConn = Environment.GetEnvironmentVariable("DATABASE_URL");
                var conn = "server=localhost;database=QuickleeDatabaseTwo;username=postgres;password=xiixvii";
                if (envConn != null)
                {
                    conn = ConvertPostConnectionToConnectionString(envConn);
                }
                optionsBuilder.UseNpgsql(conn);
            }
        }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Users>().HasData(
        new Users { Id = -1, CompanyName = "ABC Inc" }
      );
      modelBuilder.Entity<Items>().HasData(
        new Items { Id = -1, ItemName = "Item A", Count = 0, ItemPrice = 1.99f, UsersId = -1 },
        new Items { Id = -2, ItemName = "Item B", Count = 0, ItemPrice = 2.99f, UsersId = -1 },
        new Items { Id = -3, ItemName = "Item C", Count = 0, ItemPrice = 3.99f, UsersId = -1 }
      );
      modelBuilder.Entity<Inventories>().HasData(
          new Inventories { Id = -1, InventoryTotal = 26.91f, InventoryDate = new DateTime(2018, 11, 01), UsersId = -1 },
          new Inventories { Id = -2, InventoryTotal = 26.91f, InventoryDate = new DateTime(2018, 11, 30), UsersId = -1 }
      );
      modelBuilder.Entity<InventoryDetails>().HasData(
          new InventoryDetails { Id = -1, ItemsId = -1, ItemOnHandCount = 3f, InventoriesId = -1 },
          new InventoryDetails { Id = -2, ItemsId = -2, ItemOnHandCount = 3f, InventoriesId = -1 },
          new InventoryDetails { Id = -3, ItemsId = -3, ItemOnHandCount = 3f, InventoriesId = -1 },
          new InventoryDetails { Id = -4, ItemsId = -1, ItemOnHandCount = 3f, InventoriesId = -2 },
          new InventoryDetails { Id = -5, ItemsId = -2, ItemOnHandCount = 3f, InventoriesId = -2 },
          new InventoryDetails { Id = -6, ItemsId = -3, ItemOnHandCount = 3f, InventoriesId = -2 }
      );
      modelBuilder.Entity<Reports>().HasData(
          new Reports { Id = -1, Sales = 500.01f, Purchases = 100.01f, ReportDate = new DateTime(2018, 12, 01), InventoriesBegin = 26.61f, InventoriesEnd = 26.61f, UsersId = -1 }
      );
    }
    public DbSet<Users> Users { get; set; }
    public DbSet<Items> Items { get; set; }
    public DbSet<Inventories> Inventories { get; set; }
    public DbSet<InventoryDetails> InventoryDetails { get; set; }
    public DbSet<Reports> Reports { get; set; }
  }
}
