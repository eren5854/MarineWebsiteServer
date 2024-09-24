using ED.Result;
using MarineWebsiteServer.WebAPI.DTOs.HomeDto;
using MarineWebsiteServer.WebAPI.Models;

namespace MarineWebsiteServer.WebAPI.Services;

public interface IHomeService
{
    Task<Result<string>> Create(CreateHomeDto request, CancellationToken cancellationToken);
    Task<Result<string>> Update(UpdateHomeDto request, CancellationToken cancellationToken);
    Task<Result<string>> DeleteById(Guid id, CancellationToken cancellationToken);
    Task<Result<List<Home>>> GetAll(CancellationToken cancellationToken);
}
