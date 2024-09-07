using MarineWebsiteServer.WebAPI.Entities;

namespace MarineWebsiteServer.WebAPI.Models;

public sealed class Referance: Entity
{
    public string Title { get; set; } = string.Empty;
    public string? Image { get; set; }
}
