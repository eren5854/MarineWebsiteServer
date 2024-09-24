using MarineWebsiteServer.WebAPI.Entities;

namespace MarineWebsiteServer.WebAPI.Models;

public sealed class HomeIcon : Entity
{
    public string Title { get; set; } = string.Empty;
    public string Subtitle { get; set; } = string.Empty;
    public string? Icon { get; set; }

    //public Guid? HomeId { get; set; }
    //public Home? Home { get; set; }
}
