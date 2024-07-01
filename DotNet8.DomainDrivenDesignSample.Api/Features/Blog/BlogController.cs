using DotNet8.DomainDrivenDesignSample.Domain.Models.Blog;
using Microsoft.AspNetCore.Mvc;

namespace DotNet8.DomainDrivenDesignSample.Api.Features.Blog;

[Route("api/[controller]")]
[ApiController]
public class BlogController : BaseController
{
    private readonly BL_Blog _bL_Blog;

    public BlogController(BL_Blog bL_Blog)
    {
        _bL_Blog = bL_Blog;
    }

    [HttpGet]
    public async Task<IActionResult> GetBlogs()
    {
        try
        {
            var result = await _bL_Blog.GetBlogList();
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

            result = await _bL_Blog.CreateBlog(requestModel);
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
            var result = await _bL_Blog.UpdateBlog(requestModel, id);
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
            var result = await _bL_Blog.DeleteBlog(id);
            return Content(result);
        }
        catch (Exception ex)
        {
            return InternalSererError(ex);
        }
    }
}
