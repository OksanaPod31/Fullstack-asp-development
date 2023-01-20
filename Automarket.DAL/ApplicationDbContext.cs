using Automarket.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace Automarket.DAL;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
    public DbSet<Car> Car { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder options)
    //    => options.UseSqlite(@"Data Source=D:\Data\AutoMarkerData.db");

}