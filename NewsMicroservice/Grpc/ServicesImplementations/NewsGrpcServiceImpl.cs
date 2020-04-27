using Common.Shared;
using Core.Interfaces.Services;
using Grpc.Core;
using Grpc.GrpcConverters;
using NewsMicroservice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grpc.GrpcServicesImplementations
{
    public class NewsGrpcServiceImpl: NewsGrpcService.NewsGrpcServiceBase
    {
        private INewsService _newsService { get; set; }

        public NewsGrpcServiceImpl(INewsService newsService)
        {
            _newsService = newsService;
        }

        public override Task<GetNewsResponse> GetNews(GetNewsRequest request, ServerCallContext context)
        {
            var basePageFilter = new BasicPageFilter()
            {
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
            };
            var news = _newsService.GetNews(basePageFilter).Select(n => NewsGrpcConverter.ToMessage(n)).ToList();

            var response = new GetNewsResponse();

            response.News.AddRange(news);
            return Task.FromResult(response);
        }
    }
}
