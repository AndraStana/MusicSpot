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
    public class LibraryService : ILibraryService
    {
        const string channelTarget = "localhost:50052";

        public async Task AddSongToLibraryAsync(Guid libraryId, Guid songId)
        {
            var channel = new Channel(channelTarget, ChannelCredentials.Insecure);
            try
            {
                var client = new LibraryGrpcService.LibraryGrpcServiceClient(channel);
                var request = new AddSongToLibraryRequest()
                {
                    LibraryId = libraryId.ToString(),
                    SongId = songId.ToString()
                };

                var response = await client.AddSongToLibraryAsync(request);

                return;
            }
            finally
            {
                await channel.ShutdownAsync();
            }
        }

        public async Task RemoveSongFromLibraryAsync(Guid libraryId, Guid songId)
        {
            var channel = new Channel(channelTarget, ChannelCredentials.Insecure);
            try
            {
                var client = new LibraryGrpcService.LibraryGrpcServiceClient(channel);
                var request = new RemoveSongFromLibraryRequest()
                {
                    LibraryId = libraryId.ToString(),
                    SongId = songId.ToString()
                };

                var response = await client.RemoveSongFromLibraryAsync(request);

                return;
            }
            finally
            {
                await channel.ShutdownAsync();
            }
        }


        public async Task AddLibraryAsync(LibraryAddModel library)
        {
            var channel = new Channel(channelTarget, ChannelCredentials.Insecure);
            try
            {
                var client = new LibraryGrpcService.LibraryGrpcServiceClient(channel);
                var request = new AddLibraryRequest()
                {
                    Id = library.Id.ToString(),
                    Name = library.Name
                };

                var response = await client.AddLibraryAsync(request);

                return;
            }
            finally
            {
                await channel.ShutdownAsync();
            }
        }


        public async Task<List<PopularityRankingModel>> GetPopularityRankingsAsync()
        {
            var channel = new Channel(channelTarget, ChannelCredentials.Insecure);
            try
            {
                var client = new LibraryGrpcService.LibraryGrpcServiceClient(channel);
                var request = new GetPopularityRankingRequest()
                {

                };

                var response =  client.GetPopularityRankings(request);
                var popularityRankings = response.PopularityRankings.Select(s => PopularityRankingGrpcConverter.ToMessage(s)).ToList();
                return popularityRankings;
            }
            finally
            {
                await channel.ShutdownAsync();
            }
        }

        public async Task<LibraryPageModel> GetLibrarySongsAsync(LibraryPageFilter filter)
        {
            var channel = new Channel(channelTarget, ChannelCredentials.Insecure);
            try
            {

                var client = new LibraryGrpcService.LibraryGrpcServiceClient(channel);
                var request = new GetLibrarySongsRequest()
                {
                    UserId = filter.UserId.ToString(),
                    PageIndex = filter.PageIndex,
                    PageSize= filter.PageSize
                };

                if( filter.Genre != null)
                {
                    request.Genre = (int)filter.Genre;
                }

                if (filter.Decade != null)
                {
                    request.Decade = (int)filter.Decade;
                }

                if (filter.PopularityRankingId != null)
                {
                    request.PopularityRankingId = filter.PopularityRankingId.ToString();
                }


                var response = await client.GetLibrarySongsAsync(request);

                return new LibraryPageModel()
                {
                    TotalNumber = response.TotalNumber,
                    Songs = response.Songs.Select(s=> SongGrpcConverter.ToMessage(s)).ToList()
                };
            }
            finally
            {
                await channel.ShutdownAsync();
            }
        }
    }
}
