using DotNet8.DomainDrivenDesignSample.Domain.Models.Blog;
using DotNet8.DomainDrivenDesignSample.Domain.Resources;
using DotNet8.DomainDrivenDesignSample.Domain.Shared;

namespace DotNet8.DomainDrivenDesignSample.Api.Features.Blog;

public class BL_Blog
{
    private readonly IBlogRepository _blogRepository;

    public BL_Blog(IBlogRepository blogRepository)
    {
        _blogRepository = blogRepository;
    }

    public async Task<Result<BlogListResponseModel>> GetBlogList()
    {
        return await _blogRepository.GetBlogList();
    }

    public async Task<Result<BlogResponseModel>> CreateBlog(BlogRequestModel requestModel)
    {
        return await _blogRepository.CreateBlog(requestModel);
    }

    public async Task<Result<BlogResponseModel>> UpdateBlog(BlogRequestModel requestModel, int id)
    {
        Result<BlogResponseModel> responseModel;

        if (id <= 0)
        {
            responseModel = Result<BlogResponseModel>.FailureResult(MessageResource.InvalidId);
            goto result;
        }

        responseModel = await _blogRepository.UpdateBlog(requestModel, id);

    result:
        return responseModel;
    }

    public async Task<Result<BlogResponseModel>> DeleteBlog(int id)
    {
        Result<BlogResponseModel> responseModel;

        if (id <= 0)
        {
            responseModel = Result<BlogResponseModel>.FailureResult(MessageResource.InvalidId);
            goto result;
        }

        responseModel = await _blogRepository.DeleteBlog(id);

    result:
        return responseModel;
    }
}
