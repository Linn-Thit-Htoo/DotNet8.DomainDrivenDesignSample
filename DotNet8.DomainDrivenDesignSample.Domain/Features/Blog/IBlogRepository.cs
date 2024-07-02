namespace DotNet8.DomainDrivenDesignSample.Domain.Features.Blog;

public interface IBlogRepository
{
    Task<Result<BlogListResponseModel>> GetBlogList();
    Task<Result<BlogResponseModel>> CreateBlog(TblBlog requestModel);
    Task<Result<BlogResponseModel>> UpdateBlog(BlogRequestModel requestModel, int id);
    Task<Result<BlogResponseModel>> DeleteBlog(int id);
}
