namespace MarineWebsiteServer.WebAPI.DTOs.HomeImageDto;

public sealed record CreateHomeImageDto(
    string Title,
    string Image,
    Guid HomeId);

