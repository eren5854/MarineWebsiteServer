using ED.GenericRepository;
using MarineWebsiteServer.WebAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MarineWebsiteServer.WebAPI.Context;

public class ApplicationDbContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>, IUnitOfWork
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Home> Homes { get; set; }
    public DbSet<HomeImage> HomeImages { get; set; }
    public DbSet<About> Abouts { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<HomeIcon> HomeIcons { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<Information> Informations { get; set; }
    public DbSet<Link> Links { get; set; }
    public DbSet<Quality> Qualities { get; set; }
    public DbSet<Referance> Referances { get; set; }
    public DbSet<Service> Services { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Ignore<IdentityRoleClaim<Guid>>();
        builder.Ignore<IdentityUserClaim<Guid>>();
        builder.Ignore<IdentityUserLogin<Guid>>();
        builder.Ignore<IdentityUserToken<Guid>>();
        builder.Ignore<IdentityUserRole<Guid>>();

        //builder.Entity<Home>()
        //    .HasMany(h => h.Icons)
        //    .WithOne(h => h.Home)
        //    .HasForeignKey(h => h.HomeId);

        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
