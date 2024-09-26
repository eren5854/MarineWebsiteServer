using MarineWebsiteServer.WebAPI.Abstraction;
using MarineWebsiteServer.WebAPI.DTOs.AboutDto;
using MarineWebsiteServer.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace MarineWebsiteServer.WebAPI.Controllers;

public class AboutsController(
    AboutService aboutService) : ApiController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromForm]CreateAboutDto request, CancellationToken cancellationToken)
    {
        var response = await aboutService.Create(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var response = await aboutService.GetAll(cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> Update([FromForm]UpdateAboutDto request, CancellationToken cancellationToken)
    {
        var response = await aboutService.Update(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpGet]
    public async Task<IActionResult> DeleteById(Guid Id, CancellationToken cancellationToken)
    {
        var response = await aboutService.DeleteById(Id, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}
