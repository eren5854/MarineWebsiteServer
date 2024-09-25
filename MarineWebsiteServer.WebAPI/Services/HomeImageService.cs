using AutoMapper;
using ED.Result;
using MarineWebsiteServer.WebAPI.DTOs.HomeImageDto;
using MarineWebsiteServer.WebAPI.Models;
using MarineWebsiteServer.WebAPI.Repositories;

namespace MarineWebsiteServer.WebAPI.Services;

public sealed class HomeImageService(
    HomeImageRepository homeImageRepository,
    IMapper mapper)
{
    public async Task<Result<string>> Create(CreateHomeImageDto request, CancellationToken cancellationToken)
    {
        HomeImage homeImage = mapper.Map<HomeImage>(request);
        homeImage.CreatedBy = "Admin";
        homeImage.CreatedDate = DateTime.Now;

        return await homeImageRepository.Create(homeImage, cancellationToken);
    }

    public async Task<Result<string>> DeleteById(Guid id, CancellationToken cancellationToken)
    {
        return await homeImageRepository.DeleteById(id, cancellationToken);
    }

    public async Task<Result<List<HomeImage>>> GetAll(CancellationToken cancellationToken)
    {

    }
}
