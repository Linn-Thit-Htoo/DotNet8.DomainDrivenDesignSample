using DotNet8.DomainDrivenDesignSample.Domain.Features.Blog;
using DotNet8.DomainDrivenDesignSample.Domain.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.DomainDrivenDesignSample.Application.Features.Blog.UpdateBlog
{
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
}
