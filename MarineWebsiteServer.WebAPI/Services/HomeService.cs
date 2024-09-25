using AutoMapper;
using ED.Result;
using MarineWebsiteServer.WebAPI.DTOs.HomeDto;
using MarineWebsiteServer.WebAPI.Models;
using MarineWebsiteServer.WebAPI.Repositories;

namespace MarineWebsiteServer.WebAPI.Services;

public sealed class HomeService(
    HomeRepository homeRepository,
    IMapper mapper)
{
    public async Task<Result<string>> Create(CreateHomeDto request, CancellationToken cancellationToken)
    {
        Home home = mapper.Map<Home>(request);
        home.CreatedBy = "Admin";
        home.CreatedDate = DateTime.Now;
        if (request.HomeImages != null)
        {
            home.HomeImages = mapper.Map<List<HomeImage>>(request.HomeImages);
            foreach (var homeImage in home.HomeImages)
            {
                homeImage.Home = home;
                homeImage.CreatedBy = "Admin";
                homeImage.CreatedDate = DateTime.Now;
            }

            //home.HomeImages = request.HomeImages.Select(imageDto => new HomeImage
            //{
            //    Title = imageDto.Title,
            //    Image = imageDto.Image,
            //    Home = home // Home nesnesini ilişkilendir
            //}).ToList();
        }

        return await homeRepository.Create(home, cancellationToken);
    }

    public async Task<Result<string>> DeleteById(Guid id, CancellationToken cancellationToken)
    {
        return await homeRepository.DeleteById(id, cancellationToken);
    }

    public Task<Result<List<GetAllHomeDto>>> GetAll(CancellationToken cancellationToken)
    {
        return homeRepository.GetAll(cancellationToken);
    }

    public async Task<Result<string>> Update(UpdateHomeDto request, CancellationToken cancellationToken)
    {
        Home? home = homeRepository.GetById(request.Id);
        if (home is null)
        {
            return Result<string>.Failure("Kayıt bulunamadı");
        }

        mapper.Map(request, home);
        home.UpdatedBy = "Admin";
        home.UpdatedDate = DateTime.Now;

        home.HomeImages = mapper.Map<List<HomeImage>>(request.HomeImages);
        foreach (var homeImage in home.HomeImages)
        {
            homeImage.Home = home;
            homeImage.UpdatedBy = "Admin";
            homeImage.UpdatedDate = DateTime.Now;
        }

        return await homeRepository.Update(home, cancellationToken);
    }
}
