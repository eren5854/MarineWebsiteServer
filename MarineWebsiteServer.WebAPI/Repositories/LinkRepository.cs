using ED.Result;
using MarineWebsiteServer.WebAPI.Context;
using MarineWebsiteServer.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MarineWebsiteServer.WebAPI.Repositories;

public sealed class LinkRepository(
    ApplicationDbContext context)
{
    public async Task<Result<string>> Create(Link link, CancellationToken cancellationToken)
    {
        await context.AddAsync(link, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Link kayıt işlemi başarılı");
    }

    public async Task<Result<string>> DeleteById(Guid Id, CancellationToken cancellationToken)
    {
        Link? link = GetById(Id);
        if (link is null)
        {
            return Result<string>.Failure("Link bulunamadı");
        }

        link.IsDeleted = true;

        context.Update(link);
        await context.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Link silme işlemi başarılı");
    }

    public async Task<Result<List<Link>>> GetAll(CancellationToken cancellationToken)
    {
        var links = await context.Links.Where(p => !p.IsDeleted).OrderBy(o => o.CreatedDate).ToListAsync(cancellationToken);
        return Result<List<Link>>.Succeed(links);
    }

    public Link? GetById(Guid Id)
    {
        return context.Links.Where(p => p.Id == Id).FirstOrDefault();
    }

    public async Task<Result<string>> Update(Link link, CancellationToken cancellationToken)
    {
        context.Update(link);
        await context.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Link güncelleme işlemi başarılı");
    }
}
