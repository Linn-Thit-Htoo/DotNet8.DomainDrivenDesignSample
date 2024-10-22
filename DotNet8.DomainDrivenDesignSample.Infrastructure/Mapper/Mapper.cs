﻿namespace DotNet8.DomainDrivenDesignSample.Infrastructure.Mapper;

public static class Mapper
{
    #region Blog

    public static BlogModel Map(this TblBlog dataModel)
    {
        return new BlogModel
        {
            BlogId = dataModel.BlogId,
            BlogTitle = dataModel.BlogTitle,
            BlogAuthor = dataModel.BlogAuthor,
            BlogContent = dataModel.BlogContent
        };
    }

    public static TblBlog Map(this BlogRequestModel requestModel)
    {
        return new TblBlog
        {
            BlogTitle = requestModel.BlogTitle,
            BlogAuthor = requestModel.BlogAuthor,
            BlogContent = requestModel.BlogContent
        };
    }

    #endregion
}
