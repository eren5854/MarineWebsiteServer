using ED.Result;
using MarineWebsiteServer.WebAPI.Context;
using MarineWebsiteServer.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MarineWebsiteServer.WebAPI.Repositories;

public sealed class HomeRepository(
    ApplicationDbContext context) : IHomeRepository
{
    public async Task<Result<string>> Create(Home home, CancellationToken cancellationToken)
    {
        await context.AddAsync(home, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Kayıt başarılı");
    }

    public async Task<Result<string>> DeleteById(Guid Id, CancellationToken cancellationToken)
    {
        Home? home = await context.Homes.Where(p => p.Id == Id).FirstOrDefaultAsync();
        if (home is null)
        {
            return Result<string>.Failure("Kayıt bulunamadı");
        }

        home.IsDeleted = true;
        context.Update(home);
        await context.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Silme işlemi başarılı");
    }

    public async Task<Result<List<Home>>> GetAll(CancellationToken cancellationToken)
    {
        var homes = await context.Homes.ToListAsync(cancellationToken);
        return Result<List<Home>>.Succeed(homes);
    }

    public Home? GetById(Guid Id)
    {
        return context.Homes.Where(p => p.Id == Id).FirstOrDefault();
    }

    public async Task<Result<string>> Update(Home home, CancellationToken cancellationToken)
    {
        context.Update(home);
        await context.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Güncelleme başarılı");
    }
}
