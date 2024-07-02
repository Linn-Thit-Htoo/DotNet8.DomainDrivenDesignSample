namespace DotNet8.DomainDrivenDesignSample.Infrastructure.Repositories;

public class BlogRepository : IBlogRepository
{
    private readonly AppDbContext _context;

    public BlogRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Result<BlogResponseModel>> CreateBlog(TblBlog requestModel)
    {
        Result<BlogResponseModel> responseModel;
        try
        {
            await _context.TblBlogs.AddAsync(requestModel);
            int result = await _context.SaveChangesAsync();

            responseModel = Result<BlogResponseModel>.ExecuteResult(
                result,
                successStatusCode: EnumHttpStatusCode.Created
            );
        }
        catch (Exception ex)
        {
            responseModel = Result<BlogResponseModel>.FailureResult(ex);
        }

        return responseModel;
    }

    public async Task<Result<BlogResponseModel>> DeleteBlog(int id)
    {
        Result<BlogResponseModel> responseModel;
        try
        {
            var item = await _context.TblBlogs.FindAsync(id);
            if (item is null)
            {
                responseModel = Result<BlogResponseModel>.FailureResult(
                    MessageResource.NotFound,
                    EnumHttpStatusCode.NotFound
                );
                goto result;
            }

            _context.TblBlogs.Remove(item);
            int result = await _context.SaveChangesAsync();

            responseModel = Result<BlogResponseModel>.ExecuteResult(
                result,
                successStatusCode: EnumHttpStatusCode.Accepted
            );
        }
        catch (Exception ex)
        {
            responseModel = Result<BlogResponseModel>.FailureResult(ex);
        }

        result:
        return responseModel;
    }

    public async Task<Result<BlogListResponseModel>> GetBlogList()
    {
        Result<BlogListResponseModel> responseModel;
        try
        {
            var dataLst = await _context.TblBlogs.OrderByDescending(x => x.BlogId).ToListAsync();

            var model = new BlogListResponseModel
            {
                Blogs = dataLst.Select(x => x.Change()).ToList()
            };

            responseModel = Result<BlogListResponseModel>.SuccessResult(model);
        }
        catch (Exception ex)
        {
            responseModel = Result<BlogListResponseModel>.FailureResult(ex);
        }

        return responseModel;
    }

    public async Task<Result<BlogResponseModel>> UpdateBlog(BlogRequestModel requestModel, int id)
    {
        Result<BlogResponseModel> responseModel;
        try
        {
            var item = await _context.TblBlogs.FindAsync(id);
            if (item is null)
            {
                responseModel = Result<BlogResponseModel>.FailureResult(
                    MessageResource.NotFound,
                    EnumHttpStatusCode.NotFound
                );
                goto result;
            }

            if (!requestModel.BlogTitle!.IsNullOrEmpty())
            {
                item.BlogTitle = requestModel.BlogTitle;
            }

            if (!requestModel.BlogAuthor!.IsNullOrEmpty())
            {
                item.BlogAuthor = requestModel.BlogAuthor;
            }

            if (!requestModel.BlogContent!.IsNullOrEmpty())
            {
                item.BlogContent = requestModel.BlogContent;
            }

            _context.Update(item);
            int result = await _context.SaveChangesAsync();

            responseModel = Result<BlogResponseModel>.ExecuteResult(
                result,
                successStatusCode: EnumHttpStatusCode.Accepted
            );
        }
        catch (Exception ex)
        {
            responseModel = Result<BlogResponseModel>.FailureResult(ex);
        }

        result:
        return responseModel;
    }
}
