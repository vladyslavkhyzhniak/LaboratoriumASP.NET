using Microsoft.EntityFrameworkCore;

namespace WebApp.Models;

public class AppDbContext: DbContext
{
    public DbSet<ContactEntity> Contacts { get; set; }

    private string DbPath { get; set; }
    public AppDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);

        DbPath = Path.Join(path, "contacts.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data source ={DbPath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ContactEntity>().HasData(
            new ContactEntity()
            {
            Id = 4,
            FirstName = "123",
            LastName = "123",
            Email = "123@123",
            PhoneNumber = "123123123",
            Birth = new DateOnly(2000,10,10),
            Created = DateTime.Now
            },
            new ContactEntity()
            {
                Id = 5,
                FirstName = "abc",
                LastName = "abc",
                Email = "abc@abc",
                PhoneNumber = "123123124",
                Birth = new DateOnly(2000,10,10),
                Created = DateTime.Now
            },
            new ContactEntity()
            {
                Id = 6,
                FirstName = "1235abc",
                LastName = "1235abc",
                Email = "123@1235abc",
                PhoneNumber = "123123125",
                Birth = new DateOnly(2000,10,10),
                Created = DateTime.Now
            }
        );
    }
}