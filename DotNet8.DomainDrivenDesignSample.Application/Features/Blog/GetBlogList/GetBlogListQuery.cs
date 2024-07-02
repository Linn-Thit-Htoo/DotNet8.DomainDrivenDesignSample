using DotNet8.DomainDrivenDesignSample.Domain.Features.Blog;
using DotNet8.DomainDrivenDesignSample.Domain.Shared;
using MediatR;

namespace DotNet8.DomainDrivenDesignSample.Application.Features.Blog.GetBlogList;

public class GetBlogListQuery : IRequest<Result<BlogListResponseModel>> { }
