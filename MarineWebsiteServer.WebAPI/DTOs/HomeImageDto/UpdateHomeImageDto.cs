namespace MarineWebsiteServer.WebAPI.DTOs.HomeImageDto;

public sealed record UpdateHomeImageDto(
    Guid Id,
    string Title,
    IFormFile? Image,
    Guid? HomeId);
