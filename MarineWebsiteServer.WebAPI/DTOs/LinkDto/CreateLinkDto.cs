namespace MarineWebsiteServer.WebAPI.DTOs.LinkDto;

public sealed record CreateLinkDto(
    string LinkIcon,
    string LinkUrl,
    Guid? InformationId,
    Guid? LayoutId);
