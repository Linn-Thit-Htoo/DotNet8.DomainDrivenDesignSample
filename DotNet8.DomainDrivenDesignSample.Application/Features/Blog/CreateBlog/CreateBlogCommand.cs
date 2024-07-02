namespace DotNet8.DomainDrivenDesignSample.Application.Features.Blog.CreateBlog;

public class CreateBlogCommand : IRequest<Result<BlogResponseModel>>
{
    public BlogRequestModel RequestModel;

    public CreateBlogCommand(BlogRequestModel requestModel)
    {
        this.RequestModel = requestModel;
    }
}
