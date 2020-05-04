using Common.Shared;
using Core.Interfaces.Services;
using Grpc.Core;
using Grpc.GrpcConverters;
using MusicMicroservice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grpc.ServicesImplementations
{
    public class ArtistsGrpcServiceImpl : ArtistsGrpcService.ArtistsGrpcServiceBase
    {
        private IArtistsService _artistsService { get; set; }

        public ArtistsGrpcServiceImpl(IArtistsService artistsService)
        {
            _artistsService = artistsService;
        }

        public override Task<GetArtistsResponse> GetArtists(GetArtistsRequest request, ServerCallContext context)
        {

            var artists = _artistsService.GetArtists(new ArtistsPageFilter() { 
                LibraryId = Guid.Parse(request.LibraryId),
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                SearchText = request.SearchText
            });

            var response = new GetArtistsResponse();

            response.Artists.AddRange(artists.Select(a => ArtistGrpcConverter.ToMessage(a)));


            //var popRanks = _libraryService.GetPopularityRankings().Select(s => new PopularityRankingMessage() { Id = s.Id.ToString(), Name = s.Name });

            return Task.FromResult(response);
        }
    }
}
