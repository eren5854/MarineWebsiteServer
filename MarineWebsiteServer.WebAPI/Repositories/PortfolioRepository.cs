using ED.Result;
using MarineWebsiteServer.WebAPI.Context;
using MarineWebsiteServer.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MarineWebsiteServer.WebAPI.Repositories;

public sealed class PortfolioRepository(
    ApplicationDbContext context)
{
    public async Task<Result<string>> Create(Portfolio portfolio, CancellationToken cancellationToken)
    {
        await context.AddAsync(portfolio, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Portfolio kayıt işlemi başarılı");
    }

    public async Task<Result<string>> DeleteById(Guid Id, CancellationToken cancellationToken)
    {
        Portfolio? portfolio = GetById(Id);
        if (portfolio is null)
        {
            return Result<string>.Failure("Silinecek portfolio bulunamadı");
        }

        portfolio.IsDeleted = true;
        context.Update(portfolio);
        await context.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Portfolio silme işlemi başarılı");
    }

    public async Task<Result<List<Portfolio>>> GetAll(CancellationToken cancellationToken)
    {
        var portfolios = await context.Portfolios.ToListAsync(cancellationToken);
        return Result<List<Portfolio>>.Succeed(portfolios);
    }

    public Portfolio? GetById(Guid Id)
    {
        return context.Portfolios.Where(p => p.Id == Id).FirstOrDefault();
    }

    public async Task<Result<string>> Update(Portfolio portfolio, CancellationToken cancellationToken)
    {
        context.Update(portfolio);
        await context.SaveChangesAsync();
        return Result<string>.Succeed("Portfolio güncelleme işlemi başarılı");
    }
}
