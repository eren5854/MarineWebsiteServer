using MarineWebsiteServer.WebAPI.Abstraction;
using MarineWebsiteServer.WebAPI.DTOs.ContactDto;
using MarineWebsiteServer.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace MarineWebsiteServer.WebAPI.Controllers;

public class ContactsController(
    ContactService contactService) : ApiController
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateContactDto request, CancellationToken cancellationToken)
    {
        var response = await contactService.Create(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var response = await contactService.GetAll(cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateContactDto request, CancellationToken cancellationToken)
    {
        var response = await contactService.Update(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpGet]
    public async Task<IActionResult> DeleteById(Guid Id, CancellationToken cancellationToken)
    {
        var response = await contactService.DeleteById(Id, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}
