using MarineWebsiteServer.WebAPI.Models;

namespace MarineWebsiteServer.WebAPI.DTOs.HomeDto;

public sealed record CreateHomeDto(
    string Title,
    string Subtitle,
    string Text,
    List<HomeImage> HomeImages);
