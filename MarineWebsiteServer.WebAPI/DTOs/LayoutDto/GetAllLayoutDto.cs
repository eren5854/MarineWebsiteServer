using MarineWebsiteServer.WebAPI.DTOs.LinkDto;

namespace MarineWebsiteServer.WebAPI.DTOs.LayoutDto;

public sealed record GetAllLayoutDto(
    Guid Id,
    string Slogan,
    string ShortAboutText,
    List<GetAllLinkDto> GetAllLinks);
