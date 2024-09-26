using AutoMapper;
using ED.Result;
using GenericFileService.Files;
using MarineWebsiteServer.WebAPI.DTOs.AboutDto;
using MarineWebsiteServer.WebAPI.Models;
using MarineWebsiteServer.WebAPI.Repositories;

namespace MarineWebsiteServer.WebAPI.Services;

public sealed class AboutService(
    AboutRepository aboutRepository,
    IMapper mapper)
{
    public async Task<Result<string>> Create(CreateAboutDto request, CancellationToken cancellationToken)
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

        About about = mapper.Map<About>(request);
        about.Image = image;
        about.CreatedBy = "Admin";
        about.CreatedDate = DateTime.Now;

        return await aboutRepository.Create(about, cancellationToken);
    }

    public async Task<Result<string>> DeleteById(Guid id, CancellationToken cancellationToken)
    {
        return await aboutRepository.DeleteById(id, cancellationToken);
    }

    public async Task<Result<List<About>>> GetAll(CancellationToken cancellation)
    {
        return await aboutRepository.GetAll(cancellation);
    }

    public async Task<Result<string>> Update(UpdateAboutDto request, CancellationToken cancellationToken)
    {
        About? about = aboutRepository.GetById(request.Id);
        if (about is null)
        {
            return Result<string>.Failure("Güncellenecek kayıt bulunamadı");
        }

        string image = "";
        var response = request.Image;
        if (response is null)
        {
            image = about.Image!;
        }
        if (response is not null)
        {
            image = FileService.FileSaveToServer(request.Image!, "wwwroot/Images/");
        }

        mapper.Map(request, about);
        about.Image = image;
        about.UpdatedDate = DateTime.Now;
        about.UpdatedBy = "Admin";

        return await aboutRepository.Update(about, cancellationToken);
    }
}
