using DotNet8.DomainDrivenDesignSample.Domain.Models.Blog;
using DotNet8.DomainDrivenDesignSample.Infrastructure.AppDbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.DomainDrivenDesignSample.Infrastructure.Mapper
{
    public static class Mapper
    {
        public static BlogModel Change(this TblBlog dataModel)
        {
            return new BlogModel
            {
                BlogId = dataModel.BlogId,
                BlogTitle = dataModel.BlogTitle,
                BlogAuthor = dataModel.BlogAuthor,
                BlogContent = dataModel.BlogContent
            };
        }

        public static TblBlog Change(this BlogRequestModel requestModel)
        {
            return new TblBlog
            {
                BlogTitle = requestModel.BlogTitle,
                BlogAuthor = requestModel.BlogAuthor,
                BlogContent = requestModel.BlogContent
            };
        }
    }
}
