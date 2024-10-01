using ED.Result;
using MarineWebsiteServer.WebAPI.Context;
using MarineWebsiteServer.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MarineWebsiteServer.WebAPI.Repositories;

public sealed class LayoutRepository(
    ApplicationDbContext context)
{
    public async Task<Result<string>> Create(Layout layout, CancellationToken cancellationToken)
    {
        await context.AddAsync(layout, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Layout kayıt işlemi başarılı");
    }

    public async Task<Result<string>> DeleteById(Guid Id, CancellationToken cancellationToken)
    {
        Layout? layout = GetById(Id);
        if (layout is null)
        {
            return Result<string>.Failure("Layout bulunamadı");
        }

        layout.IsDeleted = true;
        context.Update(layout);
        await context.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Layout silme işlemi başarılı");
    }

    public async Task<Result<List<Layout>>> GetAll(CancellationToken cancellationToken)
    {
        var layouts = await context
            .Layouts
            .Where(p => !p.IsDeleted)
            .OrderBy(o => o.CreatedDate)
            .ToListAsync(cancellationToken);
        return Result<List<Layout>>.Succeed(layouts);
    }

    public Layout? GetById(Guid Id)
    {
        return context.Layouts.Where(p => p.Id == Id).FirstOrDefault();
    }

    public async Task<Result<string>> Update(Layout layout, CancellationToken cancellationToken)
    {
        context.Update(layout);
        await context.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Layout güncelleme işlemi başarılı");
    }
}
