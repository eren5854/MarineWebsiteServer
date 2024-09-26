using ED.Result;
using MarineWebsiteServer.WebAPI.Context;
using MarineWebsiteServer.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MarineWebsiteServer.WebAPI.Repositories;

public sealed class AboutRepository(
    ApplicationDbContext context)
{
    public async Task<Result<string>> Create(About about, CancellationToken cancellationToken)
    {
        await context.AddAsync(about, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Kayıt işlemi başarılı");
    }

    public async Task<Result<string>> DeleteById(Guid id, CancellationToken cancellationToken)
    {
        About? about = GetById(id);
        if (about is null)
        {
            return Result<string>.Failure("Kayıt bulunamadı");
        }

        about.IsDeleted = true;
        context.Update(about);
        await context.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Silme işlemi başarılı");
    }

    public async Task<Result<List<About>>> GetAll(CancellationToken cancellationToken)
    {
        var abouts = await context.Abouts.ToListAsync(cancellationToken);
        return Result<List<About>>.Succeed(abouts);
    }

    public About? GetById(Guid id)
    {
        return context.Abouts.Where(p => p.Id == id).FirstOrDefault();
    }

    public async Task<Result<string>> Update(About about, CancellationToken cancellationToken)
    {
        context.Update(about);
        await context.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Güncelleme işlemi başarılı");
    }
}
