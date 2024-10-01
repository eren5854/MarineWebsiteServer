using AutoMapper;
using ED.GenericRepository;
using ED.Result;
using GenericFileService.Files;
using MarineWebsiteServer.WebAPI.DTOs;
using MarineWebsiteServer.WebAPI.Models;
using MarineWebsiteServer.WebAPI.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MarineWebsiteServer.WebAPI.Services;

public sealed class UserService(
    UserManager<AppUser> userManager,
    IMapper mapper)
{
    public async Task<Result<string>> Create(CreateUserDto request, CancellationToken cancellationToken)
    {
        if (request.Email != "")
        {
            if (request.UserName != "")
            {
                var isEmailExists = await userManager.Users.AnyAsync(x => x.Email == request.Email);
                if (isEmailExists)
                {
                    return Result<string>.Failure("Email already exists");
                }

                var isUserNameExists = await userManager.Users.AnyAsync(x => x.UserName == request.UserName);
                if (isUserNameExists)
                {
                    return Result<string>.Failure("User name already exists");
                }

                AppUser user = mapper.Map<AppUser>(request);
                user.CreatedBy = request.UserName;
                user.CreatedDate = DateTime.Now;

                IdentityResult result = await userManager.CreateAsync(user, request.Password);
                if (!result.Succeeded)
                {
                    return Result<string>.Failure("Record could not be created.");
                }
                return Result<string>.Succeed("User registration successful.");
            }
            return Result<string>.Failure("User Name field cannot be empty");
        }
        return Result<string>.Failure("E-mail field cannot be empty.");
    }

    public async Task<Result<string>> Update(UpdateUserDto request, CancellationToken cancellationtoken)
    {
        AppUser? appuser = await userManager.FindByIdAsync(request.Id.ToString());
        if (appuser is null)
        {
            return Result<string>.Failure("user not found");
        }

        mapper.Map(request, appuser);
        appuser.UpdatedBy = "Admin";
        appuser.UpdatedDate = DateTime.Now;

        IdentityResult result = await userManager.UpdateAsync(appuser);
        if (!result.Succeeded)
        {
            return Result<string>.Failure("Record could not be created.");
        }
        return Result<string>.Succeed("User update successful.");
    }

    public async Task<Result<string>> DeleteById(Guid Id, CancellationToken cancellation)
    {
        AppUser? appuser = await userManager.FindByIdAsync(Id.ToString());
        if (appuser is null)
        {
            return Result<string>.Failure("user not found");
        }

        appuser.IsDeleted = true;

        IdentityResult result = await userManager.UpdateAsync(appuser);
        if (!result.Succeeded)
        {
            return Result<string>.Failure("Record could not be created.");
        }
        return Result<string>.Succeed("User deleted successful.");
    }

    public async Task<Result<AppUser>> GetById(Guid Id, CancellationToken cancellation)
    {
        AppUser? appUser = await userManager.FindByIdAsync(Id.ToString());
        if (appUser is null)
        {
            return Result<AppUser>.Failure("user not found");
        }

        return Result<AppUser>.Succeed(appUser);
    }

}

