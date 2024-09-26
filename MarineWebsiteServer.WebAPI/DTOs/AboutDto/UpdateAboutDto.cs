namespace MarineWebsiteServer.WebAPI.DTOs.AboutDto;

public sealed record UpdateAboutDto(
    Guid Id,
    string? Title,
    string Text,
    IFormFile? Image);
