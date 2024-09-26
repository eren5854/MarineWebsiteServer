using MarineWebsiteServer.WebAPI.Entities;

namespace MarineWebsiteServer.WebAPI.Models;

public sealed class About : Entity
{
    public string? Title { get; set; }
    public string Text { get; set; } = string.Empty;
    public string? Image { get; set; }
}
