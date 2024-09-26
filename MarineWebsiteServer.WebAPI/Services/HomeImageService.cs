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
        return await homeImageRepository.GetAll(cancellationToken);
    }

    public async Task<Result<string>> Update(UpdateHomeImageDto request, CancellationToken cancellationToken)
    {
        HomeImage? homeImage = homeImageRepository.GetById(request.Id);
        if (homeImage is null)
        {
            return Result<string>.Failure("Kayıt bulunamadı");
        }

        mapper.Map(request, homeImage);
        homeImage.UpdatedDate = DateTime.Now;
        homeImage.UpdatedBy = "Admin";

        return await homeImageRepository.Update(homeImage, cancellationToken);
    }
}
