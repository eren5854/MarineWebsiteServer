using MarineWebsiteServer.WebAPI.Entities;

namespace MarineWebsiteServer.WebAPI.Models;

public sealed class Information : Entity
{
    public string Title { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Email {  get; set; } = string.Empty; 
    public string Phone { get; set; } = string.Empty;
}
