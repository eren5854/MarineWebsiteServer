using MarineWebsiteServer.WebAPI.Entities;

namespace MarineWebsiteServer.WebAPI.Models;

public sealed class Layout : Entity
{
    public string Slogan { get; set; } = string.Empty;
    public string ShortAboutText { get; set; } = string.Empty;
    public string? Image { get; set; }
    public List<Link>? Links { get; set; }
}
