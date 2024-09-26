namespace MarineWebsiteServer.WebAPI.DTOs.ContactDto;

public sealed record UpdateContactDto(
    Guid Id,
    bool IsRead);
