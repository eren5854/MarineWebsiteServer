namespace MarineWebsiteServer.WebAPI.DTOs.ContactDto;

public sealed record CreateContactDto(
    string FullName,
    string CompanyName,
    string Email,
    string Phone,
    string Subject,
    string Message);
