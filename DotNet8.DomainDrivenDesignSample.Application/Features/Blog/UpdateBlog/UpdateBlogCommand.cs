namespace DotNet8.DomainDrivenDesignSample.Application.Features.Blog.UpdateBlog;

public class UpdateBlogCommand : IRequest<Result<BlogResponseModel>>
{
    public BlogRequestModel RequestModel;

    public int BlogId;

    public UpdateBlogCommand(BlogRequestModel requestModel, int blogId)
    {
        this.RequestModel = requestModel;
        BlogId = blogId;
    }
}
