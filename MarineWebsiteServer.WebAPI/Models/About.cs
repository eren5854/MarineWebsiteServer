using MarineWebsiteServer.WebAPI.Entities;

namespace MarineWebsiteServer.WebAPI.Models;

public sealed class About : Entity
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<Image>? ImageUrl { get; set; }
}
