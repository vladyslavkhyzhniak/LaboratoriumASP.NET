using Microsoft.EntityFrameworkCore;

namespace WebApp.Models;

public class AppDbContext: DbContext
{
    public DbSet<ContactEntity> Contacts { get; set; }
    public DbSet<OrganizationEntity> Organization { get; set; }

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
        modelBuilder.Entity<OrganizationEntity>()
            .ToTable("organizations").HasData(
                new OrganizationEntity()
                {
                    Id = 101,
                    NIP = "12312313",
                    Name = "WSEI",
                    REGON = "123131231"
                },
                new OrganizationEntity()
                {
                    Id = 102,
                    NIP = "123123132",
                    Name = "WSEI2",
                    REGON = "123131231213"
                }
            );
        modelBuilder.Entity<OrganizationEntity>().OwnsOne(o => o.Adress)
            .HasData(
                new
                {
                    OrganizationEntityId = 101,
                    Street = "św. Filipa",
                    City = "Kraków"
                },
                new
                {
                    OrganizationEntityId = 102,
                    Street = "Dworcowa",
                    City = "Łódź"
                }
            );
        modelBuilder.Entity<ContactEntity>()
            .Property(c => c.OrganizationId).HasDefaultValue(101);
        
        modelBuilder.Entity<ContactEntity>().HasData(
            new ContactEntity()
            {
            Id = 4,
            FirstName = "123",
            LastName = "123",
            Email = "123@123",
            PhoneNumber = "123123123",
            Birth = new DateOnly(2000,10,10),
            Created = DateTime.Now,
            OrganizationId = 101
            },
            new ContactEntity()
            {
                Id = 5,
                FirstName = "abc",
                LastName = "abc",
                Email = "abc@abc",
                PhoneNumber = "123123124",
                Birth = new DateOnly(2000,10,10),
                Created = DateTime.Now,
                OrganizationId = 101
            },
            new ContactEntity()
            {
                Id = 6,
                FirstName = "1235abc",
                LastName = "1235abc",
                Email = "123@1235abc",
                PhoneNumber = "123123125",
                Birth = new DateOnly(2000,10,10),
                Created = DateTime.Now,
                OrganizationId = 101
            }
        );
    }
}