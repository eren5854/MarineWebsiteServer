using MarineWebsiteServer.WebAPI.Abstraction;
using MarineWebsiteServer.WebAPI.DTOs.InformationDto;
using MarineWebsiteServer.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace MarineWebsiteServer.WebAPI.Controllers;

public class InformationsController(
    InformationService informationService) : ApiController
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateInformationDto request, CancellationToken cancellationToken)
    {
        var response = await informationService.Create(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var response = await informationService.GetAll(cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateInformationDto request, CancellationToken cancellationToken)
    {
        var response = await informationService.Update(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpGet]
    public async Task<IActionResult> DeleteById(Guid Id, CancellationToken cancellationToken)
    {
        var response = await informationService.DeleteById(Id, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}
