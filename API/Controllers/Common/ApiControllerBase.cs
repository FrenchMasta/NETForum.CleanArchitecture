using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Common;

[ApiController]
[Route("api/[controller]")]
public class ApiControllerBase : ControllerBase
{
    protected ISender? _mediatr;

    protected ISender Mediatr => _mediatr ??= HttpContext.RequestServices.GetRequiredService<ISender>();
}