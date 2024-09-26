namespace MarineWebsiteServer.WebAPI.DTOs;

public sealed record ChangePasswordDto(
    Guid Id,
    string CurrentPassword,
    string NewPassword);
