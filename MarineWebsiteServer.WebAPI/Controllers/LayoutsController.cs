using MarineWebsiteServer.WebAPI.Abstraction;
using MarineWebsiteServer.WebAPI.DTOs.LayoutDto;
using MarineWebsiteServer.WebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MarineWebsiteServer.WebAPI.Controllers;

public class LayoutsController(
    LayoutService layoutService) : ApiController
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpPost]
    public async Task<IActionResult> Create([FromForm]CreateLayoutDto request, CancellationToken cancellationToken)
    {
        var response = await layoutService.Create(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var response = await layoutService.GetAll(cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpPost]
    public async Task<IActionResult> Update([FromForm]UpdateLayoutDto request, CancellationToken cancellationToken)
    {
        var response = await layoutService.Update(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpGet]
    public async Task<IActionResult> DeleteById(Guid Id, CancellationToken cancellationToken)
    {
        var response = await layoutService.DeleteById(Id, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}
