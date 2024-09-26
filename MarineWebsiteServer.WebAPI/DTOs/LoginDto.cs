namespace MarineWebsiteServer.WebAPI.DTOs;

public sealed record LoginDto(
    string EmailOrUserName,
    string Password);
