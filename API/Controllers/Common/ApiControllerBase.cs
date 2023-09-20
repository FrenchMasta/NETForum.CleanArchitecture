﻿using API.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Common;

[ApiController]
[CustomApiExceptionFilter]
[Route("api/[controller]")]
public class ApiControllerBase : ControllerBase
{
    private ISender? _mediatr;

    protected ISender Mediatr => _mediatr ??= HttpContext.RequestServices.GetRequiredService<ISender>();
}