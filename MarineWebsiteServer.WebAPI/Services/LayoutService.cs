using AutoMapper;
using ED.Result;
using GenericFileService.Files;
using MarineWebsiteServer.WebAPI.DTOs.LayoutDto;
using MarineWebsiteServer.WebAPI.Models;
using MarineWebsiteServer.WebAPI.Repositories;

namespace MarineWebsiteServer.WebAPI.Services;

public sealed class LayoutService(
    LayoutRepository layoutRepository,
    IMapper mapper)
{
    public async Task<Result<string>> Create(CreateLayoutDto request, CancellationToken cancellationToken)
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

        Layout layout = mapper.Map<Layout>(request);
        layout.Image = image;
        layout.CreatedBy = "Admin";
        layout.CreatedDate = DateTime.Now;

        return await layoutRepository.Create(layout, cancellationToken);
    }

    public async Task<Result<string>> DeleteById(Guid Id, CancellationToken cancellationToken)
    {
        return await layoutRepository.DeleteById(Id, cancellationToken);
    }

    public async Task<Result<List<Layout>>> GetAll(CancellationToken cancellationToken)
    {
        return await layoutRepository.GetAll(cancellationToken);
    }

    public async Task<Result<string>> Update(UpdateLayoutDto request, CancellationToken cancellationToken)
    {
        Layout? layout = layoutRepository.GetById(request.Id);
        if (layout is null)
        {
            return Result<string>.Failure("Layout bulunamadı");
        }

        string image = "";
        var response = request.Image;
        if (response is null)
        {
            image = layout.Image!;
        }
        if (response is not null)
        {
            image = FileService.FileSaveToServer(request.Image!, "wwwroot/Images/");
            FileService.FileDeleteToServer("wwwroot/Images/" + layout.Image);
        }

        mapper.Map(request, layout);
        layout.Image = image;
        layout.UpdatedDate = DateTime.Now;
        layout.UpdatedBy = "Admin";
        return await layoutRepository.Update(layout, cancellationToken);
    }
}
