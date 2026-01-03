using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Api.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public class VersionedApiController : ControllerBase
{
}