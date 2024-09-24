using MarineWebsiteServer.WebAPI.Entities;

namespace MarineWebsiteServer.WebAPI.Models;

public sealed class HomeImage : Entity
{
    public string? Title { get; set; }
    public string? Image {  get; set; }

    public Guid? HomeId { get; set; }
    public Home? Home { get; set; }
}
