﻿namespace DotNet8.DomainDrivenDesignSample.Domain.Features.Blog;

public class BlogRequestModel
{
    public string? BlogTitle { get; set; }
    public string? BlogAuthor { get; set; }
    public string? BlogContent { get; set; }

    public Result<BlogResponseModel> IsValid()
    {
        Result<BlogResponseModel> responseModel;

        if (BlogTitle!.IsNullOrEmpty())
        {
            responseModel = Result<BlogResponseModel>.FailureResult("Blog Title cannot be empty.");
            goto result;
        }

        if (BlogAuthor!.IsNullOrEmpty())
        {
            responseModel = Result<BlogResponseModel>.FailureResult("Blog Author cannot be empty.");
            goto result;
        }

        if (BlogContent!.IsNullOrEmpty())
        {
            responseModel = Result<BlogResponseModel>.FailureResult(
                "Blog Content cannot be empty."
            );
            goto result;
        }

        responseModel = Result<BlogResponseModel>.SuccessResult();

    result:
        return responseModel;
    }
}
