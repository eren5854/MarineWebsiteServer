using MarineWebsiteServer.WebAPI.Entities;

namespace MarineWebsiteServer.WebAPI.Models;

public sealed class Contact : Entity
{
    public string ContactName { get; set; } = string.Empty;
    public string ContactEmail { get; set; } = string.Empty;
    public string ContactPhone { get; set; } = string.Empty;
    public string ContactCompanyName {  get; set; } = string.Empty;
    public string Subject { get; set; } = string.Empty;
    public string Message {  get; set; } = string.Empty;
}
