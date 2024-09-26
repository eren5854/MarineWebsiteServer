namespace MarineWebsiteServer.WebAPI.DTOs.AboutDto;

public sealed record CreateAboutDto(
    string? Title,
    string Text,
    IFormFile? Image);
