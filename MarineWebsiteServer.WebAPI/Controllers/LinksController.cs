using MarineWebsiteServer.WebAPI.Abstraction;
using MarineWebsiteServer.WebAPI.DTOs.LinkDto;
using MarineWebsiteServer.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace MarineWebsiteServer.WebAPI.Controllers;

public class LinksController(
    LinkService linkService) : ApiController
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateLinkDto request, CancellationToken cancellationToken)
    {
        var response = await linkService.Create(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var response = await linkService.GetAll(cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateLinkDto request, CancellationToken cancellationToken)
    {
        var response = await linkService.Update(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpGet]
    public async Task<IActionResult> DeleteById(Guid Id, CancellationToken cancellationToken)
    {
        var response = await linkService.DeleteById(Id, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}
