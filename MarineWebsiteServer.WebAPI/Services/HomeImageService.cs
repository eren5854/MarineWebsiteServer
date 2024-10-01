using AutoMapper;
using Azure;
using ED.Result;
using GenericFileService.Files;
using MarineWebsiteServer.WebAPI.DTOs.HomeImageDto;
using MarineWebsiteServer.WebAPI.Models;
using MarineWebsiteServer.WebAPI.Repositories;
using static System.Net.Mime.MediaTypeNames;

namespace MarineWebsiteServer.WebAPI.Services;

public sealed class HomeImageService(
    HomeImageRepository homeImageRepository,
    IMapper mapper)
{
    public async Task<Result<string>> Create(CreateHomeImageDto request, CancellationToken cancellationToken)
    {
        string image = "";
        var response = request.Image;
        if (response is null)
        {
            image = "";
        }
        if (response is not null)
        {
            image = FileService.FileSaveToServer(request.Image!, "wwwroot/Images/");
        }

        HomeImage homeImage = mapper.Map<HomeImage>(request);
        homeImage.Image = image;
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

        string image = "";
        var response = request.Image;
        if (response is null)
        {
            image = homeImage.Image!;
        }
        if (response is not null)
        {
            image = FileService.FileSaveToServer(request.Image!, "wwwroot/Images/");
            FileService.FileDeleteToServer("wwwroot/Images/" + homeImage.Image);
        }
        mapper.Map(request, homeImage);
        homeImage.UpdatedDate = DateTime.Now;
        homeImage.UpdatedBy = "Admin";

        return await homeImageRepository.Update(homeImage, cancellationToken);
    }
}
