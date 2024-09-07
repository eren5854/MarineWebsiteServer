using MarineWebsiteServer.WebAPI.Entities;

namespace MarineWebsiteServer.WebAPI.Models;

public sealed class Home : Entity
{
    public string Title { get; set; } = string.Empty;
    public string Subtitle { get; set; } = string.Empty;
    public string? MainImage { get; set; }
    public List<HomeIcon>? Icons { get; set; }
    public List<Link>? Links { get; set; }
}
