using MarineWebsiteServer.WebAPI.Abstraction;
using MarineWebsiteServer.WebAPI.DTOs.PortfolioDto;
using MarineWebsiteServer.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace MarineWebsiteServer.WebAPI.Controllers;

public class PortfoliosController(
    PortfolioService portfolioService) : ApiController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromForm]CreatePortfolioDto request, CancellationToken cancellationToken)
    {
        var response = await portfolioService.Create(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var response = await portfolioService.GetAll(cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> Update([FromForm]UpdatePortfolioDto request, CancellationToken cancellationToken)
    {
        var response = await portfolioService.Update(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpGet]
    public async Task<IActionResult> DeleteById(Guid Id,  CancellationToken cancellationToken)
    {
        var response = await portfolioService.DeleteById(Id, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}
