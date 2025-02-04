﻿namespace DotNet8.DomainDrivenDesignSample.Application.Features.Blog.DeleteBlog;

public class DeleteBlogCommandHandler
    : IRequestHandler<DeleteBlogCommand, Result<BlogResponseModel>>
{
    private readonly IBlogRepository _blogRepository;

    public DeleteBlogCommandHandler(IBlogRepository blogRepository)
    {
        _blogRepository = blogRepository;
    }

    public async Task<Result<BlogResponseModel>> Handle(
        DeleteBlogCommand request,
        CancellationToken cancellationToken
    )
    {
        if (request.BlogId <= 0)
        {
            return Result<BlogResponseModel>.FailureResult(MessageResource.InvalidId);
        }

        return await _blogRepository.DeleteBlog(request.BlogId);
    }
}
