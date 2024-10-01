using AutoMapper;
using ED.Result;
using MarineWebsiteServer.WebAPI.DTOs.LinkDto;
using MarineWebsiteServer.WebAPI.Models;
using MarineWebsiteServer.WebAPI.Repositories;

namespace MarineWebsiteServer.WebAPI.Services;

public sealed class LinkService(
    LinkRepository linkRepository,
    IMapper mapper)
{
    public async Task<Result<string>> Create(CreateLinkDto request, CancellationToken cancellationToken)
    {
        Link link = mapper.Map<Link>(request);
        link.CreatedDate = DateTime.Now;
        link.CreatedBy = "Admin";

        return await linkRepository.Create(link, cancellationToken);
    }

    public async Task<Result<string>> DeleteById(Guid Id, CancellationToken cancellationToken)
    {
        return await linkRepository.DeleteById(Id, cancellationToken);
    }

    public async Task<Result<List<Link>>> GetAll(CancellationToken cancellationToken)
    {
        return await linkRepository.GetAll(cancellationToken);
    }

    public async Task<Result<string>> Update(UpdateLinkDto request, CancellationToken cancellationToken)
    {
        Link? link = linkRepository.GetById(request.Id);
        if (link is null)
        {
            return Result<string>.Failure("Link bulunamadı");
        }

        mapper.Map(request, link);
        link.UpdatedDate = DateTime.Now;
        link.UpdatedBy = "Admin";

        return await linkRepository.Update(link, cancellationToken);
    }
}
