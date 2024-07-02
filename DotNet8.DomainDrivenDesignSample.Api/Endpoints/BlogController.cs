namespace DotNet8.DomainDrivenDesignSample.Api.Endpoints;

[Route("api/[controller]")]
[ApiController]
public class BlogController : BaseController
{
    private readonly IMediator _mediator;

    public BlogController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetBlogs()
    {
        try
        {
            var query = new GetBlogListQuery();
            var result = await _mediator.Send(query);

            return Content(result);
        }
        catch (Exception ex)
        {
            return InternalSererError(ex);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateBlog([FromBody] BlogRequestModel requestModel)
    {
        try
        {
            var result = requestModel.IsValid();
            if (result.IsError)
            {
                return BadRequest(result);
            }

            var command = new CreateBlogCommand(requestModel);
            result = await _mediator.Send(command);

            return Content(result);
        }
        catch (Exception ex)
        {
            return InternalSererError(ex);
        }
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateBlog([FromBody] BlogRequestModel requestModel, int id)
    {
        try
        {
            var command = new UpdateBlogCommand(requestModel, id);
            var result = await _mediator.Send(command);

            return Content(result);
        }
        catch (Exception ex)
        {
            return InternalSererError(ex);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBlog(int id)
    {
        try
        {
            var command = new DeleteBlogCommand(id);
            var result = await _mediator.Send(command);

            return Content(result);
        }
        catch (Exception ex)
        {
            return InternalSererError(ex);
        }
    }
}
