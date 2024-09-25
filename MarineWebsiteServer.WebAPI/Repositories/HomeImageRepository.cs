using ED.Result;
using MarineWebsiteServer.WebAPI.Context;
using MarineWebsiteServer.WebAPI.DTOs.HomeImageDto;
using MarineWebsiteServer.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MarineWebsiteServer.WebAPI.Repositories;

public sealed class HomeImageRepository(
    ApplicationDbContext context)
{
    public async Task<Result<string>> Create(HomeImage homeImage, CancellationToken cancellationToken)
    {
        await context.AddAsync(homeImage, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Kayıt işlemi başarılı");
    }

    public async Task<Result<string>> DeleteById(Guid id, CancellationToken cancellationToken)
    {
        HomeImage? homeImage = GetById(id);
        if (homeImage is null)
        {
            return Result<string>.Failure("Kayıt bulunamadı");
        }

        homeImage.IsDeleted = true;
        context.Update(homeImage);
        await context.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Silme işlemi başarılı");
    }

    public async Task<Result<List<HomeImage>>> GetAll(CancellationToken cancellationToken)
    {
        var homeImages = await context.HomeImages.ToListAsync(cancellationToken);
        return Result<List<HomeImage>>.Succeed(homeImages);
    }

    public HomeImage? GetById(Guid id)
    {
        return context.HomeImages.Where(p => p.Id == id).FirstOrDefault();
    }

    public async Task<Result<string>> Update(HomeImage homeImage, CancellationToken cancellationToken)
    {
        context.Update(homeImage);
        await context.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Günceleme işlemi başarılı");
    }
}
