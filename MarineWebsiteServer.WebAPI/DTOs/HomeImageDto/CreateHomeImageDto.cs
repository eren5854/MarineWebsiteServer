namespace MarineWebsiteServer.WebAPI.DTOs.HomeImageDto;

public sealed record CreateHomeImageDto(
    string Title,
    IFormFile? Image,
    Guid HomeId);

