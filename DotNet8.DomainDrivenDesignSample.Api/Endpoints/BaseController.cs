namespace DotNet8.DomainDrivenDesignSample.Api.Endpoints;

[Route("api/[controller]")]
[ApiController]
public class BaseController : ControllerBase
{
    protected IActionResult Content(object obj)
    {
        return Ok(JsonConvert.SerializeObject(obj));
    }

    protected IActionResult InternalSererError(Exception ex)
    {
        return StatusCode(500, ex.Message);
    }
}
