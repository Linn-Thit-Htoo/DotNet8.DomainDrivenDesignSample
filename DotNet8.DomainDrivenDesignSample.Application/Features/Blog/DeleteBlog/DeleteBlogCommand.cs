using DotNet8.DomainDrivenDesignSample.Domain.Features.Blog;
using DotNet8.DomainDrivenDesignSample.Domain.Shared;
using MediatR;

namespace DotNet8.DomainDrivenDesignSample.Application.Features.Blog.DeleteBlog;

public class DeleteBlogCommand : IRequest<Result<BlogResponseModel>>
{
    public int BlogId;

    public DeleteBlogCommand(int blogId)
    {
        BlogId = blogId;
    }
}
