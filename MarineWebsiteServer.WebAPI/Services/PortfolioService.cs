using AutoMapper;
using ED.Result;
using GenericFileService.Files;
using MarineWebsiteServer.WebAPI.DTOs.PortfolioDto;
using MarineWebsiteServer.WebAPI.Models;
using MarineWebsiteServer.WebAPI.Repositories;

namespace MarineWebsiteServer.WebAPI.Services;

public sealed class PortfolioService(
    PortfolioRepository portfolioRepository,
    IMapper mapper)
{
    public async Task<Result<string>> Create(CreatePortfolioDto request, CancellationToken cancellationToken)
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

        Portfolio portfolio = mapper.Map<Portfolio>(request);
        portfolio.Image = image;
        portfolio.CreatedDate = DateTime.Now;
        portfolio.CreatedBy = "Admin";

        return await portfolioRepository.Create(portfolio, cancellationToken);
    }

    public async Task<Result<string>> DeleteById(Guid Id, CancellationToken cancellationToken)
    {
        return await portfolioRepository.DeleteById(Id, cancellationToken);
    }

    public async Task<Result<List<Portfolio>>> GetAll(CancellationToken cancellationToken)
    {
        return await portfolioRepository.GetAll(cancellationToken);
    }

    public async Task<Result<string>> Update(UpdatePortfolioDto request, CancellationToken cancellationToken)
    {
        Portfolio? portfolio = portfolioRepository.GetById(request.Id);
        if (portfolio is null)
        {
            return Result<string>.Failure("Güncellenecek portfolio kaydı bulunamadı");
        }

        string image = "";
        var response = request.Image;
        if (response is null)
        {
            image = portfolio.Image!;
        }
        if (response is not null)
        {
            image = FileService.FileSaveToServer(request.Image!, "wwwroot/Images/");
        }

        mapper.Map(request, portfolio);
        portfolio.Image = image;
        portfolio.UpdatedDate = DateTime.Now;
        portfolio.UpdatedBy = "Admin";

        return await portfolioRepository.Update(portfolio, cancellationToken);
    }
}
