using MarineWebsiteServer.WebAPI.Entities;

namespace MarineWebsiteServer.WebAPI.Models;

public sealed class Image : Entity
{
    public string ImageUrl { get; set; } = string.Empty;
    public Guid? QualityId { get; set; }
    public Quality? Quality { get; set; }

    public Guid? ServiceId { get; set; }
    public Service? Service { get; set; }

    public Guid? AboutId { get; set; }
    public About? About { get; set; }
}
