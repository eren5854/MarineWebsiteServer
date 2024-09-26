using ED.Result;
using MarineWebsiteServer.WebAPI.Context;
using MarineWebsiteServer.WebAPI.DTOs.InformationDto;
using MarineWebsiteServer.WebAPI.DTOs.LinkDto;
using MarineWebsiteServer.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MarineWebsiteServer.WebAPI.Repositories;

public sealed class InformationRepository(
    ApplicationDbContext context)
{
    public async Task<Result<string>> Create(Information information, CancellationToken cancellationToken)
    {
        await context.AddAsync(information, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Information kayıt işlemi başarılı");
    }

    public async Task<Result<string>> DeleteById(Guid Id, CancellationToken cancellationToken)
    {
        Information? information = await context
            .Informations
            .Include(h => h.Links)
            .FirstOrDefaultAsync(h => h.Id == Id);
        if (information is null)
        {
            return Result<string>.Failure("Information kaydı bulunamadı");
        }

        information.IsDeleted = true;

        if (information.Links != null)
        {
            foreach (var links in information.Links)
            {
                links.IsDeleted = true;
            }
        }

        context.Update(information);
        await context.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Information silme işlemi başarılı");
    }  

    public async Task<Result<List<GetAllInformationDto>>> GetAlll(CancellationToken cancellationToken)
    {
        var informations = await context
            .Informations
            .Include(h => h.Links)
            .Where(p => !p.IsDeleted)
            .ToListAsync(cancellationToken);

        var informationDtos = informations
                .Select(i => new GetAllInformationDto(
                    i.Id,
                    i.Address,
                    i.Email,
                    i.PhoneNumber,
                    i.Links!.Where(p => !p.IsDeleted).Select(l => new GetAllLinkDto(
                        l.Id,
                        l.LinkIcon!,
                        l.LinkUrl)).ToList()
                        )).ToList();

        return Result<List<GetAllInformationDto>>.Succeed(informationDtos);
    }

    public Information? GetById(Guid Id)
    {
        return context.Informations.Where(p => p.Id == Id && !p.IsDeleted).FirstOrDefault();
    }

    public async Task<Result<string>> Update(Information information, CancellationToken cancellationToken)
    {
        context.Update(information);
        await context.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Information güncelleme işlemi başarılı");
    }
}
