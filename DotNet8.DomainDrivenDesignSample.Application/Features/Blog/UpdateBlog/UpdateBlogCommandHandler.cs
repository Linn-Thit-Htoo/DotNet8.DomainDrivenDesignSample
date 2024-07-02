using DotNet8.DomainDrivenDesignSample.Domain.Features.Blog;
using DotNet8.DomainDrivenDesignSample.Domain.Resources;
using DotNet8.DomainDrivenDesignSample.Domain.Shared;
using MediatR;

namespace DotNet8.DomainDrivenDesignSample.Application.Features.Blog.UpdateBlog;

public class UpdateBlogCommandHandler
    : IRequestHandler<UpdateBlogCommand, Result<BlogResponseModel>>
{
    private readonly IBlogRepository _blogRepository;

    public UpdateBlogCommandHandler(IBlogRepository blogRepository)
    {
        _blogRepository = blogRepository;
    }

    public async Task<Result<BlogResponseModel>> Handle(
        UpdateBlogCommand request,
        CancellationToken cancellationToken
    )
    {
        if (request.BlogId <= 0)
        {
            return Result<BlogResponseModel>.FailureResult(MessageResource.InvalidId);
        }

        return await _blogRepository.UpdateBlog(request.RequestModel, request.BlogId);
    }
}