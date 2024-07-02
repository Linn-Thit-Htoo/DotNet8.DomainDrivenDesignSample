using DotNet8.DomainDrivenDesignSample.Domain.Features.Blog;
using DotNet8.DomainDrivenDesignSample.Domain.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.DomainDrivenDesignSample.Application.Features.Blog.DeleteBlog
{
    public class DeleteBlogCommand : IRequest<Result<BlogResponseModel>>
    {
        public int BlogId;

        public DeleteBlogCommand(int blogId)
        {
            BlogId = blogId;
        }
    }
}
