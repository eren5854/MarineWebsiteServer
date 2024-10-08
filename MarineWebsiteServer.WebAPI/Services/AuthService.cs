﻿using ED.Result;
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
            .Users.Where(p => !p.IsDeleted)
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

    public async Task<Result<string>> ChangePassword(ChangePasswordDto request, CancellationToken cancellationToken)
    {
        AppUser? user = await userManager.FindByIdAsync(request.Id.ToString());
        if (user is null)
        {
            return Result<string>.Failure("User not found");
        }

        IdentityResult result = await userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);
        if (!result.Succeeded)
        {
            return Result<string>.Failure("Old password is wrong");
        }

        return Result<string>.Succeed("Password change is successful");
    }

    public async Task<Result<string>> ForgotPassword(ForgotPasswordDto request, CancellationToken cancellationToken)
    {
        AppUser? user = await userManager.FindByEmailAsync(request.Email);
        if (user is null)
        {
            return Result<string>.Failure("User not found");
        }

        string token = await userManager.GeneratePasswordResetTokenAsync(user);

        return token;
    }

    public async Task<Result<string>> ChangePasswordUsingToken(ChangePasswordUsingTokenDto request, CancellationToken cancellationToken)
    {
        AppUser? user = await userManager.FindByEmailAsync(request.Email);
        if (user is null)
        {
            return Result<string>.Failure("User not found");
        }

        IdentityResult result = await userManager.ResetPasswordAsync(user, request.Token, request.NewPassword);
        if (!result.Succeeded)
        {
            return Result<string>.Failure("Error ");
        }

        return Result<string>.Succeed("New password is successful");
    }
}
