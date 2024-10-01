using MarineWebsiteServer.WebAPI.DTOs.LinkDto;

namespace MarineWebsiteServer.WebAPI.DTOs.LayoutDto;

public sealed record CreateLayoutDto(
    string Slogan,
    string ShortAboutText,
    IFormFile? Image);
