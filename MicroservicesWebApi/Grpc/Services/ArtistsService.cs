using Common.Models;
using Common.Shared;
using Grpc.Core;
using Grpc.GrpcConverter;
using Grpc.Interfaces;
using MusicMicroservice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grpc.Services
{
    public class ArtistsService : IArtistsService
    {
        const string channelTarget = "localhost:50052";

        public async Task<List<ArtistModel>> GetArtistsAsync(ArtistsPageFilter filter)
        {
            var channel = new Channel(channelTarget, ChannelCredentials.Insecure);
            try
            {
                var client = new ArtistsGrpcService.ArtistsGrpcServiceClient(channel);
                var request = new GetArtistsRequest()
                {
                    LibraryId = filter.LibraryId.ToString(),
                    PageIndex = filter.PageIndex,
                    PageSize = filter.PageSize,
                    SearchText = filter.SearchText
                };

                var response = await client.GetArtistsAsync(request);
                var artists = response.Artists.Select(s => ArtistGrpcConverter.ToModel(s)).ToList();
                return artists;
            }
            finally
            {
                await channel.ShutdownAsync();
            }
        }


    }
    //{
    //public async Task<List<PopularityRankingModel>> GetPopularityRankingsAsync()
    //{
    //    var channel = new Channel(channelTarget, ChannelCredentials.Insecure);
    //    try
    //    {
    //        var client = new LibraryGrpcService.LibraryGrpcServiceClient(channel);
    //        var request = new GetPopularityRankingRequest()
    //        {

    //        };

    //        var response = client.GetPopularityRankings(request);
    //        var popularityRankings = response.PopularityRankings.Select(s => PopularityRankingGrpcConverter.ToMessage(s)).ToList();
    //        return popularityRankings;
    //    }
    //    finally
    //    {
    //        await channel.ShutdownAsync();
    //    }
    //}
//}
}
