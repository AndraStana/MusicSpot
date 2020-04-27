using Common.Models;
using Common.Shared;
using Grpc.Core;
using Grpc.GrpcConverter;
using Grpc.Interfaces;
using NewsMicroservice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grpc.Services
{
    public class NewsService: INewsService
    {
        const string channelTarget = "localhost:50051";

        public async Task<List<NewsModel>> GetNewsAsync(BasicPageFilter filter)
        {
            var channel = new Channel(channelTarget, ChannelCredentials.Insecure);
            try
            {
                var client = new NewsGrpcService.NewsGrpcServiceClient(channel);
                var request = new GetNewsRequest()
                {
                    PageIndex = filter.PageIndex,
                    PageSize = filter.PageSize
                };

                var response = await client.GetNewsAsync(request);

                return response.News.Select(n => NewsGrpcConverter.ToMessage(n)).ToList();
            }
            finally
            {
                await channel.ShutdownAsync();
            }
        }
    }
}
