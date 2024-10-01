using AutoMapper;
using ED.Result;
using MarineWebsiteServer.WebAPI.DTOs.InformationDto;
using MarineWebsiteServer.WebAPI.Models;
using MarineWebsiteServer.WebAPI.Repositories;

namespace MarineWebsiteServer.WebAPI.Services;

public sealed class InformationService(
    InformationRepository informationRepository,
    IMapper mapper)
{
    public async Task<Result<string>> Create(CreateInformationDto request, CancellationToken cancellationToken)
    {
        Information information = mapper.Map<Information>(request);
        information.CreatedBy = "Admin";
        information.CreatedDate = DateTime.Now;
        //if (request.CreateLinks != null)
        //{
        //    information.Links = mapper.Map<List<Link>>(request.CreateLinks);
        //    foreach (var link in information.Links)
        //    {
        //        link.Information = information;
        //        link.CreatedDate = DateTime.Now;
        //        link.CreatedBy = "Admin";
        //    }
        //}
        return await informationRepository.Create(information,cancellationToken);
    }

    public async Task<Result<string>> DeleteById(Guid id, CancellationToken cancellationToken)
    {
        return await informationRepository.DeleteById(id, cancellationToken);
    }

    public async Task<Result<List<Information>>> GetAll(CancellationToken cancellationToken)
    {
        return await informationRepository.GetAlll(cancellationToken);
    }

    public async Task<Result<string>> Update(UpdateInformationDto request, CancellationToken cancellationToken)
    {
        Information? information = informationRepository.GetById(request.Id);
        if (information is null)
        {
            return Result<string>.Failure("Information kaydı bulunamadı");
        }
        mapper.Map(request, information);
        information.UpdatedDate = DateTime.Now;
        information.UpdatedBy = "Admin";
        //information.Links = mapper.Map<List<Link>>(request.UpdateLinks);
        //foreach (var link in information.Links)
        //{
        //    link.Information = information;
        //    link.UpdatedDate = DateTime.Now;
        //    link.UpdatedBy = "Admin";
        //}
        return await informationRepository.Update(information,cancellationToken);
    }
}
