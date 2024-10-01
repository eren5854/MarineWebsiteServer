namespace MarineWebsiteServer.WebAPI.DTOs;

public sealed record UpdateUserDto(
    Guid Id,
    string FirstName,
    string LastName,
    string UserName,
    string Email);
