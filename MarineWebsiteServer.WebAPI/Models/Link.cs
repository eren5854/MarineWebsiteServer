using MarineWebsiteServer.WebAPI.Entities;

namespace MarineWebsiteServer.WebAPI.Models;

public sealed class Link : Entity
{
    public string? LinkIcon { get; set; }
    public string LinkUrl { get; set; } = string.Empty;

    public Guid? InformationId { get; set; }
    public Information? Information { get; set; }

    public Guid? LayoutId { get; set; } 
    public Layout? Layout { get; set; }
}
