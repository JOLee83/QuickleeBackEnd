using System;
using QuickleeBackEnd.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        optionsBuilder.UseNpgsql("server=localhost;database=QuickleeDatabaseTwo;username=postgres;password=xiixvii");
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
