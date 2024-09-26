namespace MarineWebsiteServer.WebAPI.DTOs;

public sealed record ChangePasswordUsingTokenDto(
    string Email,
    string NewPassword,
    string Token);
