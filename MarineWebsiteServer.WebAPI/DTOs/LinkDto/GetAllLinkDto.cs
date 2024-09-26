namespace MarineWebsiteServer.WebAPI.DTOs.LinkDto;

public sealed record GetAllLinkDto(
    Guid Id,
    string LinkIcon,
    string LinkUrl);
