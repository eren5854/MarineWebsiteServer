using MarineWebsiteServer.WebAPI.DTOs.LinkDto;

namespace MarineWebsiteServer.WebAPI.DTOs.InformationDto;

public sealed record UpdateInformationDto(
    Guid Id,
    string Address,
    string Email,
    string PhoneNumber,
    List<UpdateLinkDto> UpdateLinks);
