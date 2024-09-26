using MarineWebsiteServer.WebAPI.DTOs;
using MarineWebsiteServer.WebAPI.Models;

namespace MarineWebsiteServer.WebAPI.Services;

public interface IJwtProvider
{
    Task<LoginResponseDto> CreateToken(AppUser user);
}
