using ED.Result;
using MarineWebsiteServer.WebAPI.Context;
using MarineWebsiteServer.WebAPI.DTOs.HomeDto;
using MarineWebsiteServer.WebAPI.DTOs.HomeImageDto;
using MarineWebsiteServer.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MarineWebsiteServer.WebAPI.Repositories;

public sealed class HomeRepository(
    ApplicationDbContext context)
{
    public async Task<Result<string>> Create(Home home, CancellationToken cancellationToken)
    {
        await context.AddAsync(home, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Kayıt başarılı");
    }

    public async Task<Result<string>> DeleteById(Guid Id, CancellationToken cancellationToken)
    {
        Home? home = await context.Homes
            .Include(h => h.HomeImages)
            .FirstOrDefaultAsync(h => h.Id == Id, cancellationToken);

        if (home is null)
        {
            return Result<string>.Failure("Kayıt bulunamadı");
        }

        home.IsDeleted = true;

        if (home.HomeImages != null)
        {
            foreach (var homeImage in home.HomeImages)
            {
                homeImage.IsDeleted = true;
            }
        }

        context.Update(home);
        await context.SaveChangesAsync(cancellationToken);

        return Result<string>.Succeed("Silme işlemi başarılı");
    }

    public async Task<Result<List<Home>>> GetAll(CancellationToken cancellationToken)
    {
        //var homes = await context
        //.Homes
        //.Include(h => h.HomeImages) // HomeImages ile ilişkili verileri dahil ediyoruz
        //.Where(p => !p.IsDeleted)
        //.ToListAsync(cancellationToken);

        //// Her bir home nesnesini manuel olarak GetAllHomeDto'ya dönüştürüyoruz
        //var homeDtos = homes.Select(home => new GetAllHomeDto(
        //    home.Id,
        //    home.Title,
        //    home.Subtitle,
        //    home.Text,
        //    home.HomeImages.Select(img => new GetAllHomeImageDto(
        //        img.Id,
        //        img.Title,
        //        img.Image
        //    )).ToList() // Tüm HomeImage'ları liste olarak ekliyoruz
        //)).ToList();

        var homes = await context.Homes.Where(p => !p.IsDeleted).ToListAsync(cancellationToken);

        return Result<List<Home>>.Succeed(homes);
        //return Result<List<GetAllHomeDto>>.Succeed(homeDto);

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
