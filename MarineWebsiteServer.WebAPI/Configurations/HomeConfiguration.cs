using MarineWebsiteServer.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarineWebsiteServer.WebAPI.Configurations;

public sealed class HomeConfiguration : IEntityTypeConfiguration<Home>
{
    public void Configure(EntityTypeBuilder<Home> builder)
    {
        builder
            .Property(p => p.Title)
            .IsRequired()
            .HasColumnType("varchar(50)")
            .HasMaxLength(50);

        builder
            .Property(p => p.Subtitle)
            .IsRequired()
            .HasColumnType("varchar(100)")
            .HasMaxLength(100);

        builder
            .HasMany(p => p.HomeImages)
            .WithOne(p => p.Home)
            .HasForeignKey(p => p.HomeId);
    }
}
