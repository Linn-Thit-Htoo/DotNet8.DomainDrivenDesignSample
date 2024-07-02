﻿using DotNet8.DomainDrivenDesignSample.Domain.Features.Blog;
using DotNet8.DomainDrivenDesignSample.Domain.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.DomainDrivenDesignSample.Application.Features.Blog.GetBlogList
{
    public class GetBlogListQueryHandler : IRequestHandler<GetBlogListQuery, Result<BlogListResponseModel>>
    {
        private readonly IBlogRepository _blogRepository;

        public GetBlogListQueryHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<Result<BlogListResponseModel>> Handle(GetBlogListQuery request, CancellationToken cancellationToken)
        {
            return await _blogRepository.GetBlogList();
        }
    }
}