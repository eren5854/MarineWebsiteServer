using MarineWebsiteServer.WebAPI.DTOs.HomeImageDto;
using MarineWebsiteServer.WebAPI.Models;

namespace MarineWebsiteServer.WebAPI.DTOs.HomeDto;

public sealed record UpdateHomeDto(
    Guid Id,
    string Title,
    string Subtitle,
    string Text);
