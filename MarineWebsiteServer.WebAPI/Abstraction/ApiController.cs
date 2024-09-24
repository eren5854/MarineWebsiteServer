using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MarineWebsiteServer.WebAPI.Abstraction;
[Route("api/[controller]/[action]")]
[ApiController]

public class ApiController : ControllerBase
{
    //public readonly IMediator _mediator;
    //protected ApiController(IMediator mediator)
    //{
    //    _mediator = mediator;
    //}

}
