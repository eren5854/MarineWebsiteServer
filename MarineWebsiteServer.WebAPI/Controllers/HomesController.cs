using MarineWebsiteServer.WebAPI.Abstraction;
using MarineWebsiteServer.WebAPI.DTOs.HomeDto;
using MarineWebsiteServer.WebAPI.Services;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MarineWebsiteServer.WebAPI.Controllers;

public class HomesController(
    HomeService homeService) : ApiController
{
    //protected HomesController(IMediator mediator) : base(mediator)
    //{
    //}

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpPost]
    public async Task<IActionResult> Create(CreateHomeDto request, CancellationToken cancellationToken)
    {
        var response = await homeService.Create(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var response = await homeService.GetAll(cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpPost]
    public async Task<IActionResult> Update(UpdateHomeDto request, CancellationToken cancellationToken)
    {
        var response = await homeService.Update(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpGet]
    public async Task<IActionResult> DeleteById(Guid Id, CancellationToken cancellationToken)
    {
        var response = await homeService.DeleteById(Id, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}
