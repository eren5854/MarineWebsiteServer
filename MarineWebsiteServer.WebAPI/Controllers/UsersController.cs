using MarineWebsiteServer.WebAPI.Abstraction;
using MarineWebsiteServer.WebAPI.DTOs;
using MarineWebsiteServer.WebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MarineWebsiteServer.WebAPI.Controllers;

public class UsersController(
    UserService appUserService) : ApiController
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpPost]
    public async Task<IActionResult> Create(CreateUserDto request, CancellationToken cancellationToken)
    {
        var response = await appUserService.Create(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpGet]
    public async Task<IActionResult> GetById(Guid Id, CancellationToken cancellationToken)
    {
        var response = await appUserService.GetById(Id, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpPost]
    public async Task<IActionResult> Update(UpdateUserDto request, CancellationToken cancellationToken)
    {
        var response = await appUserService.Update(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpGet]
    public async Task<IActionResult> DeleteById(Guid Id, CancellationToken cancellationToken)
    {
        var response = await appUserService.DeleteById(Id, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}
