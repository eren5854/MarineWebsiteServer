using ED.Result;
using MarineWebsiteServer.WebAPI.Context;
using MarineWebsiteServer.WebAPI.DTOs;
using MarineWebsiteServer.WebAPI.Models;

namespace MarineWebsiteServer.WebAPI.Repositories;

public sealed class AppUserRepository(
    ApplicationDbContext context)
{
    public async Task<Result<string>> Update(AppUser appUser, CancellationToken cancellationToken)
    {
        context.Update(appUser);
        await context.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Kullanıcı güncelleme işlemi başarılı");
    }
}
