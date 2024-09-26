using MarineWebsiteServer.WebAPI.DTOs.LinkDto;

namespace MarineWebsiteServer.WebAPI.DTOs.LayoutDto;

public sealed record UpdateLayoutDto(
    Guid Id,
    string Slogan,
    string ShortAboutText,
    List<UpdateLinkDto> UpdateLinks);
