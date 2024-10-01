using MarineWebsiteServer.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarineWebsiteServer.WebAPI.Configurations;

public sealed class AboutConfiguration : IEntityTypeConfiguration<About>
{
    public void Configure(EntityTypeBuilder<About> builder)
    {
        builder
            .Property(p => p.Title)
            .HasColumnType("varchar(100)")
            .HasMaxLength(100);

        builder
            .Property(p => p.Text)
            .HasColumnType("varchar(MAX)");


    }
}
