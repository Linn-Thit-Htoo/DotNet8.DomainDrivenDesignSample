using DotNet8.DomainDrivenDesignSample.Domain.Features.Blog;
using DotNet8.DomainDrivenDesignSample.Domain.Shared;
using MediatR;

namespace DotNet8.DomainDrivenDesignSample.Application.Features.Blog.CreateBlog;

public class CreateBlogCommand : IRequest<Result<BlogResponseModel>>
{
    public BlogRequestModel RequestModel;

    public CreateBlogCommand(BlogRequestModel requestModel)
    {
        this.RequestModel = requestModel;
    }
}