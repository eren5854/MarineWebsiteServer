namespace MarineWebsiteServer.WebAPI.DTOs.HomeImageDto;

public sealed record UpdateHomeImageDto(
    Guid Id,
    string Title,
    string Image);
