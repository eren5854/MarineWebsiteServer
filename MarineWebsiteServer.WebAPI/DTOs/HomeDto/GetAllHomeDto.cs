using MarineWebsiteServer.WebAPI.DTOs.HomeImageDto;

namespace MarineWebsiteServer.WebAPI.DTOs.HomeDto;

public sealed record GetAllHomeDto(
    Guid Id,
    string Title,
    string Subtitle,
    string Text,
    List<GetAllHomeImageDto?> GetAllHomeImage);
