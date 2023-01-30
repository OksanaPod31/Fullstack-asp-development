using Automarket.Domain.Entity;
using Automarket.Domain.Enum;
using Automarket.Domain.Helpers;
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
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(builder =>
        {
            builder.ToTable("Users").HasKey(x => x.Id);

            builder.HasData(new User
            {
                Id = 1,
                Name = "AdminTest",
                Password = HashPasswordHelper.HashPassowrd("1234"),
                Role = Role.Admin
            });

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Password).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        });
        modelBuilder.Entity<Car>(builder =>
        {
            builder.ToTable("Cars").HasKey(x => x.Id);

            builder.HasData(new Car
            {
                Id = 1,
                Name = "BMW X5",
                Description = new string('A', 50),
                Speed = 230,
                Model = "BMW",
                Avatar = null,
                TypeCar = TypeCar.PassengerCar,
                PathCar = "BMW.jpg"
            });
        });
    }

    //protected override void OnConfiguring(DbContextOptionsBuilder options)
    //    => options.UseSqlite(@"Data Source=D:\Data\AutoMarkerData.db");

}