using MarineWebsiteServer.WebAPI.Abstraction;
using MarineWebsiteServer.WebAPI.DTOs.HomeImageDto;
using MarineWebsiteServer.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace MarineWebsiteServer.WebAPI.Controllers;

public class HomeImagesController(
    HomeImageService homeImageService) : ApiController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromForm]CreateHomeImageDto request, CancellationToken cancellationToken)
    {
        var response = await homeImageService.Create(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var response = await homeImageService.GetAll(cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> Update([FromForm]UpdateHomeImageDto request, CancellationToken cancellationToken)
    {
        var response = await homeImageService.Update(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpGet]
    public async Task<IActionResult> DeleteById(Guid Id, CancellationToken cancellationToken)
    {
        var response = await homeImageService.DeleteById(Id, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}
