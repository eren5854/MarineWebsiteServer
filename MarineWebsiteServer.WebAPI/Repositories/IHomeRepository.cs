using ED.Result;
using MarineWebsiteServer.WebAPI.Models;

namespace MarineWebsiteServer.WebAPI.Repositories;

public interface IHomeRepository
{
    Task<Result<string>> Create(Home home, CancellationToken cancellationToken);
    Task<Result<string>> Update(Home home, CancellationToken cancellationToken);
    Task<Result<string>> DeleteById(Guid Id, CancellationToken cancellationToken);
    Task<Result<List<Home>>> GetAll(CancellationToken cancellationToken);
    Home? GetById(Guid Id);
}
