using MarineWebsiteServer.WebAPI.Abstraction;
using MarineWebsiteServer.WebAPI.DTOs.HomeImageDto;
using MarineWebsiteServer.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace MarineWebsiteServer.WebAPI.Controllers;

public class HomeImagesController(
    HomeImageService homeImageService) : ApiController
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateHomeImageDto request, CancellationToken cancellationToken)
    {
        var response = await homeImageService.Create(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}
