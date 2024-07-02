using DotNet8.DomainDrivenDesignSample.Domain.Features.Blog;
using DotNet8.DomainDrivenDesignSample.Domain.Shared;
using DotNet8.DomainDrivenDesignSample.Infrastructure.Mapper;
using MediatR;

namespace DotNet8.DomainDrivenDesignSample.Application.Features.Blog.CreateBlog;

public class CreateBlogCommandHandler
    : IRequestHandler<CreateBlogCommand, Result<BlogResponseModel>>
{
    private readonly IBlogRepository _blogRepository;

    public CreateBlogCommandHandler(IBlogRepository blogRepository)
    {
        _blogRepository = blogRepository;
    }

    public async Task<Result<BlogResponseModel>> Handle(
        CreateBlogCommand request,
        CancellationToken cancellationToken
    )
    {
        return await _blogRepository.CreateBlog(request.RequestModel.Change());
    }
}
