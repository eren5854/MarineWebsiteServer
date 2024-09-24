using MarineWebsiteServer.WebAPI.Entities;

namespace MarineWebsiteServer.WebAPI.Models;

public sealed class Link : Entity
{
    public string Title { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public string? Icon { get; set; }

    //public Guid? HomeId { get; set; }
    //public Home? Home { get; set; }
}
