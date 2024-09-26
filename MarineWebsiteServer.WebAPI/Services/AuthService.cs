using ED.Result;
using MarineWebsiteServer.WebAPI.DTOs;
using MarineWebsiteServer.WebAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MarineWebsiteServer.WebAPI.Services;

public sealed class AuthService(
    UserManager<AppUser> userManager,
    IJwtProvider jwtProvider)
{
    public async Task<Result<LoginResponseDto>> Login(LoginDto request, CancellationToken cancellationToken)
    {
        string emailOrUserName = request.EmailOrUserName.ToUpper();
        AppUser? user = await userManager
            .Users
            .FirstOrDefaultAsync(p => p.Email == request.EmailOrUserName ||
            p.UserName == request.EmailOrUserName);
        if (user is null)
        {
            return Result<LoginResponseDto>.Failure("Kullanıcı bulunamadı");
        }

        bool result = await userManager.CheckPasswordAsync(user, request.Password);
        if (!result)
        {
            return Result<LoginResponseDto>.Failure("Şifre Yanlış");
        }

        var loginResponse = await jwtProvider.CreateToken(user);
        return loginResponse;
    }
}
