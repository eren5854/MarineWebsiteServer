namespace MarineWebsiteServer.WebAPI.DTOs.LinkDto;

public sealed record UpdateLinkDto(
    Guid Id,
    string LinkIcon,
    string LinkUrl);