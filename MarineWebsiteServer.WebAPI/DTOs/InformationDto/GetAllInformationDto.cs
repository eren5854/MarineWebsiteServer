using MarineWebsiteServer.WebAPI.DTOs.LinkDto;

namespace MarineWebsiteServer.WebAPI.DTOs.InformationDto;

public sealed record GetAllInformationDto(
    Guid Id,
    string Address,
    string Email,
    string PhoneNumber,
    List<GetAllLinkDto> GetAllLinks);
