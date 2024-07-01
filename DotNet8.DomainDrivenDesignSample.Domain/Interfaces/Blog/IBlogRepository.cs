using DotNet8.DomainDrivenDesignSample.Domain.Models.Blog;
using DotNet8.DomainDrivenDesignSample.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.DomainDrivenDesignSample.Domain.Interfaces.Blog
{
    public interface IBlogRepository
    {
        Task<Result<BlogListResponseModel>> GetBlogList();
        Task<Result<BlogResponseModel>> CreateBlog(BlogRequestModel requestModel);
        Task<Result<BlogResponseModel>> UpdateBlog(BlogRequestModel requestModel, int id);
        Task<Result<BlogResponseModel>> DeleteBlog(int id);
    }
}
