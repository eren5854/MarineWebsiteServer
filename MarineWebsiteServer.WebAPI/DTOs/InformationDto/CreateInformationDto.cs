using MarineWebsiteServer.WebAPI.DTOs.LinkDto;

namespace MarineWebsiteServer.WebAPI.DTOs.InformationDto;

public sealed record CreateInformationDto(
    string Address,
    string Email,
    string PhoneNumber,
    List<CreateLinkDto>? CreateLinks);
