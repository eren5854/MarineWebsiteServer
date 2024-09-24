using AutoMapper;
using ED.Result;
using MarineWebsiteServer.WebAPI.DTOs.HomeDto;
using MarineWebsiteServer.WebAPI.Models;
using MarineWebsiteServer.WebAPI.Repositories;

namespace MarineWebsiteServer.WebAPI.Services;

public class HomeService(
    HomeRepository homeRepository,
    IMapper mapper) : IHomeService
{
    public async Task<Result<string>> Create(CreateHomeDto request, CancellationToken cancellationToken)
    {
        Home home = mapper.Map<Home>(request);
        home.CreatedBy = "Admin";
        home.CreatedDate = DateTime.Now;
        return await homeRepository.Create(home, cancellationToken);
    }

    public async Task<Result<string>> DeleteById(Guid id, CancellationToken cancellationToken)
    {
        return await homeRepository.DeleteById(id, cancellationToken);
    }

    public Task<Result<List<Home>>> GetAll(CancellationToken cancellationToken)
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
        home.UpdatdBy = "Admin";
        home.UpdatdDate = DateTime.Now;

        return await homeRepository.Update(home, cancellationToken);
    }
}
