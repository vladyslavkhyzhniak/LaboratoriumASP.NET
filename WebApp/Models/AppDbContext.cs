using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Models;

public class AppDbContext : IdentityDbContext<IdentityUser>
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
        base.OnModelCreating(modelBuilder);
        var ADMIN_ID = Guid.NewGuid().ToString();
        var ADMIN_ROLE_ID = Guid.NewGuid().ToString();
        var USER_ID = Guid.NewGuid().ToString();
        var USER_ROLE_ID = Guid.NewGuid().ToString();
        
        modelBuilder.Entity<IdentityRole>()
            .HasData(
                new IdentityRole()
                {
                    Id = ADMIN_ROLE_ID,
                    Name = "admin",
                    NormalizedName = "admin".ToUpper(),
                    ConcurrencyStamp = ADMIN_ROLE_ID
                },
                new IdentityRole()
                {
                    Id = USER_ROLE_ID,
                    Name = "user1",
                    NormalizedName = "user1".ToUpper(),
                    ConcurrencyStamp = USER_ROLE_ID
                }
                );
        var admin = new IdentityUser()
        {
            Id = ADMIN_ID,
            UserName = "user",
            NormalizedUserName = "user".ToUpper(),
            Email = "user@user.com",
            NormalizedEmail = "user@user.com".ToUpper(),
            EmailConfirmed = true,
        };
        var user = new IdentityUser()
        {
            Id = USER_ID,
            UserName = "user2",
            NormalizedUserName = "user2".ToUpper(),
            Email = "user2@user.com",
            NormalizedEmail = "user2@user.com".ToUpper(),
            EmailConfirmed = true,
        };
        
        PasswordHasher<IdentityUser> hasher = new PasswordHasher<IdentityUser>();
        
        admin.PasswordHash = hasher.HashPassword(admin, "123123");
        user.PasswordHash = hasher.HashPassword(user, "234234!");
        modelBuilder.Entity<IdentityUserRole<string>>()
            .HasData(
                new IdentityUserRole<string>()
                {
                    RoleId = ADMIN_ROLE_ID,
                    UserId = ADMIN_ID
                },
                new IdentityUserRole<string>()
                {
                    RoleId = USER_ROLE_ID,
                    UserId = USER_ID,
                },
                new IdentityUserRole<string>()
                {
                    RoleId = USER_ROLE_ID,
                    UserId = ADMIN_ID
                });
        
        modelBuilder.Entity<IdentityUser>()
            .HasData(admin, user);
        
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